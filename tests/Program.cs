using CrdtNotes.Sync;

var a = new NoteReplica("Ana"); var b = new NoteReplica("Bruno");
a.Edit("texto A"); b.Edit("texto B"); a.Merge(b); b.Merge(a);
if (a.Value != b.Value || a.Value.Replica != "Bruno" || a.Value.Text != "texto B") throw new Exception("Concurrent edits did not converge deterministically.");
Console.WriteLine("CRDT convergence checks passed.");
