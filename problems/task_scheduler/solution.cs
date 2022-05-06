public class Solution 
{
    public int LeastInterval(char[] tasks, int n) 
    {
        if (n == 0) return tasks.Length;
        
        var tasksGroupedByFreq = 
            tasks
            .GroupBy(t => t)
            .Select(g => (g.Key, g.Count()));
        
        var runnableTaskQueue = 
            new PriorityQueue<char, int>(tasksGroupedByFreq, Comparer<int>.Create((lhs, rhs) => rhs - lhs));
        
        var holdingState =
            new Dictionary<char, (int RemFreq, int RemHolding)>();
        
        var time = 0;
        
        while(runnableTaskQueue.Count > 0 || holdingState.Count > 0)
        {
            // update holdingState and if necessary, update runableTaskQueue
            foreach(var taskOnHold in holdingState.Keys)
            {
                var (remFreq, remHoldingTime) = holdingState[taskOnHold];
                if (remHoldingTime == 0)
                {
                    holdingState.Remove(taskOnHold);
                    runnableTaskQueue.Enqueue(taskOnHold, remFreq);
                }
                else
                {
                    holdingState[taskOnHold] = (remFreq, remHoldingTime-1); // reduce holding time by 1
                }
            }
            
            // if anything runnable, run
            if (runnableTaskQueue.TryDequeue(out var task, out var taskFreq))
            {
                // do this task { ... }
                // Console.WriteLine(task);
                
                if (taskFreq > 1)
                {
                    // put it to hold
                    holdingState[task] = (taskFreq-1, n);
                }
            }
            else
            {
                // Console.WriteLine("idle");
            }
            
            // else, wait
            time++;
            
            // Console.WriteLine($"{runnableTaskQueue.Count}  {holdingState.Count}");
        }
            
        return time;
    }
}