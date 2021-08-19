public class Solution
{
    private int[] merge(int[] nums1, int[] nums2)
    {
        var merged = new int[nums1.Length + nums2.Length];
        var idx = 0;
        var idx1 = 0;
        var idx2 = 0;

        while(idx1 < nums1.Length && idx2 < nums2.Length)
        {
            if (nums1[idx1] < nums2[idx2])
            {
                merged[idx++] = nums1[idx1];
                idx1++;
            }
            else if (nums1[idx1] > nums2[idx2])
            {
                merged[idx++] = nums2[idx2];
                idx2++;
            }
            else
            {
                merged[idx++] = nums1[idx1];
                merged[idx++] = nums2[idx2];
                idx1++;
                idx2++;
            }
        }

        if(idx1 == nums1.Length)
        {
            while(idx2 < nums2.Length)
            {
                merged[idx++] = nums2[idx2++];
            }
        }
        else if(idx2 == nums2.Length)
        {
            while(idx1 < nums1.Length)
            {
                merged[idx++] = nums1[idx1++];
            }
        }

        return merged;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int mergedLen = nums1.Length + nums2.Length;
        int[] merged = merge(nums1, nums2);

        if (mergedLen % 2 != 0)
        {
            return merged[mergedLen / 2];
        }
        else
        {
            var idx1 = mergedLen / 2 - 1;
            var idx2 = idx1 + 1;
            return (merged[idx1] + merged[idx2]) / 2.0;
        }            
    }
}