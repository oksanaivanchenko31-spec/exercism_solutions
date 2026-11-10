using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var words = phrase
            .Replace('-', ' ')
            .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var result = "";

        foreach (var word in words)
        {

            var letter = word.FirstOrDefault(c => char.IsLetter(c));

            if (letter != '\0')
                result += char.ToUpper(letter);
        }

        return result;
    }
}