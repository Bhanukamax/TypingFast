using TypingFast.Services;
using Xunit.Abstractions;

namespace TestTypingFast;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var wordsService = new WordsService();
        var result = wordsService.GetWords(10);
        foreach (var word in result)
        {
            _testOutputHelper.WriteLine(word);
        }

        Assert.Equal(10, result.Length);
    }
}