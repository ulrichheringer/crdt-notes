# crdt-notes

A two-replica note editor for exploring concurrent edits and conflict resolution. Synchronization uses a last-write-wins register with logical clocks and replica IDs.

## Run

Requires the .NET 10 SDK. Browser builds also need the WebAssembly workload: `dotnet workload install wasm-tools`.

### Desktop

~~~sh
dotnet run --project CrdtNotes.Desktop/CrdtNotes.Desktop.csproj
~~~

### Browser

~~~sh
dotnet run --project CrdtNotes.Browser/CrdtNotes.Browser.csproj
~~~

## Example

Edit both replicas before syncing to see how concurrent changes converge.
