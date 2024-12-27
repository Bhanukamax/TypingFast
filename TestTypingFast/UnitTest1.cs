using TypingFast.Services;

namespace TestTypingFast;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var wordsService = new WordsService();
        var result = wordsService.GetWords(2);
        Assert.Equal(2, result.Length);
    }
}