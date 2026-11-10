using System;
using System.Linq;

public class Matrix
{
    private readonly int[][] _rows;

    public Matrix(string input)
    {
        _rows = input
            .Split('\n')
            .Select(line => line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToArray())
            .ToArray();
    }

    public int Rows => _rows.Length;

    public int Cols => _rows[0].Length;

    public int[] Row(int row)
    {
        return _rows[row - 1];
    }

    public int[] Column(int col)
    {
        return _rows.Select(row => row[col - 1]).ToArray();
    }
}