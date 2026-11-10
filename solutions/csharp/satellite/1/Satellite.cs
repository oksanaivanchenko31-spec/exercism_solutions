using System;
using System.Collections.Generic;
using System.Linq;

public class Tree
{
    public Tree(int value, Tree left, Tree right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public int Value { get; }
    public Tree Left { get; }
    public Tree Right { get; }

    public override bool Equals(object obj)
    {
        if (obj is not Tree other)
            return false;

        return Value == other.Value
            && Equals(Left, other.Left)
            && Equals(Right, other.Right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Left, Right);
    }
}

public static class Satellite
{
    public static Tree TreeFromTraversals(int[] preorder, int[] inorder)
    {
        if (preorder.Length != inorder.Length)
            throw new ArgumentException("Traversals must have the same length.");

        if (preorder.Distinct().Count() != preorder.Length)
            throw new ArgumentException("Traversals must contain unique items.");

        if (!preorder.OrderBy(x => x).SequenceEqual(inorder.OrderBy(x => x)))
            throw new ArgumentException("Traversals must have the same elements.");

        return Build(preorder.ToList(), inorder.ToList());
    }

    private static Tree Build(List<int> preorder, List<int> inorder)
    {
        if (preorder.Count == 0)
            return null;

        var rootValue = preorder[0];
        var rootIndex = inorder.IndexOf(rootValue);

        var leftPre = preorder.Skip(1).Take(rootIndex).ToList();
        var leftIn = inorder.Take(rootIndex).ToList();

        var rightPre = preorder.Skip(rootIndex + 1).ToList();
        var rightIn = inorder.Skip(rootIndex + 1).ToList();

        var left = Build(leftPre, leftIn);
        var right = Build(rightPre, rightIn);

        return new Tree(rootValue, left, right);
    }
}