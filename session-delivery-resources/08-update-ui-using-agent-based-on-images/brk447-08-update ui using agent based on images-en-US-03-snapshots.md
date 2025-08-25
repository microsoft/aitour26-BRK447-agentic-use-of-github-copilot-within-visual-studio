# Video: [brk447-08-update ui using agent based on images.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:05:05

# Applying SAVA Brand Styles to a Blazor App using GitHub Copilot / Compiler
A concise user manual that walks you step-by-step through using a multimodal AI agent (GitHub Copilot / Compiler) to apply brand CSS and iterate on UI styling in a Blazor web application.

## Overview
(00:00:00.080 – 00:00:25.120)

This guide shows how to take SAVA brand style assets from a repository, feed them into GitHub Copilot / Compiler (including images), let the agent analyze your Blazor project, and iteratively apply and refine CSS changes. The workflow demonstrates using Copilot to:
- scan project files,
- update app.css and component styles,
- handle the "stop the running application" prompt,
- iterate with screenshots and further prompts,
- test product page and cart UI components.

Snapshot: ![Intro UI — 00:00:00.080] (Snapshot: ![Snapshot at 00:00:00.080](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-00-00-080.png))

---

## Step-by-step instructions

Follow each phase in order. Where relevant, a reference timestamp is provided.

### Phase 1 — Prepare style assets and inputs for Copilot
(00:00:25.120 – 00:01:04.200)

1. Locate the SAVA style files in your repository (CSS files, variables, and reference images).
   - Typical files: app.css or site.css, brand color tokens, logo and style-guide images.
2. Open GitHub Copilot / Compiler in your development environment (the web or IDE plugin).
3. Copy the style files and reference images (or file contents) into the Copilot / Compiler context:
   - Paste the CSS file contents or upload the files.
   - Paste or upload reference images (brand style guide screenshots).
4. Prepare a clear multimodal prompt describing the goal. Example:
   - "Apply the SAVA brand styles to this Blazor front-end. Use the pasted app.css, color tokens, and images. Update component styles (.razor and CSS) so the app uses the SAVA primary/secondary colors, improves contrast, and matches brand spacing."
5. Submit the prompt and allow Copilot to read the project context.

Tip: Keep the prompt concise and explicit about which files to change (e.g., app.css, product.razor, shared layout).

Snapshot: ![Pasting assets into Copilot — 00:00:25.120] (Snapshot: ![Snapshot at 00:00:25.120](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-00-25-120.png))

---

### Phase 2 — Let Copilot analyze the repository and plan changes
(00:01:09.380 – 00:02:09.720)

1. Allow Copilot/Compiler to scan repository files (it will read CSS, .razor component files, and layout files).
2. Review the generated implementation plan. Typical plan items:
   - Update color variables in app.css
   - Replace default color classes with brand classes
   - Adjust product card styling (padding, border, background)
   - Update button styles and hover states
3. Confirm or request adjustments to the plan if needed.

Tip: If Copilot suggests many changes, ask it to produce a staged plan (apply CSS variables first, then component adjustments) to make iteration easier.

Snapshot: ![Copilot analysis and plan — 00:01:09.380] (Snapshot: ![Snapshot at 00:01:09.380](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-01-09-380.png))

---

### Phase 3 — Apply edits and handle the running-app popup
(00:02:09.720 – 00:03:03.040)

1. Allow Copilot to apply edits to app.css and other targeted files.
2. If your Blazor app is running, a popup will ask whether to stop the running application so file changes can be applied.
   - Confirm/accept the prompt to stop the running application.
   - Warning: Stopping the app will interrupt any active sessions; ensure you saved work.
3. Restart the Blazor application (run/debug).
4. Refresh the browser to pick up the new CSS.
   - Observe the UI. Some changes may look off at first (e.g., dark backgrounds with dark text).

Tip: Back up app.css or commit to a branch before automated edits so you can revert quickly.

Snapshot: ![Stop running app popup and restart — 00:02:09.720] (Snapshot: ![Snapshot at 00:02:09.720](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-02-09-720.png))

---

### Phase 4 — Iterate via screenshot-driven prompts
(00:03:03.040 – 00:03:56.709)

1. If readability or layout issues appear (example: low contrast or dark text on dark background), take a screenshot of the affected UI state.
   - Capture the whole viewport or the specific component (product card, navbar, cart).
2. Paste the screenshot into the Copilot/Compiler input with a focused instruction. Example:
   - "Screenshot attached: product listing view — text is not readable on the current card background. Please adjust colors and spacing to match SAVA brand and improve contrast for readability. Limit changes to app.css and product.razor."
3. Submit and allow Copilot time to analyze the screenshot and implement changes (this can take several minutes).
4. Re-run/reload the app to view the updated styles.
5. Repeat: take new screenshots for subsequent issues and ask for incremental fixes.

Tip: Make single-purpose prompts (contrast fix, spacing fix, button color) rather than broad requests to keep changes small and reviewable.

Snapshot: ![Screenshot inserted for refinement — 00:03:03.040] (Snapshot: ![Snapshot at 00:03:03.040](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-03-03-040.png))

Warning: Automated changes might update multiple files. Review diffs before committing.

---

### Phase 5 — Review updated UI and test interactive components
(00:03:56.709 – 00:05:04.920)

1. Re-run the Blazor application to ensure latest edits are applied.
2. Inspect the product page and product cards:
   - Verify background colors, text contrast, padding, and alignment match SAVA branding.
3. Test cart functionality:
   - Add sample products to the cart to confirm add-to-cart visuals, buttons, and cart layout respond correctly.
4. Note remaining issues (e.g., card layout misalignment, cart visual tweaks) and prepare focused Copilot prompts for them.
   - Example prompt: "Adjust product card layout so cards have consistent spacing and product title wraps correctly on smaller viewports. Only edit product.css/product.razor."
5. Iterate until the visual state meets the brand guidelines.

Tip: Test across viewports (desktop and mobile) to ensure responsive styles are correct.

Snapshot: ![Updated UI & product cards — 00:03:56.709] (Snapshot: ![Snapshot at 00:03:56.709](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-03-56-709.png))  
Snapshot: ![Testing cart and product add — 00:05:04.920] (Snapshot: ![Snapshot at 00:05:04.920](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-05-04-920.png))

---

## Tips & Best Practices
- Version control: Always commit or stash changes before letting Copilot/Compiler apply automatic edits.
- Incremental changes: Request small, focused edits so you can review diffs and behavior after each iteration.
- Use multimodal prompts: Include both file contents and screenshots to let Copilot reason about structure and visual output.
- Give Copilot time: Visual analysis and code edits can take several minutes. Avoid interrupting mid-process.
- Review diffs: Inspect all file changes before merging to ensure no unintended modifications.

## Warnings
- Stopping the running Blazor app will interrupt sessions; save work before confirming.
- Automated edits may conflict with custom code; manually verify component logic after styling changes.
- Hot reload may show “disconnected/gray” state; refresh the browser if styles look out of date.

---

## Snapshots
![Snapshot at 00:00:00.080](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-00-00-080.png)  
![Snapshot at 00:00:25.120](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-00-25-120.png)  
![Snapshot at 00:01:09.380](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-01-09-380.png)  
![Snapshot at 00:02:09.720](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-02-09-720.png)  
![Snapshot at 00:03:03.040](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-03-03-040.png)  
![Snapshot at 00:03:56.709](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-03-56-709.png)  
![Snapshot at 00:05:04.920](./images/brk447-08-update%20ui%20using%20agent%20based%20on%20images-en-US-snapshot-00-05-04-920.png)