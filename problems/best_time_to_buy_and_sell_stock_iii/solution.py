from typing import List

class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        numState = 5
        valueMatrix = [[-float('inf')]*numState]*2
        valueMatrix[0][0] = 0

        for p in prices:
            today, prevDay = 1, 0
            for j in range(numState):
                prevState = max(0, j-1)
                valueMatrix[today][j] = max(
                    valueMatrix[prevDay][j],
                    valueMatrix[prevDay][prevState] + (
                        p if j in [2,4] else -p
                    )
                )
        valuesWhen0Position = [
            valueMatrix[1][0], 
            valueMatrix[1][2],
            valueMatrix[1][4]]

        return max(valuesWhen0Position)