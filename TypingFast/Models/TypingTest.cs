using TypingFast.Services;

namespace TypingFast.Models;

public class TypingTest
{
    private readonly WordsService _wordsService;
    private List<string> _words;

    public TypingTest(WordsService wordsService)
    {
        _wordsService = wordsService;
        _words = _wordsService.GetWords(10).ToList();
    }

    public List<int> WrongIndexes { get; set; } = new();

    public int CurrentIndex { get; private set; }

    public string[] GetWords()
    {
        return _words.ToArray();
    }

    public bool MatchCurrentWord(string matchString)
    {
        var currentWord = _words[CurrentIndex];
        return currentWord.Substring(0, matchString.Length) == matchString;
    }

    public void ConsumeWord(string word)
    {
        if (_words[CurrentIndex] != word) WrongIndexes.Add(CurrentIndex);

        CurrentIndex++;
    }

    public void Restart()
    {
        CurrentIndex = 0;
        _words = _wordsService.GetWords(10).ToList();
        WrongIndexes = new List<int>();
    }
}