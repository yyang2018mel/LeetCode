public class Solution
{
    class Node
    {
        public string Key;
        public int Rank;
        public Node Root;
        public double Multiple; // meaning Node is "Multiple" times of its Root

        public Node(string key, int rank, Node root, double multiple)
        {
            Key = key;
            Rank = rank;
            Root = root;
            Multiple = multiple;
        }
    }

    class DisjointSet
    {
        private Dictionary<string, Node> nodes;

        public DisjointSet(int n)
        {
            nodes = new Dictionary<string, Node>();
        }

        public Node FindRoot(string nodeKey)
        {
            if (nodes.TryGetValue(nodeKey, out var node))
            {
                if (node.Root is null)
                    return node;

                var pointer = node;
                var multiple = node.Multiple;
                while (pointer.Root is not null)
                {
                    pointer = pointer.Root;
                    multiple = multiple * pointer.Multiple;
                }

                node.Root = pointer;
                node.Multiple = multiple;
                return pointer;
            }
            else
            {
                throw new Exception($"{nodeKey} does not exist in this Disjoint Set.");
            }
        }

        public void Union(string lhsKey, string rhsKey, double lhsOverRhs)
        {
            if (!nodes.TryGetValue(lhsKey, out var lhsNode))
            {
                lhsNode = new Node(lhsKey, 1, null, 1.0);
                nodes[lhsKey] = lhsNode;
            }

            if (!nodes.TryGetValue(rhsKey, out var rhsNode))
            {
                rhsNode = new Node(rhsKey, 1, null, 1.0);
                nodes[rhsKey] = rhsNode;
            }

            // both nodes are guaranteed to exist by this point

            var lhsNodeRoot = FindRoot(lhsNode.Key);
            var rhsNodeRoot = FindRoot(rhsNode.Key);

            if (lhsNodeRoot.Key == rhsNodeRoot.Key)
                return; // already in a union

            if (lhsNodeRoot.Rank >= rhsNodeRoot.Rank)
            {
                rhsNodeRoot.Root = lhsNodeRoot;
                rhsNodeRoot.Multiple = lhsNode.Multiple / lhsOverRhs / rhsNode.Multiple;
                lhsNode.Rank += 1;
                lhsNodeRoot.Rank += 1;
            }
            else
            {
                lhsNodeRoot.Root = rhsNodeRoot;
                lhsNodeRoot.Multiple = rhsNode.Multiple * lhsOverRhs / lhsNode.Multiple;
                rhsNode.Rank += 1;
                rhsNodeRoot.Rank += 1;
            }
        }

        public bool TryGetNode(string nodeKey, out Node node)
        {
            return nodes.TryGetValue(nodeKey, out node);
        }
    }


    public double[] CalcEquation(
        IList<IList<string>> equations,
        double[] values,
        IList<IList<string>> queries)
    {
        var n = values.Length;
        var disjointSet = new DisjointSet(n);

        for (var i = 0; i < n; i++)
        {
            var lhs = equations[i][0];
            var rhs = equations[i][1];
            var val = values[i];
            disjointSet.Union(lhs, rhs, val);
        }

        var results =
            queries
            .Select(query => {
                var lhsKey = query[0];
                var rhsKey = query[1];

                if (disjointSet.TryGetNode(lhsKey, out var lhs) && disjointSet.TryGetNode(rhsKey, out var rhs))
                {
                    var lhr = disjointSet.FindRoot(lhsKey);
                    var rhr = disjointSet.FindRoot(rhsKey);

                    if (lhr.Key == rhr.Key)
                        return lhs.Multiple / rhs.Multiple;
                }

                return -1.0;
            })
            .ToArray();

        return results;
    }
}