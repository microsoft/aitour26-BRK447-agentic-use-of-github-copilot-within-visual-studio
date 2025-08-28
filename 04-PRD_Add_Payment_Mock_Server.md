# PRD: Add Mock Payment Server / Payment Service to Zava-Aspire

**Date:** 2025-08-28  
**Author:** Current User & Copilot (documentation draft)

## Purpose

- Provide a lightweight, mock payment flow for the `Store` frontend so checkout can be demonstrated end-to-end without integrating a real payment provider
- Introduce a new Blazor Server-based Payment Service that is registered with .NET Aspire and persists payment records to a new `paymentsdb`
- Enable complete e-commerce demonstration capabilities within the Zava-Aspire solution

## Scope

**What we'll deliver:**
- A new Blazor Server project `src/PaymentsService` that exposes an API and a web UI to view processed payments
- Integration points in `src/ZavaAppHost` to provision `paymentsdb` and pass the connection string to the Payment Service via Aspire configuration
- A mock payment dialog/flow in `src/Store` that prompts the user at checkout and calls the Payment Service `POST /api/payments` endpoint

## Key Success Criteria

- The Store checkout flow invokes a mock payment prompt and posts purchase details to the Payment Service
- The Payment Service stores each payment in `paymentsdb` and the Payments UI shows persisted payments
- Complete end-to-end checkout flow works without external payment dependencies

## Quick Checklist

- [ ] Mock server design: described in this PRD (processing, storage, UI)
- [ ] Checkout prompt: Store UI triggers mock payment and returns a selected mock payment method
- [ ] New Blazor Payment Service: project created under `src/`, registered with Aspire
- [ ] API endpoint: `POST /api/payments` and `GET /api/payments` documented in this PRD
- [ ] Persist payments: records saved in `paymentsdb`
- [ ] Aspire host: provisions `paymentsdb` and passes connection string
- [ ] Payments UI: grid showing processed payments with optional product enrichment

## Assumptions

- Repository targets .NET 9 and the Aspire host is already configured in `src/ZavaAppHost`
- Local dev uses project references and file-based or lightweight DBs (SQLite) by default for demos
- No real payment gateway integration is required; this is a sandbox/mock flow only
- Store frontend already has checkout functionality that can be extended

## High-Level Design Overview

**Architecture Components:**
- **PaymentsService** (Blazor Server, net9.0) — exposes Web API for payments and a Blazor UI to view stored payments
- **Storage** (`paymentsdb`) — created/provisioned by the Aspire host; suggested provider for local dev: SQLite
- **Frontend Integration** — `Store` will show a mock payment dialog at checkout and call the Payment Service API

**Service Flow:**
1. User proceeds to checkout in Store frontend
2. Mock payment dialog collects payment method selection
3. Store calls PaymentsService API with payment details
4. PaymentsService persists payment record to database
5. PaymentsService returns confirmation to Store
6. Users can view payment history via PaymentsService UI

## API Contract Summary

### Endpoints

**POST `/api/payments`**
- **Purpose:** Process a new payment transaction
- **Input:** Payment details including user info, cart items, amount, payment method
- **Output:** Payment confirmation with transaction ID and status

**GET `/api/payments`**
- **Purpose:** Retrieve payment history with pagination
- **Input:** Query parameters for pagination and filtering
- **Output:** List of payment records with metadata

## Data Model Summary

### Tables/Fields (High Level)

**Payments Table:**
- `PaymentId` (GUID, Primary Key)
- `UserId` (string) - Customer identifier
- `StoreId` (string) - Store/tenant identifier  
- `CartId` (string) - Shopping cart reference
- `Currency` (string) - Payment currency (e.g., USD)
- `Amount` (decimal) - Total payment amount
- `Status` (string) - Payment status (Success/Failed)
- `PaymentMethod` (string) - Masked payment method info
- `ItemsJson` (text) - Serialized cart items
- `CreatedAt`/`ProcessedAt` (datetime) - Timestamps

## Implementation Notes

**Suggested Technology Stack:**
- **Blazor Server Service:** New project under `src/PaymentsService`
- **Database:** SQLite for local development, configurable for production
- **Store Integration:** Add typed HttpClient and payment dialog component

**Key Integration Points:**
- EF Core with SQLite provider for data persistence
- Aspire service registration for health checks and discovery
- Service-to-service communication via HTTP APIs
- Optional product enrichment by calling existing Products service

## Configuration & Local Defaults

**Suggested Environment Keys:**
```
ConnectionStrings:PaymentsDb
Services:PaymentsService  
Payments:MockMode (bool)
```

**Local Port Assignments:**
- PaymentsService: `http://localhost:5004`
- Store: Keep existing port, use Aspire discovery

## Security & Privacy Notes

- Do not log raw card data or sensitive payment information
- Use masked payment method strings only (e.g., "Visa ****1111")
- For local demo, authentication between services may be relaxed
- For production, enable service-to-service authentication via Aspire
- Ensure payment data is properly validated and sanitized

## Testing & Validation

**Testing Strategy:**
- **Unit Tests:** PaymentRepository, PaymentsController logic
- **Integration Tests:** Start Aspire host + PaymentsService + Store, run checkout flow
- **Manual Validation:** Complete checkout process, verify payment persistence and UI display

**Acceptance Testing:**
- Verify Store checkout triggers payment dialog
- Confirm payment data persists to database
- Validate Payments UI displays transaction history
- Test error handling for failed payments

## Acceptance Criteria

- [ ] Payment Service project exists at `src/PaymentsService` and targets `net9.0`
- [ ] PaymentsService registers with Aspire (health checks, service discovery)
- [ ] Aspire host provisions `paymentsdb` and exposes connection string to PaymentsService
- [ ] Store shows a mock payment dialog at checkout and posts to PaymentsService
- [ ] PaymentsService persists payment records and makes them available via `GET /api/payments`
- [ ] Payments UI displays payments in a pageable grid with product details when available
- [ ] End-to-end checkout flow completes successfully with payment confirmation

## Rollout Plan

**Phase 1: Core Service Setup**
1. Create PaymentsService skeleton with in-memory persistence
2. Implement basic `POST /api/payments` endpoint
3. Wire Aspire host to provide `paymentsdb` connection string

**Phase 2: Data Persistence**
1. Switch to EF Core SQLite implementation
2. Add database migrations and schema setup
3. Implement payment record persistence

**Phase 3: UI and Integration** 
1. Add Blazor UI page for payment history
2. Update Store frontend with payment dialog
3. Add product enrichment functionality

**Phase 4: Testing and Polish**
1. Add comprehensive unit and integration tests
2. Perform end-to-end validation
3. Optimize performance and error handling

## Appendix

### Example Request/Response JSON

**CreatePaymentRequest:**
```json
{
  "userId": "user-123",
  "currency": "USD", 
  "amount": 39.98,
  "items": [
    { 
      "productId": "prod-001", 
      "quantity": 2, 
      "unitPrice": 19.99 
    }
  ],
  "paymentMethod": "Visa ****1111"
}
```

**CreatePaymentResponse:**
```json
{
  "paymentId": "7e9b8f9a-4c5d-4e6f-8a9b-1c2d3e4f5g6h",
  "status": "Success",
  "processedAt": "2025-08-28T12:34:56Z"
}
```

**GetPaymentsResponse:**
```json
{
  "items": [
    {
      "paymentId": "7e9b8f9a-4c5d-4e6f-8a9b-1c2d3e4f5g6h",
      "userId": "user-123",
      "amount": 39.98,
      "currency": "USD",
      "status": "Success",
      "paymentMethod": "Visa ****1111",
      "processedAt": "2025-08-28T12:34:56Z"
    }
  ],
  "totalCount": 1
}
```

---

*This PRD provides the foundation for implementing a complete mock payment system within the Zava-Aspire solution, enabling full e-commerce demonstration capabilities without external payment dependencies.*