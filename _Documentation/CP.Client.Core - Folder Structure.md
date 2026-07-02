CP.Client.Core
│
├── Intent
│   ├── Models
│   ├── Validation
│   ├── Policies
│   └── Abstractions
│
├── Knowledge
│   ├── Models
│   ├── Validation
│   ├── Versioning
│   └── Abstractions
│
├── Storage
│   ├── Abstractions
│   └── Contracts
│
├── Common
│   ├── Identity
│   ├── Time
│   ├── Errors
│   └── Results
│
├── Diagnostics
│   ├── Models
│   └── Abstractions
│
├── Serialization
│   ├── Contracts
│   └── Versioning
│
└── Internal

----
## 1. `Intent/` — deferred execution, explicitly

This folder exists because **intent is the heart of the library**.

### `Intent/Models`

- Intent envelopes
    
- Intent metadata
    
- Replay identifiers
    
- Provisional state
    

These models are _not_ API DTOs.  
They represent **requests for future truth**.

### `Intent/Validation`

- Structural validation
    
- Invariant enforcement
    
- “Is this intent even allowed to be queued?”
    

No execution logic here. Just rules.

### `Intent/Policies`

- Replay rules
    
- Cancellation rules
    
- Staleness or expiration logic
    
- Explicit gating (“this must not run offline”)
    

Policies are **decisions**, not actions.

### `Intent/Abstractions`

- Interfaces the client must implement
    
    - e.g. intent persistence
        
    - intent dispatch hooks
        
- No concrete implementations
    

This is where the library reaches _outward_.

---

## 2. `Knowledge/` — cached truth, strictly read-only

This folder exists to make it **impossible to confuse Knowledge with Intent**.

### `Knowledge/Models`

- Client-side read models
    
- Snapshot metadata
    
- API-aligned domain representations
    

These should feel boring and stable.

### `Knowledge/Validation`

- Snapshot integrity checks
    
- Required field enforcement
    
- Schema compatibility rules
    

### `Knowledge/Versioning`

- Schema version handling
    
- Compatibility checks
    
- “Can I safely display this offline?”
    

### `Knowledge/Abstractions`

- Read-only access interfaces
    
- Snapshot providers
    
- Refresh hooks (but not fetch logic)
    

No mutation. Ever.

---

## 3. `Storage/` — where data goes, not how

This is intentionally narrow.

### `Storage/Abstractions`

- Generic interfaces for persistence
    
- No assumptions about SQLite, files, IndexedDB, etc.
    

### `Storage/Contracts`

- Expected behaviors
    
- Atomicity guarantees
    
- Durability expectations
    

This prevents clients from “kind of” implementing storage.

---

## 4. `Common/` — shared primitives, not utilities

This is _not_ a dumping ground.

### `Common/Identity`

- Local identifiers
    
- Correlation tokens
    
- Replay-safe identity helpers
    

### `Common/Time`

- Clock abstractions
    
- Timestamp contracts
    
- No concrete time sourcing
    

### `Common/Errors`

- Domain-specific failure types
    
- Explicit error states (not exceptions-as-flow)
    

### `Common/Results`

- Result types
    
- Explicit success/failure modeling
    

If something feels “generic”, question whether it belongs here.

---

## 5. `Diagnostics/` — observability without behavior

This is for **explanation**, not execution.

### `Diagnostics/Models`

- Diagnostic records
    
- Audit-friendly metadata
    
- State explanations
    

### `Diagnostics/Abstractions`

- Diagnostic sinks
    
- Reporting interfaces
    

No logging frameworks. No side effects.

---

## 6. `Serialization/` — contracts, not transports

Serialization is treated as **a compatibility concern**, not a convenience.

### `Serialization/Contracts`

- Canonical serialized shapes
    
- Versioned envelopes
    
- Explicit field definitions
    

### `Serialization/Versioning`

- Upgrade/downgrade rules
    
- Compatibility checks
    
- Forward/backward handling
    

This is critical for offline replay and long-lived data.

---

## 7. `Internal/` — explicitly not public

This folder exists to **protect you from yourself**.

- Helpers
    
- Shared logic
    
- Internal coordination code
    

Nothing here should be part of the public API.