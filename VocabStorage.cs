using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class VocabStorage
{
    private const string FilePath = "vocabulary.json";

    public List<Vocab> Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Vocab>>(json);
        }
        return new List<Vocab>();
    }

    public void Save(List<Vocab> vocabulary)
    {
        string json = JsonConvert.SerializeObject(vocabulary, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }
}
