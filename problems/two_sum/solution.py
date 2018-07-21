class Solution:
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        numsDict = dict()
        for i in range(len(nums)):
            complement = target - nums[i]
            if complement in numsDict:
                return [i, numsDict[complement]]
            numsDict[nums[i]] = i
        