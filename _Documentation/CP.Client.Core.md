# CP.Client.Core

## Purpose, Path, and Architectural Patterns

---

## 1. Why This Library Exists (Purpose)

`CP.Client.Core` exists to support **serious CP clients**—clients that must remain correct, honest, and useful even when the CP API is unavailable or unreachable.

It is **not required** for all clients.

A thin, always-online client that simply sends requests and renders responses may not need this library at all.

This library exists specifically to solve two hard client-side problems that cannot be solved safely by naïve implementations:

1. **Deferred execution**  
    Capturing, preserving, and replaying _user intent_ when immediate execution is not possible.
    
2. **Offline read access to authoritative data**  
    Safely caching _read-only Knowledge data_ so clients can view what is already true, even while offline.
    

The library is intentionally narrow, explicit, and boring. Its job is to prevent subtle lies, not to add convenience.

---

## 2. The Core Mental Model (Path to Clarity)

The key architectural insight that guided this design is the separation of **truth**, **permission**, and **execution**:

> **CP API defines what is true.**  
> **CP.Client.Core defines what is allowed.**  
> **Clients define what actually happens.**

This separation scales because it prevents responsibility bleed:

- The API never needs to guess what a client meant.
    
- Clients never need to guess what the API will accept.
    
- The shared library never needs to care about UI, transport, or storage technology.
    

---

## 3. Two Fundamentally Different Client-Side Concerns

Early discussions conflated two kinds of “offline storage.” They must be treated as **separate subsystems**, governed by different rules.

### 3.1 Deferred Execution (Intent Capture)

This is about **what the user wants to do**.

Examples:

- “Archive this Knowledge item”
    
- “Create a task”
    
- “Add a journal entry”
    

Characteristics:

- Provisional
    
- User-originated
    
- May never execute
    
- May execute later
    
- Must not pretend success
    
- Must be inspectable and cancellable
    

The client stores **intent**, not facts.

This subsystem is governed by:

- Explicit intent records
    
- Deterministic replay
    
- No implicit execution
    
- Clear failure modes
    

This is the _primary_ reason `CP.Client.Core` exists.

---

### 3.2 Knowledge Inbox (Read-Only Replicated Truth)

This is about **what is already true**.

Examples:

- Knowledge items returned by the CP API
    
- Historical entries
    
- Read-only domain data
    

Characteristics:

- Source of truth is the API
    
- Client copy is read-only
    
- Client copy may be stale
    
- Client copy must never invent or mutate data
    
- Client copy should be semantically identical to the API’s view
    

This is **not intent**.  
This is **cached truth**.

This subsystem exists to allow offline _viewing_, not offline _decision-making_.

---

## 4. Role of CP.Client.Core in Each Subsystem

### 4.1 Role in Deferred Execution

CP.Client.Core:

- Defines what a valid _intent_ looks like
    
- Enforces invariants before intent is queued
    
- Ensures intent can be replayed deterministically
    
- Prevents silent or implicit execution
    
- Treats execution as a separate concern
    

CP.Client.Core does **not**:

- Execute API calls
    
- Know about HTTP or transports
    
- Decide UI flows
    
- Guess missing data
    

---

### 4.2 Role in Knowledge Inbox Replication

CP.Client.Core does **not** own Knowledge storage.

However, it **does** govern the rules that make client-side Knowledge caching safe.

CP.Client.Core may:

- Define canonical **client-side Knowledge models**
    
- Enforce schema compatibility and versioning
    
- Validate snapshot integrity
    
- Define staleness semantics
    
- Ensure read-only guarantees
    

CP.Client.Core must **never**:

- Allow local mutation of Knowledge data
    
- Treat cached Knowledge as authoritative
    
- Merge or reconcile conflicting truths
    
- “Sync” Knowledge bidirectionally
    

Clients store Knowledge data **only** as a read model.

Any action that would change Knowledge is captured as **intent**, not as a local mutation.

---

## 5. Data Shape and Duplication (A Critical Clarification)

There is intentional duplication between client and API storage.

This duplication is **healthy**, but only when properly scoped.

### What must be aligned:

- Field meanings
    
- Required vs optional data
    
- Domain semantics
    
- Version compatibility
    

### What must not be forced identical:

- Persistence format
    
- Storage engine
    
- Transport DTOs
    
- Lifecycle metadata
    
- Internal indexes or optimizations
    

The client does **not** store “API data.”

It stores:

- Provisional intent (for future execution)
    
- Cached truth (for offline viewing)
    

CP.Client.Core governs **compatibility**, not sameness.

---

## 6. Contract of Purity (Foundational Guardrails)

`CP.Client.Core` is a **pure client-side domain library**.

It must never reference:

- UI frameworks
    
- Hosting frameworks
    
- Transport mechanisms
    
- Platform-specific APIs
    
- Environment variables
    
- System clocks
    
- Threading or dispatch models
    

All external concerns are injected via interfaces.

The library consumes inputs.  
It never sources them implicitly.

---

## 7. Time, Identity, and Scope

- The library assumes **a single client instance**
    
- All state is client-local
    
- No cross-device coordination is assumed
    
- Time is supplied externally
    
- Identity is local but stable across restarts
    

The goal is replay safety, not distributed consensus.

---

## 8. What This Library Is Not

`CP.Client.Core` is **not**:

- A general CP SDK
    
- A networking layer
    
- A sync engine
    
- A background automation system
    
- A UI abstraction
    
- A convenience wrapper
    

It is deliberately incomplete unless paired with a real client.

---

## 9. The North Star

This sentence should remain true even as features evolve:

> **CP.Client.Core exists to ensure that user intent is captured, preserved, and replayed safely when immediate execution is not possible.**

Everything else is secondary.

Knowledge caching is supported because it prevents _lying by omission_ when offline—not because the library wants to manage data.

---

## 10. Practical Implications

Because of these decisions:

- Some clients will not need this library
    
- Offline-capable clients will rely on it heavily
    
- Features that feel “helpful” but hide uncertainty will be rejected
    
- Debugging will be easier because state is explicit
    
- Trust will be preserved between user, client, and API
    

This library defines **what a client refuses to fake**.