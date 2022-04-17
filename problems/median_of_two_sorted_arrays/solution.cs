public class Solution 
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        var totalLen = nums1.Length + nums2.Length;
        var halfLen = totalLen / 2;        
     
       if (nums1.Length == 0)
        return 
           totalLen % 2 != 0 
           ? (double)nums2[halfLen] 
           : (nums2[halfLen-1] + nums2[halfLen])/2.0;
        
        if (nums2.Length == 0)
            return 
            totalLen % 2 != 0 
            ? (double)nums1[halfLen] 
            : (nums1[halfLen-1] + nums1[halfLen])/2.0;
     
        var tillMedianLen = halfLen + 1;
        var nums1MinItems = Math.Max(tillMedianLen - nums2.Length, 0);
        var nums1MaxItems = Math.Min(tillMedianLen, nums1.Length);
        
        while (nums1MinItems <= nums1MaxItems)
        {
            var nums1Items = (nums1MinItems + nums1MaxItems) / 2;
            var nums2Items = tillMedianLen - nums1Items;
            
            var num1 =
                nums1Items-1 >= 0 ? nums1[nums1Items-1] : Int32.MinValue;
            
            var num1_ = 
                nums1Items < nums1.Length ? nums1[nums1Items] : Int32.MaxValue;
            
            var num2 = 
                nums2Items-1 >= 0 ? nums2[nums2Items-1] : Int32.MinValue;
            
            var num2_ = 
                nums2Items < nums2.Length ? nums2[nums2Items] : Int32.MaxValue;
            
            if (num1 >= num2)
            {
                if (num1 <= num2_)
                {
                    // find the median
                    if (totalLen % 2 != 0)
                    {
                        return (double)num1;
                    }
                    else
                    {
                        // need to find the number that is immediately smaller than num1
                        var _num1 = nums1Items-2 >= 0 ? nums1[nums1Items-2] : Int32.MinValue;
                        var immediateSmaller = Math.Max(num2, _num1);
                        return (immediateSmaller+num1)/2.0;
                    }
                    return totalLen % 2 != 0 ? (double)num1 : (num1+num2)/2.0;
                }
                else
                {
                    // need to reduce number of elements from nums1
                    nums1MaxItems = nums1Items - 1;
                }
            }
            else // (num1 < num2)
            {
                if (num2 <= num1_)
                {
                    // find the median
                    if (totalLen % 2 != 0)
                    {
                        return (double)num2;
                    }
                    else
                    {
                        // need to find the number that is immediately smaller than num2
                        var _num2 = nums2Items-2 >= 0 ? nums2[nums2Items-2] : Int32.MinValue;
                        var immediateSmaller = Math.Max(num1,_num2);
                        return (immediateSmaller+num2)/2.0;
                    }
                }
                else
                {
                    // need to increase number of elements from nums1
                    nums1MinItems = nums1Items + 1;
                }
            }
        }
        
        throw new Exception("Unexpected code path!");
    }
}