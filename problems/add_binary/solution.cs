public class Solution 
{
    public string AddBinary(string a, string b) 
    {
        if (a == "" || b == "") return a+b;
        
        var lsbA = a[a.Length-1];
        var lsbB = b[b.Length-1];

        var lastDigitThisRound = 
            lsbA == lsbB ? "0" : "1";
        
        var remA = AddBinary(a.Substring(0, Math.Max(0, a.Length-1)),
                   (lsbA == '1' && lsbB == '1' ? "1" : ""));
        
        var remB = b.Substring(0, Math.Max(0, b.Length-1));
        
        return AddBinary(remA, remB) + lastDigitThisRound;
    }
}