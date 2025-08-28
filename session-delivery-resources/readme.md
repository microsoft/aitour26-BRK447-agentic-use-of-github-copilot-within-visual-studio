## How to deliver this session

🥇 Thanks for delivering this session!

Prior to delivering the workshop please:

1. Read this document and all included resources in their entirety.
2. Watch the recorded setup and demo videos referenced in the resources.
3. Ask questions of the content leads if anything is unclear — they're available to help.

## 📁 File Summary

| Resources | Links | Description |
|---|---|---|
| Session Delivery Deck | [Deck](https://aka.ms/AAxqj50>) | The session delivery slides |
| Demo source code | [demo source code](../src/) | Demo Source Code |
| Demo source code BackUp | [demo source code backup](../srcBackUp/) | Source Code completed for each one of the demo steps |

## 🚀 Get Started

The workshop mixes short live demos (30–90s) with recorded segments for longer or fragile flows. Follow the step-by-step user guides in the `docs/` folder for setup and demo scripts.

### 🕐 Timing

| Time | Description | Type, content or demos | Links |
|---:|---|---|---|
| 05 mins |  Introduction | content | |
| 04 mins |  Demo 1 | demos | [02-Zava-Overview (00:57)](https://aka.ms/AAxqc9f) <br/> [03-VS2022-and-GHCP-Overview (02:43)](https://aka.ms/AAxqj53) |
| 03 mins |  GH Copilot Agents | content | |
| 04 mins |  Demo 2 | demos  | [04-Add-single-unit-Test-for-AI-Search (04:02)](https://aka.ms/AAxqc9g) |
| 05 mins |  MCP Tools | content | |
| 07 mins |  Demo 3 | demos | [05-add-mcp-servers (02:42)](https://aka.ms/AAxqc9j) <br /> [(optional) 06-query-mcp-ms-learn (03:45)](https://aka.ms/AAxq4rk) <br /> [07-Implement-unit-tests-using-GH-Issue (04:35)](https://aka.ms/AAxqj52) |
| 03 mins |  Coding Agent | content | |
| 09 mins |  Demo 4 | demos | [08-update-ui-using-agent-based-on-images (05:05)](https://aka.ms/AAxq4rn) <br /> [09-coding-agent-implement-payment-PRD (03:35)](https://aka.ms/AAxqc9e) |
| 02 mins |  WrapUp | content | |

> Timing table left intentionally as-is per instructions (time cells left empty for manual updates).

### 🏋️ Preparation

These items are required as presenter pre-work and should NOT be listed as session objectives.

Essential Pre-Setup Requirements:

- Review the Initial Setup guide and recorded setup video: [Initial Setup Guide](/session-delivery-resources/01-Initial-Setup/brk447-01-Initial%20Setup-en-US-01-minimal.md)
- Set up Azure AI services and local development environment
- Run coding agent actions before the event

Optional pre-deploys (presenter choice): pre-deploy AI resources or collect connection strings if you plan to demo live services — otherwise use the recorded video segments described in Engagement Strategies.

### 🖼️ Demos

All demos reference the userguide files in the `session-delivery-resources/` folder. For each demo use the referenced minimal userguide for talking points and follow a short 1–2 step demo flow. If a demo is fragile or long-running, prefer a recorded segment.

| Demo | Description |
|---|---|
| [Architecture / Zava Overview](/session-delivery-resources/02-Zava-Overview/brk447-02-Zava%20Overview-en-US-01-minimal.md) | High-level architecture and key components — keep to the big picture. |
| [Copilot Features in Visual Studio](/session-delivery-resources/03-VS2022-and-GHCP-Overview/brk447-03-VS2022%20and%20GHCP%20Overview-en-US-01-minimal.md) | Ask vs Agent modes, completions, and quick edits inside Visual Studio. |
| [AI Search & Unit Testing](/session-delivery-resources/04-Add-single-unit-Test-for-AI-Search/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-01-minimal.md) | TDD flow with Copilot scaffolding unit tests and validating results. |
| [MCP Servers](/session-delivery-resources/05-add-mcp-servers/brk447-05%20add%20mcp%20servers-en-US-01-minimal.md) | Brief explanation and one quick verification of a configured MCP tool. |
| [Querying Documentation (MCP)](/session-delivery-resources/06-query-mcp-ms-learn/brk447-06-query%20mcp%20ms%20learn-en-US-01-minimal.md) | Show how the Agent can consult Microsoft Learn or other docs to suggest code changes. |
| [Issue-Driven Development with Agent](/session-delivery-resources/07-Implement-unit-tests-using-GH-Issue/brk447-07-Implement%20unit%20tests%20using%20GH%20Issue-en-US-01-minimal.md) | Show the issue briefly and the Agent's plan/patch workflow (use a short prerecorded clip if long). |
| [Image-Based UI Updates](/session-delivery-resources/08-update-ui-using-agent-based-on-images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-01-minimal.md) | Show before/after images and the Agent's suggested UI changes (use recorded clip if applying changes is time-consuming). |
| [Implement Payment Service](/session-delivery-resources/09-coding-agent-implement-payment-PRD/brk447-09-coding-agent-implement-payment-PRD-en-US-01-minimal.md) | Show how Coding Agent can implement a full Payment service (use recorded clip if applying changes is time-consuming). |

For each demo keep live interactions short and reserve complex changes for recorded segments.

## Engagement Strategies

- For demos that are long-running or brittle to run live, use recorded videos with voice-over rather than attempting a live run.
- Keep live demos short (30–90 seconds) and reserve complex changes for recorded segments.
- Invite audience questions during short pauses between demos and use the final Q&A for deeper discussion.

## Presenter Notes and Quick Tips

- Keep the session focused on practical demonstrations and avoid deep infrastructure tasks during the live session.
- If you must show environment setup, show only verification steps during the session and leave full setup to the pre-session guide.
- Use the referenced userguides for copy/paste snippets and backup clips.

## Quick Reference Links

### Essential Documentation

- [Initial Setup Guide](01-InitialSetup.md)
- [PRD Template](04-PRD_Add_Payment_Mock_Server.md)
- [Issue Creation Template](02-Create_Issue_for_unit_tests.md)
