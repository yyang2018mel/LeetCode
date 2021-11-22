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
    
    static readonly ImmutableArray<TreeNode?> SizeZero = new[] { (TreeNode?)null }.ToImmutableArray();

    private static ImmutableArray<TreeNode?> generateTrees(int size, int offset, ImmutableArray<TreeNode> leaves)
    {
        return size switch
        {
            0 => SizeZero,
            1 => SizeOne(),
            2 => SizeTwo(),
            3 => SizeThree(),
            _ => SizeN()
        };

        ImmutableArray<TreeNode?> SizeOne()
        {
            var builder = ImmutableArray.CreateBuilder<TreeNode?>(1);
            builder.Add(leaves[offset + 1]);
            return builder.MoveToImmutable();
        }

        ImmutableArray<TreeNode?> SizeTwo()
        {
            var builder = ImmutableArray.CreateBuilder<TreeNode?>(2);
            builder.Add(new TreeNode(1 + offset, null, leaves[2 + offset]));
            builder.Add(new TreeNode(2 + offset, leaves[1 + offset], null));
            return builder.MoveToImmutable();
        }

        ImmutableArray<TreeNode?> SizeThree()
        {
            var builder = ImmutableArray.CreateBuilder<TreeNode?>(5);
            builder.Add(new TreeNode(1 + offset, null, new TreeNode(2 + offset, null, leaves[3 + offset])));
            builder.Add(new TreeNode(1 + offset, null, new TreeNode(3 + offset, leaves[2 + offset], null)));
            builder.Add(new TreeNode(2 + offset, leaves[1 + offset], leaves[3 + offset]));
            builder.Add(new TreeNode(3 + offset, new TreeNode(1 + offset, null, leaves[2 + offset]), null));
            builder.Add(new TreeNode(3 + offset, new TreeNode(2 + offset, leaves[1 + offset], null), null));
            return builder.MoveToImmutable();
        }

        ImmutableArray<TreeNode?> SizeN()
        {
            var builder = ImmutableArray.CreateBuilder<TreeNode?>();

            for (var lowerIdx = 1; lowerIdx <= size; lowerIdx++)
            {
                var lefts = generateTrees(lowerIdx - 1, offset, leaves);
                var rights = generateTrees(size - lowerIdx, lowerIdx + offset, leaves);

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

    public IList<TreeNode> GenerateTrees(int n)
    {
        var builder = ImmutableArray.CreateBuilder<TreeNode>(n + 1);
        for (var i = 0; i <= n; i++)
            builder.Add(new TreeNode(i, null, null));
        var leaves = builder.MoveToImmutable();

        var trees = generateTrees(n, 0, leaves);

        return trees;
    }
}