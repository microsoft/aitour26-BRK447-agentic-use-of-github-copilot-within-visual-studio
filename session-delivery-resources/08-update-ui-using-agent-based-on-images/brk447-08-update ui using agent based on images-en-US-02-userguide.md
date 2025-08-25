# Video: [brk447-08-update ui using agent based on images.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:05:05

# Applying SAVA Brand Styles to a Blazor App with GitHub Copilot / Compiler
A practical user manual that walks through using a multimodal AI agent (GitHub Copilot / Compiler) to apply brand styles and refine the front-end UI of a Blazor web application.

---

## Overview
Duration: 00:00:00 — 00:05:04

This guide shows how to:
- Provide repository style assets (CSS and images) to GitHub Copilot / Compiler.
- Let the agent analyze your Blazor front-end and produce an implementation plan.
- Apply the agent's CSS edits and handle the running app prompts.
- Use screenshots and multimodal prompts for iterative visual refinement.
- Test product pages, product cards, and cart interactions after styling changes.

Target outcome: Replace the default color scheme with the SAVA brand style and iteratively improve readability and layout.

Referenced timestamps are included so you can correlate steps with the original demonstration.

---

## Step-by-step instructions

### 1 — Prepare and confirm the goal (00:00:00 — 00:00:25)
1. Open your Blazor project in your IDE or code host (the demo uses a repository containing SAVA style assets).
2. Confirm the objective: replace the current/default colors with the SAVA brand style and improve UI styling across the app.
3. Locate the style assets in the repository:
   - CSS files (commonly `app.css` or similar)
   - Reference images or style guides (brand color swatches, logos)

Tip: Keep an inventory of files you plan to modify (e.g., `wwwroot/css/app.css`, any theme or shared style files).

---

### 2 — Copy style assets into GitHub Copilot / Compiler context (00:00:25 — 00:01:04)
1. Open the GitHub Copilot / Compiler interface in your browser.
2. Copy the content of your style file(s) (for example, `app.css`) from the repository.
3. Paste the CSS content into the Copilot / Compiler input context.
4. Also paste any reference images (brand guide screenshots, logos) into the same context so the agent can use them as visual input.
5. In the same input, add a clear prompt describing the desired outcome. Example prompt:
   - "Apply the SAVA brand colors and style to this Blazor app. Use the pasted CSS and reference images. Improve readability and ensure product cards and cart visuals match the brand."

Tip: Provide concise context about which pages/components to update (e.g., `Product.razor`, shared layout files).

Warning: Make sure you are pasting only non-sensitive assets into the AI interface.

---

### 3 — Let Copilot scan the project and produce a plan (00:01:09 — 00:02:09)
1. Allow the agent time to scan the pasted files and any repository context it can access.
2. Review Copilot’s analysis — it will typically:
   - Identify the front-end framework (Blazor).
   - Locate relevant CSS and component files (`app.css`, `.razor` components).
   - Propose a step-by-step plan for applying styles (e.g., update variables, adjust colors, modify component classes).
3. Read the plan and confirm you want Copilot to apply the changes.

Tip: If the plan lists many large changes, consider requesting smaller, incremental edits (e.g., "Start by updating primary/secondary color variables only").

---

### 4 — Accept and apply CSS edits; handle the running app popup (00:02:09 — 00:03:03)
1. Allow Copilot to apply edits to `app.css` and other target files.
2. If the development server is running, you may see a popup: "Stop the running application to apply changes?"
   - Accept the prompt to stop the app so file updates can be applied cleanly.
3. Restart the Blazor application:
   - Run `dotnet run` or use your IDE's run/debug controls.
4. Open the browser and refresh the application to observe changes.

What to expect:
- Immediate style changes may appear, but some colors or contrast might look off (often darkened or low contrast) on the first pass.

Warning: Stopping the running application will interrupt any in-browser development sessions. Save work and commit if necessary before accepting.

---

### 5 — Iterate using screenshots and multimodal prompts (00:03:03 — 00:03:56)
1. If readability or layout issues remain (e.g., dark text on dark background), capture a screenshot of the problematic view.
2. Paste the screenshot into the Copilot / Compiler input area.
3. Provide a clear instruction referencing the screenshot. Example:
   - "Screenshot attached — text contrast on product cards is poor. Please adjust the SAVA palette to improve readability for this component and suggest spacing fixes."
4. Let Copilot analyze the image and implement changes. This may take several minutes.
5. Restart/reload the app to pick up iterative updates, and verify the results in-browser.

Tips:
- Make focused prompts for specific components (e.g., "Fix product card header contrast only").
- Smaller incremental requests lead to faster, more controlled improvements.
- Expect multiple iterations — visual tuning often needs several rounds.

---

### 6 — Review updated UI and test product & cart flows (00:03:56 — 00:05:04)
1. Re-run the application and navigate to the product listing or product detail pages.
2. Inspect product cards for:
   - Contrast and readability of text
   - Card layout and spacing
   - Button visibility (e.g., Add to Cart)
3. Add a product to the cart and review the cart UI:
   - Check item rows, totals, and checkout button visibility
   - Verify styling consistency with SAVA brand colors
4. Note remaining issues (e.g., layout misalignment, spacing) and prepare targeted prompts for Copilot to refine those areas.

Tip: For layout or component issues, include component filenames in your prompt (e.g., `Product.razor`) so Copilot edits the right files.

---

## Helpful tips and warnings
- Tip: Provide both CSS files and reference images — multimodal input yields better visual adjustments.
- Tip: Ask Copilot to make incremental changes (color variables first, then component spacing) to reduce risk.
- Warning: Always save/commit important changes before allowing the agent to stop a running dev server.
- Warning: Automated changes may not be perfect — always review diffs before committing to your repo.
- Tip: Use screenshots for any visual problems — the AI can reason about images and code together.

---

Timestamps referenced:
- Introduction & goal: 00:00:00 — 00:00:25
- Copying assets into Copilot: 00:00:25 — 00:01:04
- Copilot analysis & plan: 00:01:09 — 00:02:09
- Apply edits & running app popup: 00:02:09 — 00:03:03
- Iterative screenshots & prompts: 00:03:03 — 00:03:56
- Review, test product page & cart: 00:03:56 — 00:05:04

This manual condenses the demonstrated process into a repeatable workflow so you can apply brand styles and iteratively refine a Blazor front-end with the help of GitHub Copilot / Compiler.