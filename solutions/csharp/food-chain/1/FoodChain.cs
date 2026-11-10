using System;
using System.Collections.Generic;

public static class FoodChain
{
    private static readonly (string Animal, string Remark)[] Animals =
    {
        ("fly", ""),
        ("spider", "It wriggled and jiggled and tickled inside her."),
        ("bird", "How absurd to swallow a bird!"),
        ("cat", "Imagine that, to swallow a cat!"),
        ("dog", "What a hog, to swallow a dog!"),
        ("goat", "Just opened her throat and swallowed a goat!"),
        ("cow", "I don't know how she swallowed a cow!"),
        ("horse", "She's dead, of course!")
    };

    private const string FlyEnding =
        "I don't know why she swallowed the fly. Perhaps she'll die.";

    public static string Recite(int verseNumber)
    {
        var index = verseNumber - 1;
        var lines = new List<string>
        {
            $"I know an old lady who swallowed a {Animals[index].Animal}."
        };

        if (index == Animals.Length - 1)
        {
            lines.Add(Animals[index].Remark);
            return string.Join("\n", lines);
        }

        if (index > 0)
            lines.Add(Animals[index].Remark);

        for (var i = index; i > 0; i--)
            lines.Add($"She swallowed the {Animals[i].Animal} to catch the {CatchTarget(i - 1)}.");

        lines.Add(FlyEnding);
        return string.Join("\n", lines);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = new List<string>();
        for (var verse = startVerse; verse <= endVerse; verse++)
            verses.Add(Recite(verse));

        return string.Join("\n\n", verses);
    }

    private static string CatchTarget(int index) =>
        Animals[index].Animal == "spider"
            ? "spider that wriggled and jiggled and tickled inside her"
            : Animals[index].Animal;
}