using System.Text.RegularExpressions;
public class Solution 
{
    public string MostCommonWord(string paragraph, string[] banned) 
    {
        var bannedSet = new HashSet<string>(banned);
        var words = Regex.Split(paragraph, @"[\s!?',;.]+");
        var counter = new Dictionary<string, int>();
        
        foreach(var word_ in words)
        {
            var word = word_.ToLower();
            if(!bannedSet.Contains(word))
            {
                if(counter.TryGetValue(word, out var _))
                {
                    counter[word] += 1;
                }
                else
                {
                    counter[word] = 1;
                }
            }
        }
            
        var topWord = 
            counter
            .OrderByDescending(kv => kv.Value)
            .First()
            .Key;
        
        return topWord;
    }
}