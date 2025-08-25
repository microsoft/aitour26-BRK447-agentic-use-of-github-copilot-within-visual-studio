# Video: [brk447-06-query mcp ms learn.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:45

# User Manual — Using GitHub Copilot Agent to Update EF Core 9 DB Initialization

This manual guides you through the workflow demonstrated in the video: inspecting a backend "products" project, using the GitHub Copilot agent with Microsoft Docs as a tool, and updating the Entity Framework Core database initialization pattern (moving from EnsureCreatedAsync to MigrateAsync when appropriate). Timestamps link to the video sections for quick reference.

---

## Overview

This guide covers:

- Inspecting the existing project and database initializer pattern (00:00:01.840 – 00:00:23.520)
- Enabling the GitHub Copilot agent and granting it access to Microsoft Docs (00:00:23.520 – 00:01:14.800)
- Handling the tool permission prompt (00:00:57.240 – 00:01:24.960)
- Reviewing the agent's documentation-backed recommendations (00:01:24.960 – 00:02:12.360)
- Starting a new agent session, selecting a model, and allowing file access for code changes (00:02:12.360 – 00:02:51.653)
- Applying the agent’s code changes (e.g., using MigrateAsync instead of EnsureCreatedAsync) and reviewing diffs (00:02:51.653 – 00:03:44.720)

This manual assumes you want a reproducible, documented way to let an AI agent review docs and apply safe EF Core changes.

---

## Step-by-step Instructions

Follow these steps to reproduce the workflow and update your database initialization approach.

### 1. Inspect the project and identify the DB initializer (00:00:01.840)
- Open your "products" backend project in your IDE.
- Open the files of interest:
  - Products model(s)
  - Your DbContext class
  - The DB initializer class (a class that calls EnsureCreatedAsync or similar)
- Confirm the current initialization pattern. Common patterns:
  - Using EnsureCreatedAsync directly (often not recommended if you also use migrations)
  - Using migrations with MigrateAsync

Tip: Take note of any comments or custom logic in the initializer — the agent will need to see context.

Inline snapshot:
![Project open showing Products, DbContext and DB initializer (00:00:01.840)](./snapshots/00-00-01-840.png)

### 2. Enable GitHub Copilot agent mode (00:00:23.520)
- Locate the GitHub Copilot agent toggle in your IDE or Copilot UI.
- Switch the agent mode to "enabled" so it can act on prompts and use tools.
- Prepare a concise prompt for the agent. Example prompt:
  - "Is the current DB initializer implementation correct for EF Core 9? Please search Microsoft Docs and base your answer on the full documentation."

Inline snapshot:
![Enable GitHub Copilot agent mode and Microsoft Docs tool (00:00:23.520)](./snapshots/00-00-23-520.png)

### 3. Enable the Microsoft Docs tool for the agent (00:00:23.520)
- In the agent tool list, enable Microsoft Docs (or a docs search tool) so the agent can consult official documentation.
- Confirm that the tool is active in the session.

Tip: Using the official docs tool ensures recommendations are grounded in authoritative guidance.

### 4. Respond to the tool permission prompt (00:00:57.240)
- When the agent attempts to use an external tool, your environment should show a permission dialog (for safety).
- Choose one of the options:
  - "Always allow" — grants persistent permission for this tool from this agent
  - "Allow only this time" — grants permission for this session only
- For exploratory sessions, choose "Allow only this time" to limit long-term tool access.

Warning: Only grant tool permissions to trusted agents and tools. Tool access allows the agent to fetch external content.

Inline snapshot:
![Permission dialog offering 'Always allow' or 'Allow only this time' (00:00:57.240)](./snapshots/00-00-57-240.png)

### 5. Wait for the agent’s analysis and review results (00:01:24.960)
- The agent will run searches against Microsoft Docs and analyze your prompt. This can take a couple of minutes.
- Review the agent's response panel. Typical output:
  - Confirmation if the current initializer is acceptable
  - Recommended alternate approach(es) for EF Core 9
  - Links to Microsoft Docs and specific references
- Note: The agent may list two or more implementation options (e.g., use MigrateAsync with migrations, or keep EnsureCreatedAsync only for non-migration scenarios).

Inline snapshot:
![Agent response panel with documentation-backed recommendation (00:01:24.960)](./snapshots/00-01-24-960.png)

### 6. Start a new agent session to implement changes and select a model (00:02:12.360)
- Start a new agent session when you want the agent to modify code.
- Select which model to run this session with (examples: GPT-4.1, GPT-5). Note: each agent session is tied to a specific model.
- Grant the agent permission to read the project files it needs (e.g., Program.cs, DbContext, initializer class).
- Explicitly request the agent to implement the recommended changes from the Microsoft Docs references.

Tip: Use a stronger model for code edits if available. Models can differ in code quality and understanding of context.

Inline snapshot:
![Starting a new agent session and selecting a model (00:02:12.360)](./snapshots/00-02-12-360.png)

### 7. Let the agent modify code and review diffs (00:02:51.653)
- The agent will open and edit files to implement the recommended pattern. Typical edits include:
  - Replacing EnsureCreatedAsync with MigrateAsync when you are using EF Core migrations
  - Adjusting Program.cs or startup code to call MigrateAsync during application startup
  - Updating the DB initializer class to be migration-aware
- Review the agent’s diffs or change previews carefully.
- If your environment supports it, either:
  - Accept and apply the changes directly from the agent UI, or
  - Manually review and merge the changes via your version control workflow.

Key code guidance:
- When you rely on EF Core migrations, prefer:
  - await context.Database.MigrateAsync();
- Avoid EnsureCreatedAsync when you plan to use migrations; EnsureCreated bypasses migrations and may create schema incompatible with migration history.

Inline snapshot:
![Agent applies code changes and shows diff/preview (00:02:51.653)](./snapshots/00-02-51-653.png)

### 8. Final review and confirmation (00:03:44.720)
- Run unit tests, integration tests, or start the application to confirm the new initialization approach behaves as expected.
- Validate that migrations are applied correctly and that the migration history table (__EFMigrationsHistory) exists and reflects applied migrations.

Inline snapshot:
![Final state after agent-modified files and recommendations (00:03:44.720)](./snapshots/00-03-44-720.png)

---

## Tips and Best Practices

- Use "Allow only this time" for tool access during initial exploratory sessions; escalate to "Always allow" only for trusted automation.
- Keep migrations in source control and apply them with MigrateAsync during startup if you rely on migrations for schema changes.
- Avoid EnsureCreatedAsync in production environments if you also use migrations — it bypasses the migrations pipeline.
- Review all agent-proposed code changes manually before merging them into main branches.

## Warnings

- Automated agents can make incorrect or incomplete changes. Always review diffs and run tests.
- Grant tool access only when you trust the tool and the agent's intent. Tool access can expose code and environment details to external services.

---

## Snapshots

[00:00:01.840]  
[00:00:23.520]  
[00:00:57.240]  
[00:01:24.960]  
[00:02:12.360]  
[00:02:51.653]  
[00:03:44.720]