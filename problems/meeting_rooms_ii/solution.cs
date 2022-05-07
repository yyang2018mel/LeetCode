public class Solution 
{
    public int MinMeetingRooms(int[][] meetingSortedByStart) 
    {
        var meetingComparer =
            Comparer<int[]>.Create((lhs, rhs) => lhs[0] - rhs[0]);
        
        Array.Sort(meetingSortedByStart, meetingComparer);
        
        var roomInUse = new PriorityQueue<int, int>();
            
        foreach(var meeting in meetingSortedByStart)
        {
            var meetingStart = meeting[0];
            var meetingFinish = meeting[1];
            
            if (roomInUse.TryPeek(out _, out int earliestEndingTime) && meetingStart >= earliestEndingTime)
            {
                var roomNumber = roomInUse.Dequeue();
                roomInUse.Enqueue(roomNumber, meetingFinish);
                continue;
            }
            roomInUse.Enqueue(roomInUse.Count+1, meetingFinish);
        }
        
        return roomInUse.Count;
    }
}