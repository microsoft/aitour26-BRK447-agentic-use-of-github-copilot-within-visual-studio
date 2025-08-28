# Tutorial: Create the GitHub Issue for Missing Unit Tests

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
