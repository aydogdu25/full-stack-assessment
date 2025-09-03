using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public static string LongestVowelSubsequenceAsJson(List<string> words)
{
    if (words == null || words.Count == 0)
        return JsonSerializer.Serialize(new List<string>());

    string letters = "aeıioöuüAEIİOÖUÜ";

    var results = words.Select(word =>
    {
        string longestSeq = "";
        string currentSeq = "";

        foreach (char c in word)
        {
            if (letters.Contains(c.ToString()))
            {
                currentSeq += c;
                if (currentSeq.Length > longestSeq.Length)
                    longestSeq = currentSeq;
            }
            else
            {
                currentSeq = "";
            }
        }

        return new
        {
            word,
            sequence = longestSeq,
            length = longestSeq.Length
        };
    }).ToList();

    return JsonSerializer.Serialize(results);
}
