class VocabManager
{
    private List<Vocab> vocabs = new List<Vocab>();

    public void AddVocab(string term, string definition)
    {
        Vocab vocab = new Vocab(term, definition);
        vocabs.Add(vocab);
    }

    public List<Vocab> GetAllVocab()
    {
        return vocabs;
    }
}