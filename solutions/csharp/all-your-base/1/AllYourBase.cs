using System;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2)
            throw new ArgumentException("Input base must be at least 2.");

        if (outputBase < 2)
            throw new ArgumentException("Output base must be at least 2.");

        long value = 0;

        foreach (var digit in inputDigits)
        {
            if (digit < 0 || digit >= inputBase)
                throw new ArgumentException("Digit is out of range for the input base.");

            value = value * inputBase + digit;
        }

        if (value == 0)
            return new[] { 0 };

        var result = new List<int>();

        while (value > 0)
        {
            result.Add((int)(value % outputBase));
            value /= outputBase;
        }

        result.Reverse();
        return result.ToArray();
    }
}