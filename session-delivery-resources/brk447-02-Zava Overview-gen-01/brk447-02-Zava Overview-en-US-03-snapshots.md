# Video: [brk447-02-Zava Overview.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:00:57

# SAVA Migration — E‑commerce Quick User Manual

This manual documents the flows shown in the recorded session for migrating e‑commerce sites to the new SAVA experience. It explains how to add products to the cart, verify cart contents, investigate search results behavior, and test checkout behavior. Each section includes step‑by‑step instructions and inline snapshots (images) to help you reproduce and validate the same states demonstrated in the video.

- Video duration referenced: 00:00:55.480
- UI referenced throughout: SAVA application

---

## Overview

(00:00:03.720 — 00:00:14.240)

This session demonstrates:

- Migrating e‑commerce functionality into the SAVA application.
- Adding products to a shopping cart from the product listing.
- Checking search result behavior where the "Add to cart" option may be missing.
- Proceeding to checkout from the cart and noting that the cart-clearing behavior is not yet implemented.
- Identifying items for validation and further development (checkout behavior, search-list consistency, locale/localization settings).

Primary UI elements shown:
- Product listing
- Add to cart button
- Cart view / cart count
- Search input and search results
- Proceed to checkout button

Snapshot:  
![SAVA application context — initial view at 00:00:03.720](./snapshot_00_00_03_720.png)

---

## Step-by-step Instructions

The steps below reproduce what was shown in the recording and include validation and task-creation guidance for any missing or unimplemented behaviors.

### A. Add products to the cart (00:00:14.240 — 00:00:30.954)

1. Open the SAVA application and navigate to the product listing page.  
   Snapshot:  
   ![Product listing view at 00:00:14.240](./snapshot_00_00_14_240.png)

2. From the product listing, locate Product A (example: "paint wall").  
   - Tip: Use visible thumbnails or hover details to confirm the exact item.

3. Click the product’s "Add to cart" button.  
   - Expected: The cart item count increments and the item is added to cart.

4. Find Product B (example: "good stain") in the listing and click its "Add to cart" button.  
   - Expected: Cart count should further increment.

5. Open the cart (click the cart icon or cart link).  
   - Verify the cart shows 2 items (Product A and Product B).  
   Snapshot:  
   ![Cart with 2 items visible at 00:00:30.954](./snapshot_00_00_30_954.png)

Tips and Warnings:
- If the cart count does not update immediately, refresh the cart view and re-check item list.
- If an item looks added but details are missing, capture a screenshot and log a validation task (see section C).

---

### B. Search and verify add‑to‑cart availability (00:00:30.954 — 00:00:38.440)

1. In the SAVA app, enter a product name into the search input (e.g., type "paint wall" and submit).  
   Snapshot:  
   ![Search input/results view at 00:00:30.954](./snapshot_00_00_30_954.png)

2. Inspect the search results list for the expected UI controls:
   - Expected: Each search result item should offer an "Add to cart" control (button or quick action).
   - Observed: The "Add to cart" control is missing in the search results (as shown in the video).

3. If "Add to cart" is missing from search results:
   - Use the product result link to open the product detail page and add from there as a workaround.
   - Create a validation/task item to track this missing quick‑add behavior (see next section).

Tip:
- Users may need to rely on product pages until the quick-add from search is implemented.

---

### C. Create and assign a validation task for missing add‑to‑cart in search (guidance)

When you discover a missing feature (like "Add to cart" missing in search results), follow these steps to create a clear validation task for developers or QA.

Suggested task content and steps:

- Title: "Missing 'Add to cart' in search results — quick‑add not present"
- Description: Short summary of the issue and why it’s a problem (affects conversion and quick purchase flow).
- Steps to reproduce:
  1. Go to SAVA product search.
  2. Enter product name "X".
  3. Observe search results do not show "Add to cart" button.
- Actual behavior: Search results list lacks quick "Add to cart" control.
- Expected behavior: Each search result should include a quick "Add to cart" control consistent with product listing.
- Attachments: Include screenshots of the search results showing the missing control.
  - Attach snapshot: snapshot_00_00_30_954.png
- Priority: Assign based on business needs (e.g., High for rapid conversion products).
- Assignee: Assign to appropriate frontend/UX owner or SAVA integration engineer.
- Tags/Labels: search, quick-add, cart, validation

Tip:
- Include the product types tested and browser/device info if available to help reproduce.

---

### D. Checkout from cart and note cart-clearing behavior (00:00:38.440 — 00:00:55.480)

1. Open the cart containing your selected items (ensure items added earlier are present).  
   Snapshot:  
   ![Cart open; ready to proceed at 00:00:38.440](./snapshot_00_00_38_440.png)

2. Click "Proceed to checkout".  
   - Expected (future/target behavior): After completing checkout, the cart should be cleared of purchased items.
   - Observed (current implementation): The cart-clearing behavior is not yet implemented — the cart remains populated after checkout.

3. Verify behavior:
   - If your test environment supports checkout, complete the checkout flow and then check the cart contents.
   - Record observed behavior and create a task if cart-clearing is not working as expected (template in section C).

4. If you require an immediate workaround in testing:
   - Manually remove items from the cart after checkout, or
   - Use the cart UI to clear items one by one.

Tip:
- Mark the cart-clearing bug with clear reproduction steps and indicate whether this also affects session persistence or user accounts.

Warning:
- Do not rely on cart-clearing behavior in production until the feature is confirmed implemented and tested.

---

### E. Localization / local feel considerations

- The video references "local feel" or localization settings as additional UI areas to review during the SAVA migration.
- When testing:
  - Check language strings, currency formatting, and locale-specific date/time formats.
  - Ensure product names and UI labels are correct for the target locale.
- Create validation tasks for any locale/UI inconsistency you find, including screenshots and environment settings.

---

## Tips & Best Practices

- Always capture screenshots or short recordings of any UI mismatch or missing control — attach these to validation tickets.
- When filing tasks, include the exact URL, environment (staging/dev), and user/account context to help reproduce.
- Prioritize quick-add behaviors (search and listing) if they affect conversion metrics.
- Keep a consistent checklist for migration testing: product listing, search, cart, checkout, session persistence, localization.

---

## Snapshots (inline references)

- SAVA application context (initial) — 00:00:03.720  
  ![SAVA application context — 00:00:03.720](./snapshot_00_00_03_720.png)

- Product listing / add to cart action — 00:00:14.240  
  ![Product listing view — 00:00:14.240](./snapshot_00_00_14_240.png)

- Cart showing 2 items — 00:00:30.954  
  ![Cart with 2 items — 00:00:30.954](./snapshot_00_00_30_954.png)

- Search results showing missing "Add to cart" — 00:00:30.954  
  ![Search results missing quick-add — 00:00:30.954](./snapshot_00_00_30_954.png)

- Cart open / proceed to checkout — 00:00:38.440  
  ![Cart open; ready to proceed — 00:00:38.440](./snapshot_00_00_38_440.png)

---

## Snapshots

[00:00:03.720]  
[00:00:14.240]  
[00:00:30.954]  
[00:00:38.440]  
[00:00:55.480]