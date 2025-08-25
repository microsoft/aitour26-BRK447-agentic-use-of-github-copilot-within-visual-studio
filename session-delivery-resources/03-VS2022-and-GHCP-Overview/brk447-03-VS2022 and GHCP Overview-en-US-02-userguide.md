# Video: [brk447-03-VS2022 and GHCP Overview.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:02:43

# GitHub Copilot in Visual Studio (preview) — User Manual

Version: Based on demo video (total duration 00:02:39.720)  
This manual describes how to use the GitHub Copilot integration inside Visual Studio (preview), covering inline suggestions, the next-edit feature, usage/plan visibility, Copilot interaction modes, model selection, and automated code/infrastructure edits.

---

## Overview
(00:00:01.800 — 00:00:12.960)

This integration embeds GitHub Copilot directly into Visual Studio. The demo uses a preview build; features and UI may differ in future releases. Copilot offers inline code suggestions, a “next-edit” multi-line suggestion feature, an Ask mode for queries, and an Agent mode for interactive assistance. You can view and change which models are used (including selecting local models), check usage and plan consumption, and allow Copilot to make automated edits to code and infrastructure files (e.g., C# and Bicep).

Important notes:
- This manual assumes the Copilot extension is already installed and enabled in Visual Studio.
- Because this was demonstrated in a preview build, expect small UI/behavior changes.

---

## Step-by-step instructions

The following steps are grouped by common tasks shown in the demo. Each step includes a reference timestamp to the demo.

### 1) Open Visual Studio with Copilot enabled
(00:00:01.800 — 00:00:12.960)

1. Launch Visual Studio.
2. Ensure the GitHub Copilot extension is installed and enabled:
   - Look for Copilot UI elements or a preview indicator in the IDE.
3. If you are in a preview build, note any preview indicator and be prepared for behavior differences.

Tip: If Copilot is not visible, check Extensions > Manage Extensions and confirm “GitHub Copilot” is installed and enabled.

---

### 2) Use inline suggestions and the “next-edit” feature
(00:00:12.960 — 00:00:23.680)

1. Open a code file (e.g., C#) in the editor.
2. Start typing as you normally would.
   - Inline suggestions will appear as ghosted text directly in the editor.
3. To accept an inline suggestion:
   - Use the usual accept key (often Tab or your configured accept shortcut), or click the suggestion.
4. To request a more substantial / multi-line change:
   - Trigger Copilot’s “next-edit” suggestion (UI element labeled “next-edit”).
   - Review the multi-line suggestion shown in the editor.
   - Accept the suggestion to apply the change.

Tip: Use the arrow keys or suggestion UI to cycle alternative suggestions before accepting.

Warning: Always review suggestions for correctness and security (especially for business logic or secrets).

---

### 3) Check usage / plan consumption
(00:00:23.680 — 00:00:33.680)

1. Open Copilot’s options or usage panel from the Copilot menu or toolbar.
2. Look for the plan usage indicator (e.g., “28% of my Pro plan”).
3. Monitor consumption for premium requests to avoid unexpected limits.

Tip: Regularly check usage when running larger model requests or multiple premium features in the same session.

---

### 4) Understand the solution architecture context
(00:00:33.680 — 00:00:46.616)

1. Open your Solution Explorer.
2. Identify key components Copilot may interact with:
   - Orchestrators
   - Backend services
   - AI frontend code
   - Model configuration/definition files
3. When asking Copilot to make changes, narrow the scope to the relevant files to reduce unintended edits.

Tip: Keep architecture documentation or README files accessible so Copilot (and you) have clear context for changes.

---

### 5) Switch between Ask mode and Agent mode
(00:00:46.616 — 00:00:55.720)

1. Open the Copilot interaction pane.
2. Choose the interaction mode:
   - Ask mode: for one-off queries and factual questions about code or configuration.
   - Agent mode: for an interactive, side-by-side coding assistant that can carry a longer conversational context.
3. Use Ask mode to quickly query model usage or small tasks.
4. Use Agent mode when you need a persistent assistant to guide edits and multi-step changes.

Tip: Use Agent mode for larger refactors or multi-file edits where Copilot needs to remember earlier context.

---

### 6) Query and select models
(00:00:55.720 — 00:01:12.440)

1. In the Copilot pane, ask which OpenAI model the solution currently uses (type a question in Ask mode or Agent mode).
2. Open the model selector / dropdown in the Copilot UI.
3. Select a model from the available list (e.g., GPT-5 if available).
4. Confirm the selection so subsequent requests route to the chosen model.

Tip: Review model-specific documentation for cost and capability differences before switching (e.g., GPT-4o-mini, GPT-5, embedding models).

---

### 7) Review Copilot’s reported model usage
(00:01:54.560 — 00:02:11.680)

1. After asking about models, read Copilot’s response in the response pane.
   - It may report that the app host defines a certain chat model (e.g., GPT-4o-mini) and specific embedding models.
2. Note where embeddings and chat models are used in the stack (backend, frontend, model configs).
3. Verify the information by opening configuration files referenced by Copilot (e.g., app settings or infrastructure files).

Tip: Use Copilot’s response as a guide — always cross-check the actual configuration files in your repo.

---

### 8) Ask Copilot to prepare an upgrade plan or switch to local models
(00:02:13.520 — 00:02:39.720)

Follow these safety-first steps when asking Copilot to make architectural or infrastructure changes:

1. In Ask or Agent mode, request the change you want:
   - Example queries: “Create a plan to upgrade to GPT-5” or “Switch to local models.”
2. Ask Copilot to outline required file edits and steps first, before applying changes.
3. Review the proposed plan carefully:
   - Which C# files will change?
   - Which infrastructure (Bicep) files will change?
   - Are there additional deployment or configuration steps?
4. When ready to implement, allow Copilot to modify files (if the UI supports automated edits):
   - Accept each file change or enable the assisted edit flow.
   - Carefully review diffs for each modified C# and Bicep file before saving or committing.
5. After edits:
   - Run your unit/integration tests.
   - Validate infra templates (Bicep) using your standard validation/linting tools.
   - Deploy to a safe environment (staging) first.

Warnings:
- Always back up or commit current working branch before allowing automated edits.
- For infrastructure files (Bicep), validate changes to avoid accidental resource changes or costs.
- For model upgrades, verify cost/usage implications and compatibility with existing code.

Tip: Use a feature branch and pull request workflow so changes can be reviewed by peers.

---

## Tips & Warnings (summary of practical safeguards)
- Backup or create a branch before accepting automated edits.
- Review every Copilot suggestion and diff for logic, security, and compliance.
- Monitor plan usage to avoid unexpected charges (check usage panel regularly).
- Validate infrastructure templates (Bicep) with your normal tools before deploying.
- When switching to local models, ensure local model hosting, hardware, and licensing are in place.

---

Timestamps quick reference
- Introduction & preview notice: 00:00:01.800 — 00:00:12.960  
- Inline suggestions & next-edit: 00:00:12.960 — 00:00:23.680  
- Usage/plan consumption: 00:00:23.680 — 00:00:33.680  
- Solution architecture context: 00:00:33.680 — 00:00:46.616  
- Ask mode vs Agent mode: 00:00:46.616 — 00:00:55.720  
- Model selection (choose GPT-5): 00:00:55.720 — 00:01:12.440  
- Copilot model usage details: 00:01:54.560 — 00:02:11.680  
- Upgrade plan & switching to local models; automated file edits: 00:02:13.520 — 00:02:39.720

---

End of manual.