public static class ArrayExtension
{
    public static (T[], T[]) Split<T>(this T[] array, int splitIndex)
    {
        if (splitIndex >= 0 && splitIndex < array.Length)
        {
            var left = new T[splitIndex+1];
            var right = new T[array.Length - 1 - splitIndex];

            for(var i = 0; i < array.Length; i++)
            {
                if (i <= splitIndex)
                    left[i] = array[i];
                else
                    right[i - splitIndex - 1] = array[i];
            }

            return (left, right);
        }

        throw new ArgumentOutOfRangeException($"splitIndex {splitIndex} is out of range. ");
    }
}


public class Solution {
    
    private int[] mergeSort(int[] nums) {
        
        if(nums.Length <= 1) return nums;
        
        var (left, right) = nums.Split(nums.Length/2-1);
        
        var leftSorted = mergeSort(left);
        
        var rightSorted = mergeSort(right);
        
        return merge(leftSorted, rightSorted);
        
    }
    
    private int[] merge(int[]leftSorted, int[] rightSorted) {
        
        var merged = new int[leftSorted.Length + rightSorted.Length];
        
        var mergedIdx = 0;
        var leftIdx = 0;
        var rightIdx = 0;
        
        while(leftIdx < leftSorted.Length && rightIdx < rightSorted.Length) {
            
            var left = leftSorted[leftIdx];
            var right = rightSorted[rightIdx];
            
            if (left <= right) {
                merged[mergedIdx++] = left;
                leftIdx++;
            }
            else {
                merged[mergedIdx++] = right;
                rightIdx++;
            }    
        }
        
        while (leftIdx < leftSorted.Length) {
            merged[mergedIdx++] = leftSorted[leftIdx++];
        }
        
        while (rightIdx < rightSorted.Length) {
            merged[mergedIdx++] = rightSorted[rightIdx++];
        }
        
        return merged;
        
    }
    
    public int[] SortArray(int[] nums) {
        return mergeSort(nums);
    }
}