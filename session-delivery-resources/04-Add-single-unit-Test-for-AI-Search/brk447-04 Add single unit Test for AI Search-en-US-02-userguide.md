# Video: [brk447-04 Add single unit Test for AI Search.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:04:02

# Implementing Unit Tests with Copilot (Agent Mode) — User Manual

This manual describes how to use Copilot in Agent mode to generate and run unit tests for an AI search endpoint, following the workflow demonstrated in the source video. It includes step-by-step instructions, relevant timestamps for reference, UI elements to look for, and helpful tips and warnings.

---

## Overview
(00:00:02 — 00:00:12)

This task guides you through using Copilot to implement unit tests for an AI search endpoint. The goal is to have Copilot analyze the solution, generate missing tests, fix build issues if necessary, and then run the tests using your IDE’s Test Explorer.

Key objectives:
- Identify missing test coverage (AI search endpoint and related formal search).
- Use Copilot Agent mode to generate unit tests.
- Resolve build failures (add dependencies if required).
- Accept the generated code and run the tests.

---

## Step-by-step Instructions

1. **Review the task and target components**
   - Timestamp: 00:00:13 — 00:00:34
   - Actions:
     1. Open your project in the IDE.
     2. Inspect the endpoints list and identify components lacking tests (e.g., AI search endpoint and formal search).
   - Expected outcome: You know which files/endpoints need unit-test coverage.

   Tip: Make a note of endpoint names and file paths so you can confirm generated tests target them.

2. **Switch Copilot to Agent mode and create a new chat**
   - Timestamp: 00:00:34 — 00:01:21
   - Actions:
     1. Toggle Copilot to *Agent mode* in the Copilot UI.
     2. Click **New Chat** to create a fresh chat session.
     3. In the chat context selector, choose the relevant context (e.g., *AI Search*).
     4. Select the model you want Copilot to use (the demo used *GPT‑5*).
     5. In the chat input, use a quick-action hashtag such as `#implement unit tests`.
   - UI elements to look for:
     - Copilot Agent mode toggle
     - New Chat button
     - Context selector (e.g., AI Search)
     - Model selector (e.g., GPT‑5)
     - Hashtag / quick action entry
   - Expected outcome: Copilot is prepared to analyze the AI Search context and generate tests.

   Tip: Using a concise hashtag/quick-action triggers a targeted workflow. You can change models if you prefer a different Copilot capability.

3. **Allow Copilot to analyze the solution and generate tests**
   - Timestamp: 00:01:27 — 00:02:59
   - Actions:
     1. Let Copilot read and analyze the codebase in the selected context.
     2. Allow Copilot to create new test files and modify code as it deems necessary.
     3. Wait while Copilot attempts to build the project and iterates (this can take ~2 minutes or longer depending on project size).
   - Expected outcome: Copilot produces new test code and attempts automatic fixes based on build feedback.

   Warning: Generated code should be reviewed before acceptance. Copilot may add or modify files automatically — ensure you understand the changes.

4. **Handle build failures and missing dependencies**
   - Timestamp: 00:02:56 — 00:03:18
   - Actions:
     1. If the build fails, inspect the build output/errors to determine missing dependencies or compilation issues.
     2. Add the required package references or dependencies to the project (Copilot may propose or create them automatically).
     3. Re-run the build until it succeeds.
   - UI elements to look for:
     - Build output / error messages
     - Package references added to project files
   - Expected outcome: The project builds successfully after dependencies are added.

   Tip: Keep your package manager (NuGet, npm, etc.) UI or CLI available so you can quickly add or update packages suggested by Copilot.

5. **Accept the generated tests and run them**
   - Timestamp: 00:03:19 — 00:04:00
   - Actions:
     1. Review the diff or code changes Copilot produced. Confirm that the tests target the intended endpoints (e.g., products AI test files).
     2. Click **Accept Changes** (or apply the changes in your source control/IDE).
     3. Open the **Test Explorer** in your IDE.
     4. Run the tests (Run All or run the specific new tests).
   - UI elements to look for:
     - Accept changes button
     - Test Explorer
     - Run All Tests button
     - New test files (e.g., products AI test)
   - Expected outcome: New unit tests execute; you can see pass/fail results in Test Explorer.

   Tip: If tests examine external resources, ensure you have appropriate test doubles/mocks or environment settings in place.

6. **Optional — Request broader test coverage**
   - Timestamp: 00:03:19 — 00:04:00 (context)
   - Actions:
     1. If you want coverage beyond the selected context, ask Copilot to “check the entire solution for missing tests” in a follow-up chat.
   - Expected outcome: Copilot will attempt to scan the whole solution and generate additional tests.

   Warning: Scanning the entire solution can take significantly longer and may introduce many changes — review in smaller batches if you prefer tight control.

---

## Tips and Warnings (general)
- Always review generated code before accepting. Automated suggestions can introduce incorrect logic or insecure patterns.
- Commit or branch your current work before accepting large automated changes. This lets you revert if needed.
- If Copilot suggests new dependencies, verify their compatibility and licenses before adding to your project.
- Expect the analysis + build cycle to take time — larger projects will require longer runs.
- Use mocks or stubs for external calls in generated tests to avoid flaky tests and to speed execution.

---

Timestamps referenced correspond to the video demonstration and can help you follow along during each stage of the process.