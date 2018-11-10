class Solution:
    def twoSum(self, nums, target):
        value_dict = dict()
        for i in range(len(nums)):
            v = nums[i]
            complement = target - v
            if complement in value_dict:
                return [value_dict[complement], i]
            else:
                value_dict[v] = i
    
        