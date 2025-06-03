namespace FizzBuzzApp.Tests;
using System.Collections.Generic;

public class FizzBuzzServiceTests
{
    private readonly FizzBuzzService _fizzBuzzService;

    public FizzBuzzServiceTests()
    {
        _fizzBuzzService = new FizzBuzzService();
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsNotMultipleOfAnyRule_ReturnsNumber()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(1);
        Assert.Equal("1", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf3Only_ReturnsNumberFizz()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(3);
        Assert.Equal("3 Fizz", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf5Only_ReturnsNumberBuzz()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(5);
        Assert.Equal("5 Buzz", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf3And5_ReturnsNumberFizzBuzz()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(15);
        Assert.Equal("15 FizzBuzz", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf7Only_ReturnsNumberFlavio()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(7);
        Assert.Equal("7 Flavio", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf21_ReturnsNumberFlavio()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(21);
        Assert.Equal("21 Flavio", result);
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf7And3_PrioritizesSmallestExclusiveRule()
    {
        // 21 é múltiplo de 3 e 7, mas 7 é exclusivo e menor que 21
        var result = _fizzBuzzService.GetFizzBuzzValue(21);
        Assert.Equal("21 Flavio", result); // 7 tem prioridade sobre 21
    }

    [Fact]
    public void GetFizzBuzzValue_WhenNumberIsMultipleOf7And5_ReturnsOnlyFlavio()
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(35);
        Assert.Equal("35 Flavio", result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "3 Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "5 Buzz")]
    [InlineData(6, "6 Fizz")]
    [InlineData(7, "7 Flavio")]
    [InlineData(9, "9 Fizz")]
    [InlineData(10, "10 Buzz")]
    [InlineData(14, "14 Flavio")]
    [InlineData(15, "15 FizzBuzz")]
    [InlineData(21, "21 Flavio")]
    [InlineData(28, "28 Flavio")]
    [InlineData(30, "30 FizzBuzz")]
    public void GetFizzBuzzValue_WithVariousInputs_ReturnsExpectedResults(int input, string expected)
    {
        var result = _fizzBuzzService.GetFizzBuzzValue(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetFizzBuzzValue_ExclusiveRulePriority_SmallerKeyWins()
    {
        // Teste para verificar que regras exclusivas são ordenadas por Key (menor tem prioridade)
        var rules = new List<Rule>
        {
            new Rule(21, "Flavioo", true),
            new Rule(7, "Flavio", true),
            new Rule(3, "Fizz")
        };
        var service = new FizzBuzzService(rules);
        
        // 21 é múltiplo de 3, 7 e 21, mas 7 tem menor Key entre as exclusivas
        var result = service.GetFizzBuzzValue(21);
        Assert.Equal("21 Flavio", result);
    }
}
