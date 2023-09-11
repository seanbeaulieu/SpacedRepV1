public class Vocab
{
    public string Term { get; set; }
    public string Definition { get; set; }

    public bool Equals(Vocab other)
    {
        if (other == null) return false;
        return Term.Equals(other.Term, StringComparison.OrdinalIgnoreCase)
            && Definition.Equals(other.Definition, StringComparison.OrdinalIgnoreCase);
    }

    public Vocab(string term, string definition)
    {
        Term = term;
        Definition = definition;
    }
}
