namespace CrdtNotes.Sync;

public sealed record NoteVersion(string Text, long Clock, string Replica);

public sealed class NoteReplica(string id)
{
    public string Id { get; } = id;
    public NoteVersion Value { get; private set; } = new("", 0, "seed");

    public NoteVersion Edit(string text)
    {
        Value = new(text, Value.Clock + 1, Id);
        return Value;
    }

    public void Reset() => Value = new("", 0, "seed");

    public void Merge(NoteReplica other)
    {
        if (Compare(other.Value, Value) > 0) Value = other.Value;
    }

    public static int Compare(NoteVersion left, NoteVersion right)
    {
        var byClock = left.Clock.CompareTo(right.Clock);
        return byClock != 0 ? byClock : StringComparer.Ordinal.Compare(left.Replica, right.Replica);
    }
}
