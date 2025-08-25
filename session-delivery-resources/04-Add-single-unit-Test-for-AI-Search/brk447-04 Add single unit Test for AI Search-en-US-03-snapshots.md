# Video: [brk447-04 Add single unit Test for AI Search.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:04:02

# User Manual: Using Copilot Agent to Implement Unit Tests for an AI Search Endpoint

This manual guides you through using Copilot in Agent mode to automatically implement and run unit tests for an AI search endpoint, as demonstrated in the analyzed video. Follow the steps to inspect the solution, generate tests with Copilot, resolve build issues, and run the resulting tests.

---

## Overview

Duration reference: total video length ~ 00:03:57.680

In this workflow you will:
- Identify untested endpoints (AI search, formal search).
- Switch Copilot to Agent mode and create a new chat with the AI Search context.
- Use a quick-action hashtag (e.g., `#implement unit tests`) and select a model (GPT-5) to trigger test generation.
- Let Copilot analyze the solution, add test code, detect missing dependencies, and iterate until the project builds.
- Accept Copilot's changes, open the Test Explorer, and run the new tests.

This approach speeds up test coverage creation and reduces regression risk for endpoints that lack unit tests.

---

## Step-by-step Instructions

Follow these numbered steps exactly to reproduce the demonstrated process.

### 1. Inspect the project to identify missing tests (00:00:13.120)
1. Open your solution in your IDE.
2. Review the endpoints list and identify which endpoints lack unit tests.
   - In the demo, the AI Search endpoint and a formal search endpoint had no tests.
3. Note these missing tests so you can focus Copilot's generation on them.

Snapshot: see the endpoints list to confirm missing coverage.
![Endpoints list showing AI search and formal search](./snapshot-00-00-13.120.png)

Tip: If you maintain an endpoint list or API documentation, cross-reference it to ensure you don’t miss any key endpoints.

---

### 2. Switch Copilot to Agent mode, create a chat, and select context (00:00:34.360)
1. Open Copilot in your IDE.
2. Toggle **Agent mode** (if not already enabled).
3. Click **New Chat** to start a fresh session.
4. In the context selector, choose the **AI Search** context (this focuses Copilot’s analysis on the relevant code).
5. In the model selector choose **GPT-5** (or another available model if GPT-5 is not available).

Snapshot: Copilot Agent mode, New Chat, and Context / Model selectors.
![Copilot Agent mode and New Chat with AI Search context and GPT-5 selected](./snapshot-00-00-34.360.png)

Tip: Selecting the correct context helps Copilot analyze the right parts of your solution and produce more relevant tests.

---

### 3. Trigger the test-generation action using a quick-action hashtag (00:00:45.000)
1. In the Copilot chat input, type a quick-action hashtag such as:
   - `#implement unit tests`
2. Optionally, add brief clarifying text like:
   - “Implement unit tests for the AI Search endpoint and formal search endpoint.”
3. Submit the request to start the automated analysis and code generation.

Snapshot: Hashtag/quick-action entry (e.g., `#implement unit tests`) in the Copilot chat.
![Hashtag quick-action typed in Copilot chat](./snapshot-00-00-45.000.png)

Warning: Keep the request concise but specific — avoid extremely large or ambiguous instructions.

---

### 4. Let Copilot analyze the solution and generate tests (00:01:27.760 – 00:02:59.920)
1. Allow Copilot to read and analyze the codebase. This may take between 1–3 minutes depending on solution size.
2. Copilot will:
   - Generate new test files and code.
   - Attempt to build the solution to verify the generated code compiles.
   - Iterate if build errors occur.
3. Monitor the process; you may see build attempts and background analysis indicators.

Snapshot: Copilot analyzing the solution (analysis in progress).
![Copilot analyzing the codebase and preparing tests](./snapshot-00-01-30.000.png)

Tip: Be patient during analysis. Larger solutions take longer. Avoid interrupting the process unless it’s clearly stuck.

---

### 5. Handle build failures and add missing dependencies (00:02:56.040 – 00:03:05.000)
1. If the build fails, inspect the build output to identify missing packages or references.
   - Typical failures include missing test frameworks or helper packages.
2. Add the required dependencies (e.g., NuGet packages, library references) as suggested.
3. Re-run the build. Copilot may automatically add dependencies and reattempt the build in some environments.

Snapshot: Build output showing errors due to missing dependencies.
![Build failure output showing missing dependencies](./snapshot-00-02-56.040.png)

Snapshot: Dependency additions being applied (package references added).
![Dependency additions / package references added to resolve build errors](./snapshot-00-03-05.000.png)

Warning: When accepting automated dependency changes, review the package versions and licenses to avoid introducing incompatible or unwanted dependencies.

---

### 6. Accept Copilot’s generated changes and open Test Explorer (00:03:19.000)
1. After a successful build, Copilot will have added one or more unit test files.
2. Review the generated files. If acceptable, click the **Accept changes** button (or merge/apply the patch).
3. Open your IDE’s **Test Explorer** (or equivalent test runner tool) to view detected tests.
4. Confirm that new tests appear (e.g., "Products AI test" files or similar).

Snapshot: New test files shown and the Accept changes option visible.
![New unit test files created by Copilot; Accept changes visible](./snapshot-00-03-19.000.png)

Snapshot: Test Explorer showing the new tests ready to run.
![Test Explorer listing new tests generated by Copilot](./snapshot-00-03-30.000.png)

Tip: Review the generated tests’ assertions and mocks to ensure they align with your intended behavior and test strategy.

---

### 7. Run the tests and verify results (00:03:19.000 – 00:04:00.080)
1. In Test Explorer, choose **Run All Tests** or run the specific new tests.
2. Observe the test run output — Copilot’s generated tests should compile and run.
3. Confirm that tests pass (green) or review failures to adjust code/tests accordingly.

Snapshot: Tests running and test results (passing/failing) visible.
![Running tests and viewing results in Test Explorer](./snapshot-00-03-45.000.png)

Tip: If tests fail, examine the failing test details and stack traces, then either:
- Request Copilot to re-evaluate failing tests, or
- Manually adjust mocks and assertions to reflect correct behavior.

---

## Snapshots

(These timestamps identify frames to capture and embed at the indicated steps above.)

- ![Snapshot at 00:00:02.400](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-00-02-400.png)
- ![Snapshot at 00:00:13.120](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-00-13-120.png)
- ![Snapshot at 00:00:34.360](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-00-34-360.png)
- ![Snapshot at 00:00:45.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-00-45-000.png)
- ![Snapshot at 00:01:30.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-01-30-000.png)
- ![Snapshot at 00:02:56.040](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-02-56-040.png)
- ![Snapshot at 00:03:05.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-03-05-000.png)
- ![Snapshot at 00:03:19.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-03-19-000.png)
- ![Snapshot at 00:03:30.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-03-30-000.png)
- ![Snapshot at 00:03:45.000](./images/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-snapshot-00-03-45-000.png)