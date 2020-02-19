class Solution:
    
    def getShorterPointer(self, height: List[int], start: int, end: int) -> str:
        if height[start] >= height[end]:
            return 'end'
        else:
            return 'start'
    
    def getArea(self, height: List[int], start: int, end: int) -> int:
        h = min(height[start], height[end])
        l = end - start
        return h*l
    
    def maxArea(self, height: List[int]) -> int:
        lenH = len(height)
        start, end = 0, lenH-1
        shorter = self.getShorterPointer(height, start, end)
        currArea = self.getArea(height, start, end)
        
        while(start < end):
            newStart = start + 1 if shorter == 'start' else start
            newEnd = end - 1 if shorter == 'end' else end
            newArea = self.getArea(height, newStart, newEnd)
            start = newStart
            end = newEnd
            shorter = self.getShorterPointer(height, newStart, newEnd)
            currArea = max(currArea, newArea)
            
        return currArea
                
                
            
        
        
        
            
        
            
        