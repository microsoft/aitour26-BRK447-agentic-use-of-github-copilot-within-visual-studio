# Tutorial: Create the GitHub Issue for Missing Unit Tests

> Purpose: This short tutorial shows the exact GitHub Issue content you can copy & paste immediately to request the missing unit tests for this repository. A detailed (optional) section follows with suggested tests and guidance.

Last scan: Aug 22, 2025

## Copy-paste GitHub Issue content (main section)

Use the blocks below — copy the Title and Body into a new GitHub Issue in this repository.

### Title (copy this)

```text
Add missing unit tests for Products, Store, and domain entities
```

### Body (copy this)

```text
### Summary
This issue tracks adding a set of unit tests across the codebase to improve coverage and confidence before making further changes.

### Scope
- Tests for `Products` (AI-search wrapper and seed initializer)
- Tests for `Store` services: `ProductService`, `CartService`, `CheckoutService`
- Unit tests for `CartEntities` domain logic
- Serialization/format tests for `SearchEntities` / `VectorEntities`
- (Optional) integration tests for `ZavaAppHost` program/endpoint mappings

### Acceptance Criteria
- Unit tests added and passing for the items listed below
- No external network calls in unit tests (mock AI/HTTP clients)
- Tests validate success paths and important edge cases (empty results, exceptions)

### Tasks (checklist)
- [ ] Products: `ProductApiActions` / `ProductAiActions` / `MemoryContext` tests
  - [ ] `AISearch_ReturnsOk_WithSearchResponse`
  - [ ] `DbInitializer_Initialize_CreatesSeedProducts`
  - [ ] (optional) `MemoryContext` embedding-based search tests (mocked)

- [ ] Store: `ProductService` tests
  - [ ] `GetProducts_ReturnsProducts_WhenHttpOk`
  - [ ] `GetProducts_ReturnsEmpty_WhenHttpNotOkOrException`
  - [ ] `Search_UsesAiEndpoint_WhenSemanticSearchTrue`

- [ ] Store: `CartService` tests
  - [ ] `GetCartAsync_ReturnsEmptyCart_WhenNoSession`
  - [ ] `GetCartAsync_ReturnsCart_WhenSessionHasJson`
  - [ ] `GetCartAsync_ReturnsEmptyCart_OnSSRException`
  - [ ] `AddToCartAsync_AddsNewItem_WhenProductFound`
  - [ ] `AddToCartAsync_NoAction_WhenProductNotFound`
  - [ ] `UpdateQuantityAsync_RemovesOrUpdatesItem`
  - [ ] `RemoveFromCartAsync_RemovesItem_WhenPresent`
  - [ ] `ClearCartAsync_HandlesSSRException`
  - [ ] `GetCartItemCountAsync_Returns0_OnSSRException`

- [ ] Store: `CheckoutService` tests
  - [ ] `ProcessOrderAsync_CreatesConfirmedOrder_AndSavesToSession`
  - [ ] `GetOrderAsync_ReturnsOrder_WhenExists`

- [ ] Domain: `CartEntities.Cart` calculation tests
  - [ ] `CartCalculation_SubtotalTaxTotalItemCount_CalculatedCorrectly`

- [ ] (Optional) Integration: `ZavaAppHost` program/endpoint registration tests

### Implementation notes
- Use MSTest to match existing tests, and add `Moq` or `NSubstitute` for mocking.
- For EF Core tests, use `Microsoft.EntityFrameworkCore.InMemory` provider.
- For `HttpClient`-backed `ProductService`, use a mock `HttpMessageHandler` injected into `HttpClient`.
- For `ProtectedSessionStorage`, either wrap the dependency behind an interface or create a small test shim in `Store.Tests` to simulate session storage.

### Labels (suggested)
`area:tests`, `type:chore`, `priority:medium`

### Estimate
8-16 story points (broken down across multiple PRs). Prioritize Store service tests and Cart domain tests first.
```

---

## Optional: Detailed suggestions for the needed unit tests

This section is optional for readers who want more guidance after filing the Issue. It contains the analysis, suggested tests, mocking guidance and priorities.

### Summary / scope

This document enumerates suggested unit tests for the repository `src/` folder. No production code changes are proposed here. The goal is to create a prioritized checklist of test work that can be opened as a GitHub Issue and executed later.

Projects analyzed (under `src/`):

- `Products` (API endpoints, AI search integration, data seeding)
- `Store` (Blazor UI app services: `ProductService`, `CartService`, `CheckoutService`)
- `CartEntities`, `DataEntities`, `SearchEntities`, `VectorEntities` (POCOs/value logic)
- `ZavaAppHost` (app host bootstrap / infra)

Existing tests found:

- `src/Products.Tests` contains `ProductApiActionsTests` with good coverage for `ProductApiActions` endpoints (GetAll, GetById, Create, Update, Search).
- `src/Store.Tests` exists but only contains a placeholder `UnitTest1.cs` (no real tests).

Gap summary (high-level):

- `ProductAiActions` (AISearch) and `MemoryContext` are not covered.
- `Store` service classes (`ProductService`, `CartService`, `CheckoutService`) have no unit tests.
- Domain logic for `Cart` (subtotal/tax/total/itemcount) should have focused unit tests.
- `SearchEntities`, `VectorEntities` serialization/formatting and response text logic not covered.
- Integration tests / minimal API tests for endpoint mapping, health checks, and Program bootstrap are missing.

---

### Proposed unit tests (by project)

Each entry shows: target file/class, suggested tests, rationale, difficulty estimate (S/M/L), and notes about mocking.

#### 1) Products

- Targets:
  - `Products.Endpoints.ProductAiActions` (method `AISearch`)
  - `Products.Memory.MemoryContext` (initialization and `Search` logic)
  - `Products.Data.DbInitializer` (seed list) — integration-style test

- Suggested tests:
   1. `ProductAiActions.AISearch_ReturnsOk_WithSearchResponse` (M)
      - Mock `MemoryContext` (or provide a test double) to return a `SearchResponse` instance when `Search` is called.
      - Call `AISearch` with a test search term and an in-memory `Context` (or a mocked `Context`).
      - Assert: returned `IResult` is an `Ok` result and contains the expected `SearchResponse` object.
      - Note: `AISearch` is a thin wrapper, so the main focus is ensuring the result wrapping.

   2. `MemoryContext_Search_ReturnsExpectedResults_WhenEmbeddingsAvailable` (L)
      - Unit-test `MemoryContext.Search` method with mocked `IEmbeddingGenerator` and `IChatClient` (both are injected in constructor in `MemoryContext`).
      - Validate the method handles empty DB, or when embeddings return hits.
      - Difficulty: higher due to mocking 3rd-party OpenAI-style interfaces; use small in-memory vectors or wrap dependencies.

   3. `DbInitializer_Initialize_CreatesSeedProducts` (M)
      - Create an in-memory `ProductDataContext` or `Context` (DbContextOptions with InMemoryDatabase).
      - Call `DbInitializer.Initialize(context)` and assert `context.Product` has expected seeded count and contains at least one known seeded product name.

- Mocks & tools:
  - Use `Microsoft.EntityFrameworkCore.InMemory` for DbContext tests.
  - Use a mocking library (MSTest + Moq or NSubstitute) to mock `MemoryContext` dependencies and `IChatClient` / `IEmbeddingGenerator`.

... (rest of file unchanged)

# Tutorial: How to create the GitHub Issue for the missing unit tests

> Purpose: Quick tutorial that shows the exact GitHub Issue content you can copy & paste immediately to track and request the missing unit tests for this repository. Detailed test suggestions follow as an optional section.

Last scan: Aug 22, 2025

## Copy-paste GitHub Issue content (main section)

Use the block below as the Issue title and body — copy the Title and Body into a new GitHub Issue in this repository.

Title:

```
Add missing unit tests for Products, Store, and domain entities
```

Body (copy-paste):

```
### Summary
This issue tracks adding a set of unit tests across the codebase to improve coverage and confidence before making further changes.

### Scope
- Tests for `Products` (AI-search wrapper and seed initializer)
- Tests for `Store` services: `ProductService`, `CartService`, `CheckoutService`
- Unit tests for `CartEntities` domain logic
- Serialization/format tests for `SearchEntities` / `VectorEntities`
- (Optional) integration tests for `ZavaAppHost` program/endpoint mappings

### Acceptance Criteria
- Unit tests added and passing for the items listed below
- No external network calls in unit tests (mock AI/HTTP clients)
- Tests validate success paths and important edge cases (empty results, exceptions)

### Tasks (checklist)
- [ ] Products: `ProductApiActions` / `ProductAiActions` / `MemoryContext` tests
  - [ ] `AISearch_ReturnsOk_WithSearchResponse`
  - [ ] `DbInitializer_Initialize_CreatesSeedProducts`
  - [ ] (optional) `MemoryContext` embedding-based search tests (mocked)

- [ ] Store: `ProductService` tests
  - [ ] `GetProducts_ReturnsProducts_WhenHttpOk`
  - [ ] `GetProducts_ReturnsEmpty_WhenHttpNotOkOrException`
  - [ ] `Search_UsesAiEndpoint_WhenSemanticSearchTrue`

- [ ] Store: `CartService` tests
  - [ ] `GetCartAsync_ReturnsEmptyCart_WhenNoSession`
  - [ ] `GetCartAsync_ReturnsCart_WhenSessionHasJson`
  - [ ] `GetCartAsync_ReturnsEmptyCart_OnSSRException`
  - [ ] `AddToCartAsync_AddsNewItem_WhenProductFound`
  - [ ] `AddToCartAsync_NoAction_WhenProductNotFound`
  - [ ] `UpdateQuantityAsync_RemovesOrUpdatesItem`
  - [ ] `RemoveFromCartAsync_RemovesItem_WhenPresent`
  - [ ] `ClearCartAsync_HandlesSSRException`
  - [ ] `GetCartItemCountAsync_Returns0_OnSSRException`

- [ ] Store: `CheckoutService` tests
  - [ ] `ProcessOrderAsync_CreatesConfirmedOrder_AndSavesToSession`
  - [ ] `GetOrderAsync_ReturnsOrder_WhenExists`

- [ ] Domain: `CartEntities.Cart` calculation tests
  - [ ] `CartCalculation_SubtotalTaxTotalItemCount_CalculatedCorrectly`

- [ ] (Optional) Integration: `ZavaAppHost` program/endpoint registration tests

### Implementation notes
- Use MSTest to match existing tests, and add `Moq` or `NSubstitute` for mocking.
- For EF Core tests, use `Microsoft.EntityFrameworkCore.InMemory` provider.
- For `HttpClient`-backed `ProductService`, use a mock `HttpMessageHandler` injected into `HttpClient`.
- For `ProtectedSessionStorage`, either wrap the dependency behind an interface or create a small test shim in `Store.Tests` to simulate session storage.

### Labels (suggested)
`area:tests`, `type:chore`, `priority:medium`

### Estimate
8-16 story points (broken down across multiple PRs). Prioritize Store service tests and Cart domain tests first.

```

---

## Optional: Details about the needed unit tests

The section below contains a detailed breakdown of suggested tests, rationale, mocking guidance and priorities. Implementing these tests is optional after opening the Issue, but recommended to improve coverage.

### Summary / scope

This document enumerates suggested unit tests for the repository root `src/` folder. It is intentionally conservative: no production code changes are proposed here. The goal is to create a prioritized checklist of test work that can be opened as a GitHub Issue and executed later.

Projects analyzed (under `src/`):

- `Products` (API endpoints, AI search integration, data seeding)
- `Store` (Blazor UI app services: `ProductService`, `CartService`, `CheckoutService`)
- `CartEntities`, `DataEntities`, `SearchEntities`, `VectorEntities` (POCOs/value logic)
- `ZavaAppHost` (app host bootstrap / infra)

Existing tests found:

- `src/Products.Tests` contains `ProductApiActionsTests` with good coverage for `ProductApiActions` endpoints (GetAll, GetById, Create, Update, Search).
- `src/Store.Tests` exists but only contains a placeholder `UnitTest1.cs` (no real tests).

Gap summary (high-level):

- `ProductAiActions` (AISearch) and `MemoryContext` are not covered.
- `Store` service classes (`ProductService`, `CartService`, `CheckoutService`) have no unit tests.
- Domain logic for `Cart` (subtotal/tax/total/itemcount) should have focused unit tests.
- `SearchEntities`, `VectorEntities` serialization/formatting and response text logic not covered.
- Integration tests / minimal API tests for endpoint mapping, health checks, and Program bootstrap are missing.

---

### Proposed unit tests (by project)

Each entry shows: target file/class, suggested tests, rationale, difficulty estimate (S/M/L), and notes about mocking.

#### 1) Products

- Targets:
  - `Products.Endpoints.ProductAiActions` (method `AISearch`)
  - `Products.Memory.MemoryContext` (initialization and `Search` logic)
  - `Products.Data.DbInitializer` (seed list) — integration-style test

- Suggested tests:
  1. `ProductAiActions.AISearch_ReturnsOk_WithSearchResponse` (M)
     - Mock `MemoryContext` (or provide a test double) to return a `SearchResponse` instance when `Search` is called.
     - Call `AISearch` with a test search term and an in-memory `Context` (or a mocked `Context`).
     - Assert: returned `IResult` is an `Ok` result and contains the expected `SearchResponse` object.
     - Note: `AISearch` is a thin wrapper, so the main focus is ensuring the result wrapping.

  2. `MemoryContext_Search_ReturnsExpectedResults_WhenEmbeddingsAvailable` (L)
     - Unit-test `MemoryContext.Search` method with mocked `IEmbeddingGenerator` and `IChatClient` (both are injected in constructor in `MemoryContext`).
     - Validate the method handles empty DB, or when embeddings return hits.
     - Difficulty: higher due to mocking 3rd-party OpenAI-style interfaces; use small in-memory vectors or wrap dependencies.

  3. `DbInitializer_Initialize_CreatesSeedProducts` (M)
     - Create an in-memory `ProductDataContext` or `Context` (DbContextOptions with InMemoryDatabase).
     - Call `DbInitializer.Initialize(context)` and assert `context.Product` has expected seeded count and contains at least one known seeded product name.

... (remaining details unchanged)

---

If you'd like, I can also open a draft PR adding the easiest tests first (Cart domain and ProductService GetProducts) and include example test files showing mocking patterns (MSTest + Moq + InMemory EF). Let me know which test(s) you want implemented first and I'll create them.

Use the following as the Issue body. The text below is already formatted; copy the entire block into a new GitHub Issue.

Title:

```
Add missing unit tests for Products, Store, and domain entities
```

Body (copy-paste):

```
### Summary
This issue tracks adding a set of unit tests across the codebase to improve coverage and confidence before making further changes.

### Scope
- Tests for `Products` (AI-search wrapper and seed initializer)
- Tests for `Store` services: `ProductService`, `CartService`, `CheckoutService`
- Unit tests for `CartEntities` domain logic
- Serialization/format tests for `SearchEntities` / `VectorEntities`
- (Optional) integration tests for `ZavaAppHost` program/endpoint mappings

### Acceptance Criteria
- Unit tests added and passing for the items listed below
- No external network calls in unit tests (mock AI/HTTP clients)
- Tests validate success paths and important edge cases (empty results, exceptions)

### Tasks (checklist)
- [ ] Products: `ProductApiActions` / `ProductAiActions` / `MemoryContext` tests
  - [ ] `AISearch_ReturnsOk_WithSearchResponse`
  - [ ] `DbInitializer_Initialize_CreatesSeedProducts`
  - [ ] (optional) `MemoryContext` embedding-based search tests (mocked)

- [ ] Store: `ProductService` tests
  - [ ] `GetProducts_ReturnsProducts_WhenHttpOk`
  - [ ] `GetProducts_ReturnsEmpty_WhenHttpNotOkOrException`
  - [ ] `Search_UsesAiEndpoint_WhenSemanticSearchTrue`

- [ ] Store: `CartService` tests
  - [ ] `GetCartAsync_ReturnsEmptyCart_WhenNoSession`
  - [ ] `GetCartAsync_ReturnsCart_WhenSessionHasJson`
  - [ ] `GetCartAsync_ReturnsEmptyCart_OnSSRException`
  - [ ] `AddToCartAsync_AddsNewItem_WhenProductFound`
  - [ ] `AddToCartAsync_NoAction_WhenProductNotFound`
  - [ ] `UpdateQuantityAsync_RemovesOrUpdatesItem`
  - [ ] `RemoveFromCartAsync_RemovesItem_WhenPresent`
  - [ ] `ClearCartAsync_HandlesSSRException`
  - [ ] `GetCartItemCountAsync_Returns0_OnSSRException`

- [ ] Store: `CheckoutService` tests
  - [ ] `ProcessOrderAsync_CreatesConfirmedOrder_AndSavesToSession`
  - [ ] `GetOrderAsync_ReturnsOrder_WhenExists`

- [ ] Domain: `CartEntities.Cart` calculation tests
  - [ ] `CartCalculation_SubtotalTaxTotalItemCount_CalculatedCorrectly`

- [ ] (Optional) Integration: `ZavaAppHost` program/endpoint registration tests

### Implementation notes
- Use MSTest to match existing tests, and add `Moq` or `NSubstitute` for mocking.
- For EF Core tests, use `Microsoft.EntityFrameworkCore.InMemory` provider.
- For `HttpClient`-backed `ProductService`, use a mock `HttpMessageHandler` injected into `HttpClient`.
- For `ProtectedSessionStorage`, either wrap the dependency behind an interface or create a small test shim in `Store.Tests` to simulate session storage.

### Labels (suggested)
`area:tests`, `type:chore`, `priority:medium`

### Estimate
8-16 story points (broken down across multiple PRs). Prioritize Store service tests and Cart domain tests first.

```

---

## Next steps (recommended implementation order)

1. Add unit tests for `Cart` domain computations (small, quick win).
2. Add `ProductService` tests (HttpClient mocking — medium effort).
3. Add `CartService` tests (session shim or wrapper needed; medium effort).
4. Add `CheckoutService` tests.
5. Add `ProductAiActions` / `MemoryContext` tests.
6. Optional: Program/host integration tests.

---

## Companion notes / suggestions

- The code currently generates order numbers with the `ESL-` prefix (`ESL-YYYYMMDD-xxxx`) in `CheckoutService.GenerateOrderNumber`. If the project is being rebranded to `Zava`, consider updating this to `ZV-` or `ZAVA-` and add a test that checks the new format.
- There are several `.vs` and `.slnx` artifacts referencing `eShopLite`; these are cosmetic in the workspace and not test-related, but worth cleaning in a follow-up.

---

If you'd like, I can also open a draft PR adding the easiest tests first (Cart domain and ProductService GetProducts) and include example test files showing mocking patterns (MSTest + Moq + InMemory EF). Let me know which test(s) you want implemented first and I'll create them.
