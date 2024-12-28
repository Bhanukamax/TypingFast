using System.Reflection.Metadata;
using TypingFast.Services;

namespace TypingFast.Models;

public enum TestStatus
{
    Waiting,
    Running,
    Ended,
}

public class TypingTest
{
    private readonly WordsService _wordsService;
    private List<string> _words;
    public TestStatus Status { get; private set; } = TestStatus.Waiting;
    public bool InputError { get; private set; }

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
    

    public void CheckWord(string matchString, bool isLastWord)
    {
        if (Status == TestStatus.Waiting)
        {
            Status = TestStatus.Running;
        }

        if (matchString == "")
        {
            InputError = false;
            return;
        }

        var currentWord = _words[CurrentIndex];
        if (isLastWord && currentWord == matchString)
        {
            ConsumeWord(currentWord);
            CompleteTest();
            return;
        }

        if (matchString.Length > currentWord.Length)
        {
            InputError = true;
            return;
        }

        InputError = currentWord.Substring(0, matchString.Length) != matchString;
    }

    private void CompleteTest()
    {
        Status = TestStatus.Ended;
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
        InputError = false;
        Status = TestStatus.Waiting;
    }
}