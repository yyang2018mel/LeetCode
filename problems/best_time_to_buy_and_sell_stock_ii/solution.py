class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        lenP = len(prices)
        if lenP in [0, 1]:
            return 0
        cumProfit = 0
        for i in range(0, lenP-1):
            pnl = max(0, prices[i+1]-prices[i])
            cumProfit += pnl
        return cumProfit
        