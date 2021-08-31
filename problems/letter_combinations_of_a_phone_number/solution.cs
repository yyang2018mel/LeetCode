using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private static Dictionary<char, IList<string>> mapping = new Dictionary<char, IList<string>>
    {
        { '2', new List<string> { "a", "b", "c" } },
        { '3', new List<string> { "d", "e", "f" } },
        { '4', new List<string> { "g", "h", "i" } },
        { '5', new List<string> { "j", "k", "l" } },
        { '6', new List<string> { "m", "n", "o" } },
        { '7', new List<string> { "p", "q", "r", "s" } },
        { '8', new List<string> { "t", "u", "v" } },
        { '9', new List<string> { "w", "x", "y", "z" } }
    };


    private IEnumerable<string> LetterCombination(string digits, int head)
    {
        var result = new List<string>();

        if(head == digits.Length)
            return result;

        var commonTail = LetterCombination(digits, head + 1);

        foreach (var m in mapping[digits[head]])
        {
            result.AddRange(commonTail.DefaultIfEmpty("").Select(t => m + t));
        }

        return result;
    }


    public IList<string> LetterCombinations(string digits)
    {
        return LetterCombination(digits, 0).ToList();
    }
}