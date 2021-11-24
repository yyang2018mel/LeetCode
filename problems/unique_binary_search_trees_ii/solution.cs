/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

using System.Collections.Immutable;

public class Solution {
    
    private static ImmutableArray<TreeNode?> GenerateTrees(ImmutableArray<ImmutableArray<TreeNode?>[]> cached, int size, int offset)
    {
        if (cached[size][offset].Length == 0)
            cached[size][offset] = generate();
        return cached[size][offset];

        ImmutableArray<TreeNode?> generate()
        {
            var builder = ImmutableArray.CreateBuilder<TreeNode?>();

            for (var lowerIdx = 1; lowerIdx <= size; lowerIdx++)
            {
                var lefts  = GenerateTrees(cached, lowerIdx - 1, offset);
                var rights = GenerateTrees(cached, size - lowerIdx, lowerIdx + offset);

                foreach (var left in lefts)
                {
                    foreach (var right in rights)
                    {
                        var tree = new TreeNode(lowerIdx + offset, left, right);
                        builder.Add(tree);
                    }
                }
            }

            return builder.ToImmutable();
        }
    }

    public static ImmutableArray<ImmutableArray<TreeNode?>[]> GenerateEmptyCache(int n)
    {
        var cacheBuilder = ImmutableArray.CreateBuilder<ImmutableArray<TreeNode?>[]>(n + 1);
        for (var i = 0; i <= n; i++)
        {
            var empty = new ImmutableArray<TreeNode?>[n + 1];
            for (var j = 0; j < n; j++)
                empty[j] = ImmutableArray<TreeNode?>.Empty;
            cacheBuilder.Add(empty);
        }

        var zeroSize = new[] { (TreeNode?)null }.ToImmutableArray();
        for (var i=0; i <=n; ++i)
        {
            cacheBuilder[0][i] = zeroSize;
        }

        return cacheBuilder.MoveToImmutable();
    }

    public IList<TreeNode> GenerateTrees(int n)
    {
        var cache = GenerateEmptyCache(n);

        var trees = GenerateTrees(cache, n, 0);

        return trees;
    }

}