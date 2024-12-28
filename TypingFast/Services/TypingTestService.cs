using TypingFast.Models;

namespace TypingFast.Services;

public class TypingTestService
{
    public static TypingTest NewTest()
    {
        var wordsService = new WordsService();
        var test = new TypingTest(wordsService);
        return test;
    }
}