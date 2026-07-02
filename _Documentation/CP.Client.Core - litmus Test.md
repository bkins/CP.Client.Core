## 1. The litmus test (this is the only rule you need)

Something belongs in **CP.Client.Core** if **all** of the following are true:

- It is **client-side**, not API-side  
- It has **no UI knowledge**  
- It has **no transport knowledge**  
- It makes sense for **more than one client**  
- It exists to preserve **intent** or **truth** when execution is uncertain

## 2. Code that answers questions like:

- _Is this action allowed right now?_
- _Can this be replayed later?_
- _Should we fail fast or defer?_
    
That logic should move to, or be created in, CP.Client.Core

## 3. Anything that deals with:

- Storing Knowledge locally
- Validating Knowledge snapshots
- Determining whether local Knowledge is usable
- Handling “stale but viewable” vs “invalid”

…belongs in CP.Client.Core.

What does **not** belong:

- HTTP calls to fetch Knowledge
- UI binding logic
- Pagination / scrolling
- Presentation formatting
    
If both MAUI and Console currently:

- Store Knowledge locally
- Load it on startup
- Display it when offline

Then the _rules_ for when that’s allowed are shared — and should move.

## 4. “Glue code” that feels boring but important

- Small helper classes that exist only to “make things consistent” 
- ID generation helpers
- Correlation IDs
- Timestamp normalization
- Result wrappers (“Success / Failure” types)
- Explicit error models (not exceptions)
    
These often live in:

- `Utils`
- `Helpers`
- `Common`
- `Avails`
- Or directly inside services “for convenience”
    
Those are prime CP.Client.Core candidates **if** they meet the litmus test.

## 5. likely candidates

- A queue or list of deferred actions (even if simple)
- Logic that decides whether something can run offline
- Local Knowledge storage models
- “Read-only mode” decisions
- State flags like:
    - `IsOffline`
    - `CanExecute`
    - `IsDeferred`
        
- Error handling paths that exist _only_ because the API is unavailable
    
Those should be **extracted**, not duplicated.

## 6. Likely _not_ candidates (leave them where they are)

- HTTP clients
- API DTOs
- ViewModels
- Console command parsing
- Navigation logic
- Retry timers
- Background tasks
- Anything that “does” the execution
    
If it _does_ something externally, it doesn’t belong.

If it _decides_ something internally, it probably does.