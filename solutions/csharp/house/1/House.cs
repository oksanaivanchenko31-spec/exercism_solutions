using System;
using System.Collections.Generic;

public static class House
{
    private static readonly string[] Subjects =
    {
        "house that Jack built",
        "malt",
        "rat",
        "cat",
        "dog",
        "cow with the crumpled horn",
        "maiden all forlorn",
        "man all tattered and torn",
        "priest all shaven and shorn",
        "rooster that crowed in the morn",
        "farmer sowing his corn",
        "horse and the hound and the horn"
    };

    private static readonly string[] Actions =
    {
        "",
        "that lay in",
        "that ate",
        "that killed",
        "that worried",
        "that tossed",
        "that milked",
        "that kissed",
        "that married",
        "that woke",
        "that kept",
        "that belonged to"
    };

    public static string Recite(int verseNumber)
    {
        var last = verseNumber - 1;
        var parts = new List<string>
        {
            $"This is the {Subjects[last]}"
        };

        for (var k = last; k > 0; k--)
            parts.Add($"{Actions[k]} the {Subjects[k - 1]}");

        return string.Join(" ", parts) + ".";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = new List<string>();
        for (var verse = startVerse; verse <= endVerse; verse++)
            verses.Add(Recite(verse));

        return string.Join("\n", verses);
    }
}