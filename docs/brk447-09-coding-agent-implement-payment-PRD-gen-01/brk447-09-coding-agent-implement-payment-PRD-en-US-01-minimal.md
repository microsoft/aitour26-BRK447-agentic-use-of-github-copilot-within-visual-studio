# Video: [brk447-09-coding-agent-implement-payment-PRD.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:35

1. Describe the scenario to Copilot and request a PRD for a fake payment server in the Lava SAPS environment. [00:00:02.280]
2. Copy the mega prompt into Visual Studio and ask Copilot to generate the PRD, then wait for generation to finish. [00:00:29.320]
3. Inspect the generated PRD content (dates, scope, proposed features). [00:00:29.320]
4. Add the PRD to the GitHub repository and verify the file is present. [00:01:04.760]
5. Switch Copilot to coding agent (cloud) mode, open the sample repository, and use the agent panel to instruct “implement the PRD.” [00:01:04.760]
6. Allow the agent to create a pull request and run background tasks until implementation completes. [00:01:41.909]
7. Open the repository and review the generated code and documentation, including the implementation guide and architecture. [00:01:41.909]
8. Note the default database choice (SQLite) in the generated config and plan to change to SQL Server if needed. [00:01:41.909]
9. Start the application with the new checkout/payment service, add two sample products to the cart, and open the cart. [00:02:21.019]
10. Click “proceed to checkout,” fill in the required information, and place the order. [00:02:21.019]
11. Open Aspire traces, filter for the payment service, inspect the end-to-end trace from frontend to backend to payment service, and then switch Copilot back to developer mode to make changes. [00:03:07.240]

Related guides:

- [Full user manual](./brk447-09-coding-agent-implement-payment-PRD-en-US-02-userguide.md)
- [User manual with snapshots](./brk447-09-coding-agent-implement-payment-PRD-en-US-03-snapshots.md)
