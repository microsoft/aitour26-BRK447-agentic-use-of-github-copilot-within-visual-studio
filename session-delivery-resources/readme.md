## How to deliver this session

🥇 Thanks for delivering this session!

Prior to delivering the workshop please:

1. Read this document and all included resources in their entirety.
2. Watch the recorded setup and demo videos referenced in the resources.
3. Ask questions of the content leads if anything is unclear — they're available to help.

## 📁 File Summary

| Resources | Links | Description |
|---|---|---|
| Workshop Slide Deck | [Presentation](https://aka.ms/) | Presentation slides for this workshop with presenter notes and embedded demo video |
| Session Delivery Deck | [Deck](https://aka.ms/) | The session delivery slides |
| More Files | [Some More Files](https://aka.ms/) | More File Descriptions |

## 🚀 Get Started

The workshop mixes short live demos (30–90s) with recorded segments for longer or fragile flows. Follow the step-by-step user guides in the `docs/` folder for setup and demo scripts.

### 🕐 Timing

| Time | Description |
|---:|---|
| 0:00 - 5:00 | Intro and overview |
| 5:00 - 70:00 | Session Steps |
| 70:00 - 75:00 | Wrap up and Q&A |

> Timing table left intentionally as-is per instructions (do not fill beyond this placeholder).

### 🏋️ Preparation

These items are required as presenter pre-work and should NOT be listed as session objectives.

Essential Pre-Setup Requirements:

- Review the Initial Setup guide and recorded setup video: `docs/brk447-01-Initial%20Setup-gen-01/brk447-01-Initial%20Setup-en-US-02-userguide.md` (include the recorded setup video in the same folder as pre-setup material)
- Set up Azure AI services and local development environment
- Run coding agent actions before the event

Prerequisites for Attendees and Presenter:

- `.NET SDK` (repository targets .NET 9)
- `Visual Studio 2022`
- Basic level access to and familiarity with `GitHub Copilot` (sign-in + extension installed)

Optional pre-deploys (presenter choice): pre-deploy AI resources or collect connection strings if you plan to demo live services — otherwise use the recorded video segments described in Engagement Strategies.

### �️ Demos

All demos reference the userguide files in the `docs/` folder. For each demo use the referenced minimal userguide for talking points and follow a short 1–2 step demo flow. If a demo is fragile or long-running, prefer a recorded segment.

Demo flow (high level):

| Demo | Description | Minimal Guide |
|---|---|---|
| Introduction & Agenda | Brief session welcome and agenda. | N/A |
| Architecture / Zava Overview | High-level architecture and key components — keep to the big picture. | `docs/brk447-02-Zava Overview-gen-01/brk447-02-Zava Overview-en-US-01-minimal.md` |
| Copilot Features in Visual Studio | Ask vs Agent modes, completions, and quick edits inside Visual Studio. | `docs/brk447-03-VS2022 and GHCP Overview-gen-01/brk447-03-VS2022 and GHCP Overview-en-US-01-minimal.md` |
| AI Search & Unit Testing | TDD flow with Copilot scaffolding unit tests and validating results. | `docs/brk447-04 Add single unit Test for AI Search-gen-01/brk447-04 Add single unit Test for AI Search-en-US-01-minimal.md` |
| MCP Servers | Brief explanation and one quick verification of a configured MCP tool. | `docs/brk447-05 add mcp servers-gen-01/brk447-05 add mcp servers-en-US-01-minimal.md` |
| Querying Documentation (MCP) | Show how the Agent can consult Microsoft Learn or other docs to suggest code changes. | `docs/brk447-06-query mcp ms learn-gen-01/brk447-06-query mcp ms learn-en-US-01-minimal.md` |
| Issue-Driven Development with Agent | Show the issue briefly and the Agent's plan/patch workflow (use a short prerecorded clip if long). | `docs/brk447-07-Implement unit tests using GH Issue-gen-01/brk447-07-Implement unit tests using GH Issue-en-US-01-minimal.md` |
| Image-Based UI Updates | Show before/after images and the Agent's suggested UI changes (use recorded clip if applying changes is time-consuming). | `docs/brk447-08-update ui using agent based on images-gen-01/brk447-08-update ui using agent based on images-en-US-01-minimal.md` |

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

- Initial Setup Guide: `docs/01-InitialSetup.md`
- PRD Template: `docs/04-PRD_Add_Payment_Mock_Server.md`
- Issue Creation Template: `docs/02-Create_Issue_for_unit_tests.md`
