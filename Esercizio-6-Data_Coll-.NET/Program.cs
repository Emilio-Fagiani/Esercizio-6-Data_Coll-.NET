using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter the path to the .txt file: ");
        string filePath = Console.ReadLine();

        Dictionary<string, int> wordFrequency = CountWordFrequency(filePath);

        Console.WriteLine("Word frequency in the file:");
        foreach (var pair in wordFrequency)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    static Dictionary<string, int> CountWordFrequency(string filePath)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        try
        {
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return wordFrequency;
    }
}
