# Video: [brk447-03-VS2022 and GHCP Overview.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:02:43

# GitHub Copilot in Visual Studio (Preview) — User Manual

Version: Video walkthrough (00:00:01.800 — 00:02:39.720)  
This manual guides you through the GitHub Copilot integration demonstrated in the preview Visual Studio build: enabling Copilot, using inline suggestions and next-edit, checking usage, switching interaction modes, selecting models, and allowing Copilot to perform automated code and infrastructure edits.

---

## Overview

This preview integration brings GitHub Copilot directly into Visual Studio and offers:

- Inline code suggestions while you type and a "next-edit" feature for multi-line changes. (00:00:12.960 — 00:00:23.680)  
- A usage and plan panel showing consumption of premium requests. (00:00:23.680 — 00:00:33.680)  
- Two interaction modes: Ask (single-query) and Agent (interactive assistant). (00:00:46.616 — 00:00:55.720)  
- Model inspection and selection (e.g., GPT-4o-mini, GPT-5) and the ability to ask Copilot which models your solution uses. (00:00:55.720 — 00:01:12.440; 00:01:54.560)  
- Automated updates to project C# and Bicep files when requested (e.g., upgrading models or switching to local models). (00:02:13.520 — 00:02:39.720)

Snapshot: Visual Studio with Copilot integration visible (preview indicator).  
![Copilot integration in Visual Studio (00:00:01.800)](./snapshot-00-00-01-800.png)

---

## Step-by-step instructions

The following sections describe the most common workflows demonstrated in the video. Each step includes short tips and warnings as applicable.

### 1. Open Visual Studio with Copilot enabled (00:00:01.800 — 00:00:12.960)

1. Launch Visual Studio.
2. Ensure the GitHub Copilot extension/integration is installed and enabled.
3. Note any preview indicator; behavior may change in preview builds.

Tip: If you don't see Copilot, confirm the extension is installed and you are signed into your GitHub account.

Snapshot: Copilot integration visible in the Visual Studio UI.  
![Copilot visible in Visual Studio (00:00:01.800)](./snapshot-00-00-01-800.png)

---

### 2. Use inline suggestions while coding (00:00:12.960 — 00:00:23.680)

1. Open a code file (e.g., C#).
2. Begin typing a function or comment describing intent.
3. Watch for inline suggestions that appear as gray text ahead of your cursor.
4. Accept an inline suggestion by:
   - Pressing Tab (or the configured accept key), or
   - Clicking the inline suggestion with your mouse, or
   - Using any Accept action shown in the UI.

Tip: Inline suggestions are useful for single-line completions and small continuations.

Snapshot: Inline suggestion UI appearing as you type.  
![Inline suggestion example (00:00:12.960)](./snapshot-00-00-12-960.png)

Warning: Preview behavior and keyboard shortcuts may differ from release versions.

---

### 3. Use the "Next-edit" feature for multi-line suggestions (00:00:12.960 — 00:00:23.680)

1. When editing a method or making a substantial change, trigger a "next-edit" suggestion by continuing to type or invoking Copilot's suggestion command.
2. A multi-line suggestion will appear for the larger change.
3. Review the suggested multi-line edit carefully.
4. Accept the "next-edit" to apply the multi-line change to your file.

Tip: Use this to accept larger logic changes quickly, but always review for correctness and style.

Snapshot: Next-edit suggestion UI with multi-line content.  
![Next-edit suggestion example (00:00:12.960)](./snapshot-00-00-12-960.png)

---

### 4. Check usage and plan consumption (00:00:23.680 — 00:00:33.680)

1. Open the Copilot options or usage panel from the Copilot pane or the Visual Studio menus.
2. Locate the plan usage indicator (e.g., "28% of my Pro plan").
3. Monitor consumption for premium requests or quota-sensitive operations.

Tip: Track usage before running large model queries or heavy automated edits to avoid exceeding your plan.

Snapshot: Usage/Consumption panel showing plan usage (28%).  
![Copilot Usage panel (00:00:23.680)](./snapshot-00-00-23-680.png)

Warning: Model upgrades or premium requests may increase consumption.

---

### 5. Inspect solution architecture in Visual Studio (00:00:33.680 — 00:00:46.616)

1. Open the Solution Explorer and review project structure (orchestrators, backend, AI frontend, model definitions).
2. Identify which components Copilot might modify (C# orchestrators/backend, frontend code, Bicep infrastructure, model config).
3. Keep the architecture context in mind when accepting automated changes.

Tip: Knowing which files are part of the AI stack helps you make targeted requests (e.g., change model in backend config).

Snapshot: Solution architecture overview (project files visible).  
![Solution/project explorer view (00:00:33.680)](./snapshot-00-00-33-680.png)

---

### 6. Switch between Ask mode and Agent mode (00:00:46.616 — 00:00:55.720)

1. Open the Copilot pane.
2. Select Ask mode for single questions or quick lookups.
   - Example: "Which OpenAI model are we using?"
3. Select Agent (interactive assistant) mode to run a side-by-side interactive session with Copilot for iterative tasks or guided edits.

Tip: Use Ask mode for short queries (e.g., "What model is configured?") and Agent mode when you want Copilot to propose and apply code changes.

Snapshot: Ask mode and Agent mode UI options.  
![Ask vs Agent mode selector (00:00:46.616)](./snapshot-00-00-46-616.png)

---

### 7. Query and select models (00:00:55.720 — 00:01:12.440)

1. Ask Copilot: "Which OpenAI model is this solution using?" or similar in Ask mode.
2. Review Copilot's response showing configured models.
3. To change the model, open the model selector/dropdown in the Copilot pane.
4. Choose the target model (e.g., GPT-5) from the available list.

Tip: When switching models, note any differences in cost or behavior (e.g., GPT-5 vs GPT-4o-mini).

Snapshot: Model selector dropdown with GPT-5 chosen.  
![Model selector with GPT-5 (00:00:55.720)](./snapshot-00-00-55-720.png)

---

### 8. Review Copilot's reported model configuration (00:01:54.560 — 00:02:11.680)

1. After asking about models, read Copilot's reply carefully; it may report:
   - App host defines GPT-4o-mini and certain embedding models.
   - Backend uses embeddings and chat models.
2. Use this information to determine where model changes are needed (app host, backend, embedding config).

Tip: Capture Copilot's response or copy it into documentation for future reference.

Snapshot: Copilot response pane with model details.  
![Copilot response listing models (00:01:54.560)](./snapshot-00-01-54-560.png)

---

### 9. Ask Copilot to propose and apply upgrades or switch to local models (00:02:13.520 — 00:02:39.720)

1. In Agent mode, ask Copilot to "create a plan to upgrade to GPT-5" or "switch to local models".
2. Review the proposed plan and the list of files Copilot will modify (often C# and Bicep).
3. Allow Copilot to perform the automated edits:
   - It will modify code files (e.g., C#) and infrastructure files (e.g., Bicep) to point to the new model or local runtime.
4. Carefully review each change in your source control diff before committing.

Tip: Use a feature branch and run tests after Copilot performs edits. For infrastructure changes, validate Bicep templates locally or in a staging environment.

Warning:
- Automated infrastructure changes can be impactful. Always review Bicep edits and understand the deployment implications.
- Model upgrades may affect cost and runtime behavior; validate in a safe environment first.

Snapshot: Copilot preparing or showing automated edits for C# and Bicep files.  
![Copilot automated file edits prompt (00:02:13.520)](./snapshot-00-02-13-520.png)

---

### 10. Confirm, test, and commit changes

1. Inspect all modified files in the IDE's diff view.
2. Run unit/integration tests locally to ensure no regressions.
3. If Bicep/infrastructure changed, do a dry-run deployment or validation.
4. Commit changes to a branch and create a pull request for review.

Tip: Keep a rollback plan for infrastructure changes and track any quota or billing impacts when changing models.

---

## Snapshots/images used in this manual

The images below are referenced inline in the steps above. Use the dedicated Snapshots list at the end to capture frames.

- Copilot integration in Visual Studio (preview) — 00:00:01.800  
  ![Copilot integration in Visual Studio (00:00:01.800)](./snapshot-00-00-01-800.png)

- Inline suggestion and Next-edit examples — 00:00:12.960  
  ![Inline suggestion example (00:00:12.960)](./snapshot-00-00-12-960.png)

- Usage/Consumption panel (e.g., 28% of Pro plan) — 00:00:23.680  
  ![Copilot Usage panel (00:00:23.680)](./snapshot-00-00-23-680.png)

- Solution/project explorer showing orchestrators/backend/frontend — 00:00:33.680  
  ![Solution/project explorer view (00:00:33.680)](./snapshot-00-00-33-680.png)

- Ask mode vs Agent mode selector — 00:00:46.616  
  ![Ask vs Agent mode selector (00:00:46.616)](./snapshot-00-00-46-616.png)

- Model selector with GPT-5 chosen — 00:00:55.720  
  ![Model selector with GPT-5 (00:00:55.720)](./snapshot-00-00-55-720.png)

- Copilot response listing configured models — 00:01:54.560  
  ![Copilot response listing models (00:01:54.560)](./snapshot-00-01-54-560.png)

- Copilot preparing automated edits to C# and Bicep files — 00:02:13.520  
  ![Copilot automated file edits prompt (00:02:13.520)](./snapshot-00-02-13-520.png)

---

## Snapshots

[00:00:01.800]  
[00:00:12.960]  
[00:00:23.680]  
[00:00:33.680]  
[00:00:46.616]  
[00:00:55.720]  
[00:01:12.440]  
[00:01:54.560]  
[00:02:13.520]