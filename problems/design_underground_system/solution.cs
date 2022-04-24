internal record Registration(string Station, int Time);

internal record InAndOut(string In, string Out);

internal record AvgInfo(double Average, int Frequency);

public class UndergroundSystem 
{
    private Dictionary<int, Registration> _checkedInCustomers;
    
    private Dictionary<InAndOut, AvgInfo> _averageTime;
    
    public UndergroundSystem() 
    {
        _checkedInCustomers = new Dictionary<int, Registration>();
        _averageTime = new Dictionary<InAndOut, AvgInfo>();
    }
    
    public void CheckIn(int id, string stationName, int t) 
    {
        if (!_checkedInCustomers.ContainsKey(id))
        {
            _checkedInCustomers[id] = new Registration(stationName, t);
        }
    }
    
    public void CheckOut(int id, string stationName, int t) 
    {
        if (_checkedInCustomers.TryGetValue(id, out var registration))
        {
            var elapsed = t - registration.Time;
            var inAndOut = new InAndOut(registration.Station, stationName);
            if(_averageTime.TryGetValue(inAndOut, out var avgInfo))
            {
                var newFrequency = avgInfo.Frequency + 1;
                var newAvg = (double)(avgInfo.Average * avgInfo.Frequency + elapsed) / newFrequency;
                _averageTime[inAndOut] = new AvgInfo(newAvg, newFrequency);
            }
            else
            {
                _averageTime[inAndOut] = new AvgInfo(elapsed, 1);
            }
            
            _checkedInCustomers.Remove(id);
        }
    }
    
    public double GetAverageTime(string startStation, string endStation) 
    {
        var key = new InAndOut(startStation, endStation);
        
        if (_averageTime.TryGetValue(key, out var avgInfo))
        {
            return avgInfo.Average;
        }
        
        throw new ApplicationException("Invalid Operation");
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */