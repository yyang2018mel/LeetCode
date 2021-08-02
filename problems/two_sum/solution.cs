public class Solution
    {
        class PointerComparer : IComparer<int>
        {
            private Solution solver;

            internal PointerComparer(Solution solver)
            {
                this.solver = solver;
            }

            public int Compare(int lhs, int rhs)
            {
                return solver.nums[lhs].CompareTo(solver.nums[rhs]);
            }
        }

        class CrossComparer : IComparer<int>
        {
            private Solution solver;

            internal CrossComparer(Solution solver)
            {
                this.solver = solver;
            }

            public int Compare(int lhs, int rhs)
            {
                return solver.nums[lhs].CompareTo(rhs);
            }
        }

        private int[] nums;
        private int[] pointerArray;
        public int[] TwoSum(int[] nums, int target)
        {
            this.nums = nums;
            pointerArray = Enumerable.Range(0, nums.Length).ToArray();
            Array.Sort(pointerArray, new PointerComparer(this));

            for (var idx = 0; idx < pointerArray.Length; idx++)
            {
                var pointer = pointerArray[idx];
                var fixed_ = nums[pointer];
                var composite = target - fixed_;

                if (fixed_ == composite)
                {
                    if (idx + 1 < pointerArray.Length && nums[pointerArray[idx + 1]] == composite)
                        return new int[] { pointer, pointerArray[idx + 1] };
                    else
                        continue;
                }
                    
                var search = Array.BinarySearch(pointerArray, composite, new CrossComparer(this));

                if (search > 0 && search != idx)
                    return new int[] { pointer, pointerArray[search] };
            }

            throw new NotSupportedException();
        }
    }