# BRK-447 Presenter Guide: Real-World AI Development with Visual Studio and GitHub Copilot

This concise presenter guide is optimized for a technical presenter delivering session BRK-447. It focuses on live/demonstration flow, essential prerequisites, and clear pre-session preparation.

---

## Overview

**Session Title**: BRK-447 - Real-World AI Development with Visual Studio and GitHub Copilot  
**Duration**: 40–45 minutes  
**Target Audience**: Developers, DevOps engineers, and technical architects

### Session Objectives

By the end of this session, attendees will be able to:

- Use GitHub Copilot effectively inside Visual Studio to accelerate development
- Leverage MCP servers to augment Copilot with external documentation and tools
- Use Copilot Agents to automate issue-driven code changes and UI updates

---

## Pre-Session / Presenter Pre-Setup

These items are required as presenter pre-work and should NOT be listed as session objectives.

**Essential Pre-Setup Requirements:**

- Review the Initial Setup guide and recorded setup video: `docs/brk447-01-Initial%20Setup-gen-01/brk447-01-Initial%20Setup-en-US-02-userguide.md` (include the recorded setup video in the same folder as pre-setup material)
- Set up Azure AI services and local development environment
- Run coding agent actions before the event

**Prerequisites for Attendees and Presenter:**

- `.NET SDK` (repository targets .NET 9)
- `Visual Studio 2022`
- `Basic level access to and familiarity with GitHub Copilot` (sign-in + extension installed)

Optional pre-deploys (presenter choice): pre-deploy AI resources or collect connection strings if you plan to demo live services — otherwise use the recorded video segments described in Engagement Strategies.

---

## Demo Flow

All demos below reference the userguide files in the `docs/` folder.

| Demo | Description | Minimal Guide |
|---|---|---|
| Introduction & Agenda | Brief session welcome and agenda. | N/A |
| Architecture / Zava Overview | High-level architecture and key components — keep to the big picture. | [`docs/brk447-02-Zava Overview-gen-01/brk447-02-Zava Overview-en-US-01-minimal.md`](docs/brk447-02-Zava%20Overview-gen-01/brk447-02-Zava%20Overview-en-US-01-minimal.md) |
| Copilot Features in Visual Studio | Ask vs Agent modes, completions, and quick edits inside Visual Studio. | [`docs/brk447-03-VS2022 and GHCP Overview-gen-01/brk447-03-VS2022 and GHCP Overview-en-US-01-minimal.md`](docs/brk447-03-VS2022%20and%20GHCP%20Overview-gen-01/brk447-03-VS2022%20and%20GHCP%20Overview-en-US-01-minimal.md) |
| AI Search & Unit Testing | TDD flow with Copilot scaffolding unit tests and validating results. | [`docs/brk447-04 Add single unit Test for AI Search-gen-01/brk447-04 Add single unit Test for AI Search-en-US-01-minimal.md`](docs/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-gen-01/brk447-04%20Add%20single%20unit%20Test%20for%20AI%20Search-en-US-01-minimal.md) |
| MCP Servers | Brief explanation and one quick verification of a configured MCP tool. | [`docs/brk447-05 add mcp servers-gen-01/brk447-05 add mcp servers-en-US-01-minimal.md`](docs/brk447-05%20add%20mcp%20servers-gen-01/brk447-05%20add%20mcp%20servers-en-US-01-minimal.md) |
| Querying Documentation (MCP) | Show how the Agent can consult Microsoft Learn or other docs to suggest code changes. | [`docs/brk447-06-query mcp ms learn-gen-01/brk447-06-query mcp ms learn-en-US-01-minimal.md`](docs/brk447-06-query%20mcp%20ms%20learn-gen-01/brk447-06-query%20mcp%20ms%20learn-en-US-01-minimal.md) |
| Issue-Driven Development with Agent | Show the issue briefly and the Agent's plan/patch workflow (use a short prerecorded clip if long). | [`docs/brk447-07-Implement unit tests using GH Issue-gen-01/brk447-07-Implement unit tests using GH Issue-en-US-01-minimal.md`](docs/brk447-07-Implement%20unit%20tests%20using%20GH%20Issue-gen-01/brk447-07-Implement%20unit%20tests%20using%20GH%20Issue-en-US-01-minimal.md) |
| Image-Based UI Updates | Show before/after images and the Agent's suggested UI changes (use recorded clip if applying changes is time-consuming). | [`docs/brk447-08-update ui using agent based on images-gen-01/brk447-08-update ui using agent based on images-en-US-01-minimal.md`](docs/brk447-08-update%20ui%20using%20agent%20based%20on%20images-gen-01/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-01-minimal.md) |

For each demo, use the referenced minimal userguide for talking points and follow a short 1–2 step demo flow. If a demo is fragile or long-running, follow Engagement Strategies below and play a recorded segment.

---

## Engagement Strategies

- **For demos that are long-running or brittle to run live, the presenter must use recorded videos with voice-over rather than attempting a live run.** Long demos must be demonstrated using pre-recorded video and a voice-over narration.
- Keep live demos short (30–90 seconds) and reserve complex changes for recorded segments.
- Invite audience questions during short pauses between demos and use the final Q&A for deeper discussion.

---

## Presenter Notes and Quick Tips

- Keep the session focused on practical demonstrations and avoid deep infrastructure tasks during the live session.
- If you must show environment setup, show only verification steps during the session and leave full setup to the pre-session guide.
- Use the referenced userguides for copy/paste snippets and backup clips.

---

## Quick Reference Links

### Essential Documentation

- Initial Setup Guide: `docs/01-InitialSetup.md`
- PRD Template: `docs/04-PRD_Add_Payment_Mock_Server.md`
- Issue Creation Template: `docs/02-Create_Issue_for_unit_tests.md`
