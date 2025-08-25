# Video: [brk447-09-coding-agent-implement-payment-PRD.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:35

# User Manual — Using a Product Requirement Document (PRD) with GitHub Copilot to Implement a Fake Payment Service

This manual guides you through the process demonstrated in the video: creating a PRD with GitHub Copilot, using Copilot’s coding agent to implement a fake payment/checkout service in a sample Lava SAPS environment, running and testing the service, and tracing the resulting transaction in Aspire.

- Total demo duration: 00:03:31.400
- Primary tools: Visual Studio, GitHub Copilot (coding agent + developer mode), GitHub repository, sample Lava SAPS app, Aspire tracing UI

---

## Overview
(Reference: 00:00:02.280 — 00:00:29.320)

This technique uses a well-formed Product Requirement Document (PRD) as an input to GitHub Copilot to drive feature implementation. The scenario: generate a PRD for a fake payment server, add it to your repository, instruct Copilot’s coding agent to implement the PRD in the cloud (creating a pull request), then run and test the new checkout/payment service and verify end-to-end traceability using Aspire.

Key outcomes:
- A generated PRD added to your repo
- An automated pull request with implementation and documentation
- A running checkout/payment flow in the sample app
- Traceability from front end to payment service via Aspire

---

## Step-by-step Instructions

Follow the steps below in order. Each major step corresponds to a section of the demo with timestamps for quick reference.

### 1) Prepare and Describe the Scenario to Copilot
(Reference: 00:00:02.280 — 00:00:29.320)

1. Open Visual Studio (or your preferred editor with Copilot enabled).
2. Prepare a concise description of the scenario for Copilot:
   - Example: “Generate a PRD for a fake payment server to be used in the Lava SAPS sample environment for integration testing.”
3. Include environment details: mention the Lava SAPS server and the existing services that will interact with the fake payment server.

Tip: The clearer and more specific your PRD prompt (scope, goals, constraints), the better the generated PRD will align with your needs.

Warning: Treat generated PRDs as starting points — validate dates, scope, and technical choices.

---

### 2) Generate the PRD in Visual Studio with Copilot
(Reference: 00:00:29.320 — 00:01:04.760)

1. Copy your “mega prompt” (the detailed description and constraints) into Visual Studio.
2. Ask GitHub Copilot to generate the PRD (use Copilot’s prompt/response panel).
3. Wait for Copilot to generate the document — generation can take time.
4. Inspect the generated PRD:
   - Verify metadata (dates, author, scope)
   - Review proposed features and acceptance criteria

Expected result: A cohesive PRD file content is produced (ready to be added to repository).

Tip: If the PRD is missing details, iterate by asking Copilot to expand or clarify sections.

---

### 3) Add PRD to Repository and Switch to Coding Agent Mode
(Reference: 00:01:04.760 — 00:01:41.909)

1. Save the generated PRD to your GitHub repository (commit and push if needed).
2. Confirm the PRD file is present in the repository (check via GitHub or your local repo view).
3. Switch Copilot to the coding agent (cloud) mode:
   - Open the Copilot agent panel in your editor or GitHub.
4. Open the sample Lava SAPS repository in the agent panel.
5. Instruct the agent: “Implement the PRD” (or similar instruction that references the PRD file).
6. Allow Copilot’s coding agent to run. It will:
   - Create a branch and a pull request
   - Generate code and supporting files in the background

Expected result: A pull request is created automatically and background tasks begin implementing the PRD.

Warning: The agent may perform multi-step changes autonomously — review all changes in the pull request before merging.

---

### 4) Review Implementation and Generated Documentation
(Reference: 00:01:41.909 — 00:02:21.019)

1. Open the newly created pull request in GitHub.
2. Inspect the implemented code and generated documentation files:
   - Implementation guide
   - Overview and architecture documents
   - New service code (checkout/payment service)
3. Note default choices made by the agent:
   - The agent may choose SQLite by default for local/dev DB (intended to be swapped to SQL Server later).
4. If required, plan edits (for example, switching DB choice to SQL Server) and re-run the agent or edit the code manually.

Tip: Generated docs often include architecture diagrams and setup steps — read these to understand how the new service is wired into the sample app.

Warning: Defaults like SQLite are convenient for quick tests but may not match production requirements. Update configurations before deploying beyond dev/testing.

---

### 5) Run and Test the New Checkout/Payment Service in the App
(Reference: 00:02:21.019 — 00:03:07.240)

1. Start the sample Lava SAPS application with the new checkout/payment service running locally or deployed to your test environment.
2. In the UI:
   - Add two sample products to the cart.
   - Open the cart view and click “Proceed to checkout.”
   - Fill the required fields on the checkout form.
   - Click “Place order.”
3. Observe the UI behavior:
   - Demo mode or legacy UI layout may display — this may not reflect the final intended layout.
4. Verify that the new payment service processed the request and that a new order appears in the system (look in the orders list or relevant UI view).

Expected result: Order placement completes and the system records the new order using the fake payment service.

Tip: If the app is in demo mode and UI layouts look outdated, focus on functional verification (order creation and service calls) rather than visual fidelity.

---

### 6) Trace the Transaction with Aspire and Return to Developer Mode
(Reference: 00:03:07.240 — 00:03:33.680)

1. Open Aspire (your tracing observability tool).
2. Use the trace filter to search for traces related to the payment service.
3. Inspect the end-to-end trace:
   - Confirm the trace shows calls from the frontend -> backend -> payment service.
   - Look for latency, errors, or unexpected steps.
4. Use the trace details to validate service boundaries and data flow.
5. Switch Copilot back to developer mode to make any necessary code fixes or refinements based on trace findings.

Tip: Tracing is useful to confirm that instrumentation and service calls are wired correctly across the system.

Warning: If traces show missing spans or services, verify that the service instrumentation and configuration (e.g., tracing SDK, environment variables) are enabled.

---

## Quick Checklist (What You Should See)
- A PRD file added to the repository. (00:00:29–00:01:04)
- A pull request created by the Copilot coding agent with implementation and docs. (00:01:04–00:01:41)
- Implementation guide and architecture files in the repo; default SQLite usage noted. (00:01:41–00:02:21)
- Successful checkout flow in the sample app and a new order recorded. (00:02:21–00:03:07)
- Aspire trace showing the frontend -> backend -> payment service path. (00:03:07–00:03:33)

---

## Tips & Best Practices
- Always review agent-created pull requests before merging.
- Use PRDs to drive consistent, scoped implementation from Copilot.
- Update default configuration choices (e.g., SQLite → SQL Server) early if your environment requires them.
- Use tracing tools (Aspire) after running flows to validate real end-to-end behavior.
- If Copilot’s generated PRD or code misses details, iterate by refining the prompt or adjusting the PRD.

## Warnings
- Generated artifacts are suggestions: verify security, data handling, and production suitability before deploying.
- Automated agents can make sweeping changes — review diffs thoroughly.
- Demo mode or sample UIs are not production-ready; expect visual and configuration differences.

---

This manual should enable you to reproduce the demo workflow: generate a PRD with Copilot, use the coding agent to implement it, run and validate the checkout/payment flow, and trace the transaction end-to-end.