# Video: [brk447-07-Implement unit tests using GH Issue.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:04:35

# User Manual — Using GitHub Copilot (Cloud Agent) to Implement Missing Unit Tests

Last video timestamp: 00:04:34.480

---

## Overview

This manual describes how to delegate missing unit test implementation to a cloud-isolated GitHub Copilot agent using an issue-driven workflow. It covers:

- When to use a cloud agent vs. local testing (00:00:00.160–00:00:16.461)
- Triggering automation via GitHub Issues and assigning Copilot (00:00:16.461–00:01:38.680)
- Searching for existing issues and granting tool permissions (00:00:40.978–00:01:13.760)
- Monitoring Copilot's cloud session and the generated Pull Request (00:02:02.600–00:03:02.360)
- Reviewing added unit tests and inspecting CI (00:03:02.360–00:04:34.480)

This process allows Copilot to work in an isolated cloud environment, create a fork/branch, run automation, add tests, and open a pull request for review.

---

## Step-by-step Instructions

Follow these steps to delegate missing unit test creation to GitHub Copilot and review the results.

### 1. Decide to Delegate to Cloud Agent (Local vs Cloud) — [00:00:00.160]

1. Confirm the unit tests you tried locally are incomplete or would take more time than desirable.
2. Choose to delegate the missing tests to a cloud-isolated Copilot session when:
   - The work requires generating multiple unit tests across parts of the repository.
   - You want the work to run in an isolated environment (no local changes required).
3. Note the tradeoff: cloud sessions take time to provision and run (example session took ~18 minutes) but produce a PR with changes.

Tip: Use local implementation for quick, small tests; use Copilot cloud sessions for broader or repetitive test implementation.

Snapshot: See the decision point UI and intro (00:00:00.160).

---

### 2. Prepare GitHub Integration and Tools — [00:00:16.461]

1. Ensure your repository has:
   - GitHub Issues enabled.
   - GitHub Copilot and the relevant GitHub tools (MCP) enabled for your organization/repo.
2. If integration is not yet enabled, activate it in your GitHub and/or Visual Studio environment:
   - In GitHub: enable Copilot and any required repository-level tools.
   - In Visual Studio: confirm the GitHub Tools/extension is connected to your account.

Warning: Copilot cloud sessions require permission to run. You will be prompted to grant execution permission the first time.

Snapshot: Tools and integration options (00:00:16.461).

---

### 3. Search for Existing Issues About Missing Tests — [00:00:40.978]

1. Use your repository search (or the enabled GitHub tool) to find existing issues related to missing unit tests:
   - Example search query: "missing unit tests" or "add missing unit tests".
2. When prompted, allow the GitHub tool to execute searches on your repo.
3. Inspect the search results for a relevant issue (the video finds issue #18).

Tip: Reusing an existing issue prevents duplicate work and leverages any prior context.

Snapshot: Search results and permissions prompt (00:00:40.978).

---

### 4. Open and Inspect the Issue (Issue #18) — [00:01:14.240]

1. Open the issue page for the found issue (e.g., #18).
2. Review the issue details:
   - Scope description: what tests are missing (products, store, domain entity).
   - Acceptance criteria and task list (checklist items).
   - Labels, assignees, and any linked metadata.
3. If the issue lacks detail, add clarification comments or acceptance criteria before assigning automation.

Tip: Well-scoped issues yield better automated changes. Clarify edge cases in the issue body.

Snapshot: Issue #18 details page (00:01:14.240).

---

### 5. Assign Copilot to the Issue — [00:01:38.680]

You can assign Copilot to the issue using either the GitHub web UI (recommended) or directly from Visual Studio.

Method A — GitHub UI (recommended)
1. On the issue page, locate the "Assignees" control.
2. Select or add "GitHub Copilot" (or the organization-specific Copilot bot) as the assignee.
3. Optionally add a label like "help wanted" or "automation" to indicate automated processing.

Method B — Visual Studio
1. In Visual Studio, open the repository's issue panel.
2. Assign Copilot to the issue using the integration controls.

After assignment:
- Refresh the issue page to see Copilot pickup.
- Copilot will create a Pull Request and begin running tasks in a cloud session.

Warning: Make sure you have permitted Copilot automation for the repository; otherwise the agent cannot start.

Snapshot: Assign Copilot to issue control (00:01:38.680).

---

### 6. Monitor Copilot Cloud Session & Pull Request Creation — [00:02:02.600]

1. After Copilot picks up the issue, a Pull Request will be created automatically.
2. Open the newly created Pull Request from the issue page or the PR list.
3. View the session activity that Copilot runs:
   - Environment creation
   - Fork creation
   - Repository checkout
   - Plan and code generation steps
4. The session timeline/log shows the automated steps and status.

Expected behavior:
- The PR will show the session steps and an estimate of runtime. Example: an ~18 minute session produced multiple test files.

Tip: Allow the session to complete before reviewing the PR files to ensure all tasks are finished.

Snapshot: PR page showing session steps (00:02:02.600).

---

### 7. Review the Pull Request and New Test Files — [00:03:02.360]

1. In the Pull Request page, open the "Files changed" (diff) view.
2. Examine added and modified files:
   - Unit tests for products and store
   - Frontend tests or domain entity tests, if added
3. Read automated commit messages and any session-generated notes.
4. Use the session timeline/log to understand the sequence of actions the agent executed (e.g., plan, view source, run tests).

Checklist for review:
- Does each new test meet the acceptance criteria?
- Are test names and assertions clear and maintainable?
- Are there any style or lint issues introduced?

Tip: If the PR includes failing tests, inspect the session log to see if the agent attempted to run tests and what errors occurred.

Snapshot: PR files changed and session log (00:03:02.360).

---

### 8. Inspect Continuous Integration (GitHub Actions) Execution and Logs — [00:03:55.400]

1. From the Pull Request, locate the GitHub Actions status (CI badge) or the "Checks" tab.
2. Open the relevant Actions run to view the build/test execution.
3. Inspect the full action logs to trace what happened during the automated process:
   - Environment provisioning steps
   - Test run output and failure traces (if any)
   - Any post-run cleanup steps

How to use logs:
- Identify failing tests and exact stack traces.
- Determine whether failures are due to environment differences or code issues.
- Use logs to create follow-up issues or request Copilot to update the PR.

Warning: CI failures may require a local reproduction to debug environment-specific issues.

Snapshot: GitHub Actions run and logs view (00:03:55.400).

---

## Visual Snapshots (inline placeholders)

Below are inline snapshot placeholders that match key steps. Replace each placeholder with a captured image frame from the timestamp indicated.

- Introduction — local vs. cloud decision (00:00:00.160)  
  ![Snapshot: Local vs Cloud decision screen](./snapshot-00_00_00_160.png)

- Tools & options to trigger automation (GitHub Issues / Copilot / MCP) (00:00:16.461)  
  ![Snapshot: GitHub tools and Copilot options](./snapshot-00_00_16_461.png)

- Repository search with permission prompt (00:00:40.978)  
  ![Snapshot: Search results and permission prompt](./snapshot-00_00_40_978.png)

- Opened issue #18 showing scope and acceptance criteria (00:01:14.240)  
  ![Snapshot: Issue #18 details page](./snapshot-00_01_14_240.png)

- Assigning Copilot to the issue (assign control highlighted) (00:01:38.680)  
  ![Snapshot: Assign Copilot control on issue](./snapshot-00_01_38_680.png)

- Pull Request created by Copilot with session steps visible (00:02:02.600)  
  ![Snapshot: PR page showing Copilot session steps](./snapshot-00_02_02_600.png)

- Files changed / diff view showing newly added unit tests (00:03:02.360)  
  ![Snapshot: Files changed view with new tests](./snapshot-00_03_02_360.png)

- CI run (GitHub Actions) and full log view (00:03:55.400)  
  ![Snapshot: GitHub Actions run log view](./snapshot-00_03_55_400.png)

---

## Tips & Warnings (short summary)

- Tip: Ensure issues are well-scoped — the clearer the acceptance criteria, the better quality output from Copilot.
- Tip: Review session logs to understand the agent's reasoning and detect unintended changes.
- Warning: Grant only necessary permissions for automated tools; review security policies before enabling cloud agents.
- Warning: CI failures may not be caused by generated tests; verify environment parity before rejecting a PR.

---

## Snapshots

[00:00:00.160]  
[00:00:16.461]  
[00:00:40.978]  
[00:01:14.240]  
[00:01:38.680]  
[00:02:02.600]  
[00:03:02.360]  
[00:03:55.400]