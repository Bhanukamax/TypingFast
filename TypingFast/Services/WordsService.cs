using System.Reflection;

namespace TypingFast.Services;

public class WordsService
{
    private readonly string[] _words;

    public WordsService()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "TypingFast.words.txt";

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream))
        {
            var content = reader.ReadToEnd();
            _words = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    public string[]? GetWords(int count)
    {
        var random = new Random();
        return _words.OrderBy(x => random.Next()).Take(count).ToArray();
    }
}