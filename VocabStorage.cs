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
            string jsonVocab = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Vocab>>(jsonVocab);
        }
        return new List<Vocab>();
    }

    public void SaveVocab(List<Vocab> vocabularies)
    {
            List<Vocab> cur_vocabularies = Load();
            // append vocabularies to cur_vocabularies
            cur_vocabularies.AddRange(vocabularies);
            string json = JsonConvert.SerializeObject(cur_vocabularies, Formatting.Indented);
            File.WriteAllText(FilePath, json);
    }

    public void WipeVocabs()
    {
        File.WriteAllText(FilePath, "[]");
    }


    // Remove a vocabulary word from the list
    public void Remove(Vocab vocabToRemove)
    {
        // Create a temporary file path
        string tempFilePath = Path.GetTempFileName();

        // Open the input file for reading
        using (StreamReader reader = new StreamReader(FilePath))
        {
            // Open the temporary file for writing
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Deserialize the line into a Vocab object
                    Vocab vocab = JsonConvert.DeserializeObject<Vocab>(line);

                    // Check if the vocab matches the one to remove
                    if (!vocab.Equals(vocabToRemove))
                    {
                        // Write the line to the temporary file
                        writer.WriteLine(line);
                    }
                }
            }
        }

        // Replace the original file with the temporary file
        File.Delete(FilePath);
        File.Move(tempFilePath, FilePath);
    }
}
