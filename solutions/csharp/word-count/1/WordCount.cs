using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var counts = new Dictionary<string, int>();

        var matches = Regex.Matches(phrase.ToLower(), @"[a-z0-9]+(?:'[a-z0-9]+)*");

        foreach (Match match in matches)
        {
            var word = match.Value;

            if (counts.ContainsKey(word))
                counts[word]++;
            else
                counts[word] = 1;
        }

        return counts;
    }
}