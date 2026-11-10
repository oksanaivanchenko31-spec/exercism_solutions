using System;
using System.Collections.Generic;
using System.Linq;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException("Target cannot be negative.");

        if (target == 0)
            return new int[0];

        var minCoins = new int[target + 1];
        var lastCoin = new int[target + 1];

        for (var amount = 1; amount <= target; amount++)
        {
            minCoins[amount] = -1;

            foreach (var coin in coins)
            {
                if (coin > amount)
                    continue;

                var previous = minCoins[amount - coin];
                if (previous == -1)
                    continue;

                if (minCoins[amount] == -1 || previous + 1 < minCoins[amount])
                {
                    minCoins[amount] = previous + 1;
                    lastCoin[amount] = coin;
                }
            }
        }

        if (minCoins[target] == -1)
            throw new ArgumentException("Target cannot be reached with the given coins.");

        var result = new List<int>();
        var remaining = target;

        while (remaining > 0)
        {
            result.Add(lastCoin[remaining]);
            remaining -= lastCoin[remaining];
        }

        result.Sort();
        return result.ToArray();
    }
}