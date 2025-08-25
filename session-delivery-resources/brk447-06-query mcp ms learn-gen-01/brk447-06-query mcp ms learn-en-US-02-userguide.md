# Video: [brk447-06-query mcp ms learn.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:45

# GitHub Copilot Agent: Updating EF Core 9 DB Initialization — User Manual

This manual shows how to reproduce the workflow demonstrated in the video: inspect a backend "products" project that uses Entity Framework, use the GitHub Copilot agent with the Microsoft Docs tool to verify the current database initialization approach, and update the project to follow EF Core 9 recommendations (for example, replacing EnsureCreatedAsync with MigrateAsync when using migrations). Each major action includes timestamps (from the source video) so you can follow along.

---

## Overview
(00:00:01.840 — 00:03:44.720)

This workflow covers:

- Inspecting a .NET backend "products" project to identify the current DB initializer pattern and DbContext. (00:00:01.840 — 00:00:23.520)  
- Enabling GitHub Copilot agent mode and granting it the Microsoft Docs tool to search documentation. (00:00:23.520 — 00:01:14.800)  
- Responding to the tool permission prompt. (00:00:57.240 — 00:01:24.960)  
- Waiting while the agent searches Microsoft Docs and returns recommendations (often a minute or two). (00:01:24.960 — 00:02:12.360)  
- Starting a new agent session tied to a specific model (e.g., GPT-4.1 or GPT-5) to implement recommended changes. (00:02:12.360 — 00:02:51.653)  
- Applying changes the agent suggests to align the project with EF Core 9 guidance (for example, switching to MigrateAsync). (00:02:51.653 — 00:03:44.720)

Key outcomes:
- The agent can search Microsoft Docs and return exact documentation links and recommendations.
- EF Core 9 best practice: when using migrations, prefer MigrateAsync over EnsureCreatedAsync.
- The agent can edit project files (Program, DbContext, initializer class) and show diffs for review.

---

## Step-by-step Instructions

Follow these steps to reproduce the process and apply EF Core 9 recommended DB initialization changes using GitHub Copilot agent.

### 1) Inspect the project and identify the DB initializer
(00:00:01.840 — 00:00:23.520)

1. Open your code editor or IDE and load the backend "products" project.
2. Open and review these files:
   - Product entity/listing files
   - Your DbContext class
   - Any DB initializer or database bootstrapper class (e.g., a custom initializer that calls EnsureCreatedAsync)
3. Note the current initialization approach. Common patterns:
   - EnsureCreatedAsync — creates a database but bypasses migrations
   - MigrateAsync — applies pending migrations (recommended when you use migrations)

Tip: If you see EnsureCreated/EnsureCreatedAsync in production or migration-enabled projects, this is commonly a red flag — read on.

---

### 2) Enable GitHub Copilot agent and the Microsoft Docs tool
(00:00:23.520 — 00:01:14.800)

1. Toggle GitHub Copilot agent mode in the Copilot UI (look for the agent/session toggle).
2. In the agent setup, enable the Microsoft Docs tool (or add it from the tools list).
3. Compose your initial prompt. Example prompt:
   - "I have a DB initializer in this project that calls EnsureCreatedAsync. Is this the correct way to initialize databases with EF Core 9? Please search Microsoft Docs and base your answer on the full Microsoft Docs content. Provide recommended alternatives and links."
4. Submit the prompt to the agent.

Tip: Be explicit in the prompt that the agent should search Microsoft Docs and base recommendations on the official docs.

Warning: Granting an agent access to external tools and project files can expose code — only allow tools you trust and for sessions you control.

---

### 3) Respond to the tool permission prompt
(00:00:57.240 — 00:01:24.960)

1. When the agent attempts to use the Microsoft Docs tool, the system will display a permission dialog for safety.
2. Choose the permission scope:
   - "Allow only this time" (recommended for single-session testing)
   - "Always allow" (use carefully for trusted workflows)
3. Confirm to let the agent run the tool for the chosen scope.

Tip: Use "Allow only this time" if you’re experimenting. Use "Always allow" in a controlled CI or team setting after careful review.

---

### 4) Wait for the agent to analyze and return recommendations
(00:01:24.960 — 00:02:12.360)

1. The agent will search Microsoft Docs and analyze results; this can take a couple of minutes.
2. Review the agent’s summary and the documentation links it returns.
3. Expect the agent to:
   - Confirm whether the existing initializer is acceptable
   - Recommend EF Core 9 best practices (for example, use MigrateAsync when using migrations)
   - Provide multiple implementation options or patterns with links to official docs

Tip: Keep an eye on the agent response panel and click links to read the referenced docs yourself.

---

### 5) Start a new agent session and select the model for implementing changes
(00:02:12.360 — 00:02:51.653)

1. Start a new agent session specifically for code changes (separate from the analysis session).
2. Select a model for the session. Typical options:
   - GPT-4.1
   - GPT-5 (if available)
3. In the new session, prompt the agent to implement the recommended changes from the documentation search:
   - Example: "Please update the initializer and Program/DbContext files to follow EF Core 9 recommendations. Use MigrateAsync if migrations are present. Make only necessary changes and show diffs."

4. Allow the agent permission to read the relevant project files (Program.cs, DbContext, initializer class, migration files).

Tip: Each agent session is tied to the chosen model; select the one that best matches your needs for accuracy vs cost.

---

### 6) Review and apply the agent’s code changes
(00:02:51.653 — 00:03:44.720)

1. The agent will generate edits and present a diff/preview for modified files (Program, DbContext, initializer class).
2. Common recommended changes you will see:
   - Replace EnsureCreatedAsync with MigrateAsync when you use migrations:
     - Why: EnsureCreated bypasses migrations and is not compatible with applying subsequent migrations cleanly.
   - Adjust Program.cs to call the initializer code during app startup using DI and scoped services.
   - Update initializer logic to:
     - Use MigrateAsync (await dbContext.Database.MigrateAsync()) when migrations are used
     - Or keep EnsureCreatedAsync only in scenarios where you do not use migrations (typically local prototypes or tests)
3. Inspect the diff carefully:
   - Verify code correctness, error handling, and logging.
   - Ensure appropriate use of async/await and service scopes.
4. Accept or manually refine the changes:
   - Use the IDE or Copilot UI to apply the edits to your repository.
   - Run unit/integration tests and build to ensure no regressions.

Warnings:
- Do not blindly accept automated changes without code review.
- Always run tests and validate database migrations in a safe environment before deploying to production.
- Back up your database/schema before applying migrations in production environments.

---

## Tips & Best Practices

- When to use MigrateAsync vs EnsureCreatedAsync:
  - Use MigrateAsync if you maintain and apply migrations (recommended for most production scenarios).
  - Use EnsureCreatedAsync only for quick prototypes, tests, or scenarios where you will never use migrations.
- Always review the Microsoft Docs links provided by the agent — they are authoritative and may include caveats or additional migration guidance.
- Prefer "Allow only this time" when trying out tools; lock down permissions for production workflows.
- Keep separate agent sessions for documentation analysis and for code modification — this keeps the flow organized and reduces accidental edits.

---

Timestamps reference:
- Scenario introduction: 00:00:01.840 — 00:00:23.520  
- Enable Copilot agent & Docs tool: 00:00:23.520 — 00:01:14.800  
- Tool permission prompt: 00:00:57.240 — 00:01:24.960  
- Agent search and recommendations: 00:01:24.960 — 00:02:12.360  
- Start new agent session & model selection: 00:02:12.360 — 00:02:51.653  
- Agent implements code changes: 00:02:51.653 — 00:03:44.720

This manual gives the actionable steps to reproduce the video workflow: verify an EF Core 9 DB initialization approach using GitHub Copilot agent and Microsoft Docs, then implement and verify the recommended changes.