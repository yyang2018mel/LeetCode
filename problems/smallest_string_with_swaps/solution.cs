using System.Collections.Immutable;

public class Solution
{

    class DisjointSet
    {
        private int n;
        private int[] root;
        private int[] rank;

        public ImmutableArray<int> Root =>
            Enumerable.Range(0,n).Select(e => FindRoot(e)).ToImmutableArray();

        public DisjointSet(int n)
        {
            this.n = n;
            root = Enumerable.Range(0, n).Select(i => i).ToArray();
            rank = Enumerable.Range(0, n).Select(_ => 1).ToArray();
        }

        public void Union(int lhsIdx, int rhsIdx)
        {
            var lhsRoot = FindRoot(lhsIdx);
            var rhsRoot = FindRoot(rhsIdx);

            if (rank[lhsIdx] >= rank[rhsIdx])
            {
                root[rhsRoot] = lhsRoot;
                rank[lhsIdx] += 1;
            }
            else
            {
                root[lhsRoot] = rhsRoot;
                rank[rhsRoot] += 1;
            }
        }

        public int FindRoot(int idx)
        {
            var cache = idx;
            while (idx != root[idx])
                idx = root[idx];

            root[cache] = idx;
            return idx;
        }
    }

    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        var disjointSet = new DisjointSet(s.Length);

        foreach (var pair in pairs)
        {
            disjointSet.Union(pair[0], pair[1]);
        }

        var sorted =
            disjointSet.Root
            .Select((root, i) => (root, i))
            .GroupBy(e => e.root, e => e.i)
            .SelectMany(g =>
            {
                var strIndices = g.ToList();
                var strCharsSorted = strIndices.Select(i => s[i]).OrderBy(c => c).ToArray();
                return strIndices.Select((i, metai) => (i, strCharsSorted[metai])).ToArray();
            })
            .ToDictionary(e => e.i, e => e.Item2);

            var chars = new char[s.Length];

            for (var i = 0; i < s.Length; i++)
            {
                if (sorted.TryGetValue(i, out var c))
                    chars[i] = c;
                else
                    chars[i] = s[i];
            }

            var result = new string(chars);

            return result;

    }
}