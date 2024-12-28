using System.Diagnostics;
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
        {
            Debug.Assert(stream != null, nameof(stream) + " != null");
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                _words = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }

    public string[] GetWords(int count)
    {
        var random = new Random();
        return _words.OrderBy(_ => random.Next()).Take(count).ToArray();
    }
}