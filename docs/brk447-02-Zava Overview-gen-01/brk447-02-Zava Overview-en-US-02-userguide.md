# Video: [brk447-02-Zava Overview.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:00:57

# SAVA Migration — E-commerce User Manual

This manual describes the user interactions demonstrated in the video walkthrough of the migration to the new SAVA e-commerce experience. It explains how to add items to the cart, validate search-result behavior, and exercise the checkout flow while documenting missing or outstanding behaviors for the development team.

---

## Overview
Duration shown in video: 00:00:03.720 – 00:00:55.480

This project migrates existing e-commerce sites to the SAVA application. The team is deploying services and integrating UI behaviors as part of the migration. The video demonstrates:

- Adding products to a cart and verifying the cart contents (00:00:14.240 – 00:00:30.954)  
- Searching for a product and identifying a missing "Add to cart" option in search results (00:00:30.954 – 00:00:38.440)  
- Proceeding to checkout and observing that the cart-clearing behavior has not yet been implemented (00:00:38.440 – 00:00:55.480)

Use this manual to reproduce those actions, verify expected behaviors, and capture validation tasks for implementation work.

---

## Step-by-step instructions

### 1. Context — Accessing the SAVA application
Timestamp reference: 00:00:03.720 – 00:00:14.240

1. Open the SAVA application in your browser or development environment.
2. Confirm you see the overall e-commerce UI (product listings, search bar, cart icon).
3. Note that this environment may be a migration/staging build — some behaviors may be incomplete.

Tip: If you don’t see product listings, verify that the deployment and service integrations for SAVA are up and running.

---

### 2. Adding products to the cart (example)
Timestamp reference: 00:00:14.240 – 00:00:30.954

Goal: Add two products to the cart and verify the cart count reads 2.

UI elements involved:
- Product listing (catalog/list view)
- Add to cart button on product cards
- Cart icon / cart view / cart count indicator

Steps:
1. Locate the product listing or product card for the first item (example: “paint wall”).
2. Click the product card to open the product details if needed, or click the visible **Add to cart** button on the product listing.
3. Repeat for a second product (example: “good stain”) by selecting it and clicking **Add to cart**.
4. Click the cart icon or open the cart view to verify the cart count and displayed items.
   - Expected: The cart shows 2 items and lists both products added.

Tip: If an item does not appear in the cart after clicking **Add to cart**, note the exact steps and capture a screenshot for debugging.

Warning: On current migration builds the checkout behavior may be incomplete — do not assume completing checkout will clear the cart (see section 4).

---

### 3. Searching for products and validating missing Add-to-Cart option
Timestamp reference: 00:00:30.954 – 00:00:38.440

Goal: Search for a product and confirm whether the search results include the Add to cart action. If missing, create a validation task for the engineering team.

UI elements involved:
- Search input / search box
- Search results list
- (Expected) Add to cart control in search results

Steps:
1. Enter the product name (or partial name) into the search input and submit the search.
2. Inspect each search-result item in the results list.
3. Confirm whether an **Add to cart** option is present directly in search results.
   - Expected behavior: Users should be able to add an item to the cart from search results.
   - Observed (in video): The **Add to cart** option is missing from search results.

If the Add to cart control is missing:
4. Create/assign a validation/task for the team with the following information:
   - Title: “Add to cart missing from search results”
   - Environment: (staging/branch/deployment name)
   - Steps to reproduce:
     1. Navigate to SAVA product search.
     2. Search for “[product name]”.
     3. Observe search results; note the absence of an Add to cart button.
   - Expected result: Add to cart button visible in search results for applicable product types.
   - Actual result: Add to cart button not present.
   - Attachments: screenshot(s) of search results, browser console logs (if available), timestamp (00:00:30.954).
   - Priority and assignee: set according to team workflow.

Tip: Include product IDs or SKUs whenever possible to help developers reproduce the issue deterministically.

---

### 4. Cart checkout behavior and outstanding implementation work
Timestamp reference: 00:00:38.440 – 00:00:55.480

Goal: Proceed to checkout and document the cart-clearing behavior (or lack thereof) and other UI/localization considerations.

UI elements involved:
- Cart view
- Proceed to checkout button
- Cart-clearing behavior (expected feature)
- Locale / localization settings or local feel elements

Steps:
1. From the cart view (after adding items), click **Proceed to checkout**.
2. Observe the behavior after completing checkout (or after navigating to the checkout page).
   - Observed (in video): The behavior that should clear the cart after checkout is not implemented.
3. Document this as an outstanding implementation task:
   - Title: “Cart not cleared after checkout”
   - Steps to reproduce:
     1. Add n items to the cart.
     2. Proceed to checkout.
     3. Complete checkout flow (or navigate back to storefront).
     4. Observe whether the cart content is retained or cleared.
   - Expected result: Cart should be cleared after successful checkout.
   - Actual result: Cart remains populated (feature missing).
   - Attach screenshots and timestamp (00:00:38.440 – 00:00:55.480).
4. Note other areas that may require work:
   - Additional UI actions/places across the app that need parity with legacy experience.
   - Locale / local feel: ensure that localization (text, currency, date formats, etc.) is consistent for target locales.

Tip: When creating implementation tickets, include whether the expected cart-clearing should occur immediately on successful order confirmation or upon explicit action. Also include any session/persistence details observed.

Warning: Do not rely on the cart being auto-cleared in current SAVA staging builds—retain manual tracking of test items to avoid accidental test purchases or confusion during QA.

---

## Validation task template (copy/paste)
Use this short template when filing tickets or validation tasks:

- Title: [short descriptive title]
- Environment: [staging/branch/deployment]
- Timestamp: [e.g., 00:00:30.954]
- Steps to reproduce:
  1. [step 1]
  2. [step 2]
  3. ...
- Expected result: [what should happen]
- Actual result: [what happens now]
- Attachments: [screenshots, console logs, product IDs]
- Priority / Assignee: [team inputs]

---

## Quick reference — UI elements
- Product listing / product cards — where items are shown and Add to cart often appears  
- Add to cart button — may appear on product card, product page, or search result (expected)  
- Cart icon / cart view — view current items and counts  
- Search box / results list — search for products; verify presence of Add to cart in results  
- Proceed to checkout button — start checkout workflow

---

If you need a checklist or a formatted bug report for your issue tracker based on the above steps, use the Validation task template to ensure consistent reporting.