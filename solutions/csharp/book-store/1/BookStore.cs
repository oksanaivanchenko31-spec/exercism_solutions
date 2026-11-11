using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private static readonly decimal[] GroupPrice =
    {
        0m,
        8m,   
        15.2m,
        21.6m, 
        25.6m,  
        30m     
    };

    public static decimal Total(IEnumerable<int> books)
    {
        var counts = books
            .GroupBy(b => b)
            .Select(g => g.Count())
            .OrderByDescending(c => c)
            .ToList();

        return Cheapest(counts, new Dictionary<string, decimal>());
    }

    private static decimal Cheapest(List<int> counts, Dictionary<string, decimal> memo)
    {
        if (counts.Count == 0)
            return 0m;

        var key = string.Join(",", counts);
        if (memo.TryGetValue(key, out var cached))
            return cached;

        var best = decimal.MaxValue;

        for (var size = 1; size <= counts.Count; size++)
        {
            var next = counts
                .Select((count, index) => index < size ? count - 1 : count)
                .Where(count => count > 0)
                .OrderByDescending(count => count)
                .ToList();

            var price = GroupPrice[size] + Cheapest(next, memo);

            if (price < best)
                best = price;
        }

        memo[key] = best;
        return best;
    }
}
