# Video: [brk447-07-Implement unit tests using GH Issue.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:04:35

# User Manual — Using GitHub Copilot to Implement Missing Unit Tests (Local vs Cloud)

Overview
--------
This manual guides you through delegating missing unit tests to a cloud-isolated GitHub Copilot agent using an issue-driven workflow. It shows how to create or locate an issue describing missing tests, enable the necessary GitHub tools, assign Copilot, review the automatically created pull request (PR), inspect added tests and the agent session, and view CI logs. Each major action corresponds to timestamps from the demonstration for quick reference.

Key outcomes:
- Create or locate an issue requesting missing unit tests
- Assign GitHub Copilot to implement the tests in a cloud-isolated session
- Review the resulting PR, files changed, and session logs
- Inspect CI execution (GitHub Actions) and build logs

Step-by-step Instructions
-------------------------

1) Prepare and choose your workflow (00:00:00 – 00:00:40)
   - Summary (00:00:00 — 00:00:16)
     - Decide whether to implement tests locally (fast for small changes) or delegate to a cloud agent (useful for broader or automated work).
   - Options to trigger automated work (00:00:16 — 00:00:40)
     - Two primary approaches:
       1. Create a GitHub Issue describing the missing unit tests and have Copilot solve it.
       2. Activate Copilot features / GitHub tools (MCP) and assign the issue to Copilot.
   - Tips:
     - Use the issue-based approach when you want traceability and CI-backed PRs.
     - Confirm your repository allows bots/forks if you expect Copilot to create a fork.

2) Enable and authorize GitHub tools (00:00:40)
   - When prompted to use repository search or other GitHub tools, allow the execution/permissions required by the tool.
   - Action:
     - Approve the permissions prompt for the GitHub tools so the cloud agent can search issues, create forks, and open PRs.
   - Warning:
     - Granting permissions lets the tool read and modify repo data per the scopes requested. Review requested scopes before accepting.

3) Search for existing issues (00:00:40 — 00:01:13)
   - Purpose: avoid duplicating work; find issues that already request unit tests.
   - Steps:
     1. Use repository search or the GitHub Issues UI to query keywords like "missing unit tests", "add tests", or specific areas (e.g., "products", "store", "domain entity").
     2. Identify a relevant issue (example found: issue #18).
   - Expected UI elements:
     - Search tool (GitHub tools), Issues list
   - Tip:
     - Narrow searches with labels or filenames (e.g., "tests", "unit") to find existing requests quickly.

4) Inspect the target issue (00:01:14 — 00:01:38)
   - Action:
     1. Open the issue (example: #18).
     2. Review scope, acceptance criteria, task checklist, labels, and any attached metadata.
   - What to look for:
     - Clear acceptance criteria for the tests
     - Specific affected areas (e.g., products, store, domain entities)
     - Tasks that Copilot can complete (e.g., "add tests for X", "verify behavior Y")
   - Tip:
     - If the issue is ambiguous, update it with precise expectations before assigning Copilot.

5) Assign Copilot to the issue (00:01:38 — 00:02:02)
   - Two methods:
     - Preferred: Use the GitHub web UI to assign Copilot to the issue.
     - Alternative: Use Visual Studio integration to assign Copilot directly (if your environment supports it).
   - Steps (GitHub UI):
     1. On the issue page, open the assignees control.
     2. Select GitHub Copilot (or the Copilot automation entry) to assign the issue.
     3. Save/confirm assignment.
   - Expected result:
     - Copilot recognizes the assignment and begins a cloud session to address the issue.
   - Tip:
     - Use the GitHub UI when possible for clearer audit trails and easier tracking.

6) Monitor Copilot’s cloud-isolated session and PR creation (00:02:02 — 00:03:02)
   - After assignment:
     - Refresh the issue page to see Copilot pickup status.
     - Copilot will create a pull request and run isolated in the cloud.
   - Session steps you may see:
     - Creating an environment
     - Creating a fork (if required)
     - Checking out the repository
     - Running planning steps, generating code, and running tests
   - Expected UI elements:
     - Pull Request page, Session/automation activity view, Fork creation workflow
   - Tip:
     - Sessions may take several minutes. The example session for a similar task ran about 18 minutes (see step 7).

7) Review an example completed PR and new test files (00:03:02 — 00:03:55)
   - Actions:
     1. Open the pull request created by Copilot (example: PR #17 was completed earlier).
     2. Inspect "Files changed" (diff view) to see added unit tests (e.g., for products, store, frontend).
     3. Open the session timeline/log view to inspect automated steps (plan, view source, test runs).
   - Things to verify:
     - Tests added cover the acceptance criteria from the issue.
     - No undesirable code changes were introduced outside scope.
     - Session runtime and logs (example runtime ~18 minutes).
   - Tip:
     - Use the session log to understand how Copilot approached test generation and to identify any manual checks needed.

8) Inspect Continuous Integration (CI) run and logs (00:03:55 — 00:04:34)
   - Purpose: confirm tests run in CI and see detailed execution traces.
   - Steps:
     1. From the PR, open the GitHub Actions run associated with the PR.
     2. Open the action run details and inspect the build/test logs.
     3. Trace the logs to see steps executed (install, build, run tests) and final status.
   - Expected UI elements:
     - GitHub Actions run view, full action/build logs
   - Tip:
     - Logs reveal failures or flaky tests; use them to create follow-up tasks if the PR’s tests fail.

Helpful Tips and Warnings
-------------------------
- Refresh to update status: After assigning Copilot, refresh the issue or PR page to view live progress and PR creation.
- Permissions: Authorizing GitHub tools is required for search, fork, and PR creation. Only grant what you trust and review the requested scopes.
- Forks and branches: Copilot often creates a fork and a branch to submit PRs — expect fork creation if you do not permit direct pushes to the main repo.
- CI can take time: Automated sessions plus CI runs add time. Example end-to-end PR session and CI in the demo took roughly 18 minutes for the session, plus CI time.
- Review everything: Automated code generation speeds work, but always review diffs, tests, and CI logs to ensure correctness and adherence to repository standards.
- Use clear issue descriptions: The more specific the issue acceptance criteria, the higher the chance Copilot creates correct and focused tests.

Reference Timestamps
--------------------
- Introduction — Local vs Cloud: 00:00:00.160 – 00:00:16.461
- Options to trigger automated work: 00:00:16.461 – 00:00:40.978
- Search for existing issues: 00:00:40.978 – 00:01:13.760
- Open and inspect issue #18: 00:01:14.240 – 00:01:38.680
- Assign Copilot to the issue: 00:01:38.680 – 00:02:02.600
- Copilot creates a PR and works in cloud: 00:02:02.600 – 00:03:02.360
- Reviewing completed PRs and new test files: 00:03:02.360 – 00:03:55.400
- CI execution: GitHub Actions and logs: 00:03:55.400 – 00:04:34.480

This manual should enable you to reproduce the demonstrated workflow and confidently delegate missing unit tests to a cloud-isolated Copilot agent while keeping oversight through issues, PR review, and CI logs.