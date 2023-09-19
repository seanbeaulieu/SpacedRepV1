using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class VocabManager
{
    private readonly List<Vocab> vocabs = new List<Vocab>();
    private readonly object vocabLock = new object();
    private readonly VocabStorage vocabStorage = new VocabStorage();

    public VocabManager()
    {
        vocabs = vocabStorage.Load();
    }

    // Add a new vocabulary word to the list
    public void AddVocab(string term, string definition)
    {
        Vocab vocab = new Vocab(term, definition);
        lock (vocabLock)
        {
            List<Vocab> vocabList = new List<Vocab> { vocab };
            vocabStorage.SaveVocab(vocabList);
        }
    }

    // Remove a vocabulary word from the list
    public bool RemoveVocab(Vocab vocabToRemove)
    {
        lock (vocabLock)
        {

            // Get all vocabs present in vocabulary.json
            List<Vocab> cur_vocabs = vocabStorage.Load();

            // Find the vocab with matching Term and Definition
            Vocab? matchingVocab = cur_vocabs.FirstOrDefault(v => v.Equals(vocabToRemove));

            // Check if the vocab was found
            if (matchingVocab != null)
            {
                vocabStorage.WipeVocabs();
                cur_vocabs.Remove(matchingVocab);
                vocabStorage.SaveVocab(cur_vocabs);
                return true; // Vocabulary word removed successfully
            }

            return false; // Vocabulary word not found
        }
    }
    
    public List<Vocab> GetAllVocab()
    {
        return vocabStorage.Load();
    }

    public Vocab GetRandomVocab() 
    {
        // Get all vocabs present in vocabulary.json
        List<Vocab> cur_vocabs = vocabStorage.Load();

        // Select random vocab from the list
        Random random = new Random();
        int random_idx = random.Next(cur_vocabs.Count);
        
        return cur_vocabs[random_idx]; 
    }
}