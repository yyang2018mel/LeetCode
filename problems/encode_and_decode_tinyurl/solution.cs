public class Codec 
{
    private Random rand = new Random();
    private Dictionary<string, string> _urlLookup = new Dictionary<string, string>();
    private string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    private string GetRandomeString()
    {
        var randStr = "";
        for(var i = 0; i < 6; i++)
        {
            var randInt = rand.Next(0, 62);
            randStr += alphabet[randInt];
        }
        return randStr;
    }
    
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) 
    {
        var shortUrl = GetRandomeString();
        while(_urlLookup.ContainsKey(shortUrl))
            shortUrl = GetRandomeString();
        
        _urlLookup[shortUrl] = longUrl;
        return @"http://tinyurl.com/" + shortUrl;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) 
    {
        shortUrl = shortUrl.Replace(@"http://tinyurl.com/","");
        return _urlLookup[shortUrl];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));