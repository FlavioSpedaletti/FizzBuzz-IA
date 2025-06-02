using System;
using System.Collections.Generic;
using System.Linq;

// See https://aka.ms/new-console-template for more information
public class FizzBuzzService
{
    private readonly Dictionary<int, string> _rules;
    
    public FizzBuzzService()
    {
        _rules = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" },
            { 7, "Flavio" }
        };
    }
    
    public FizzBuzzService(Dictionary<int, string> customRules)
    {
        _rules = customRules;
    }
    
    public string GetFizzBuzzValue(int number)
    {
        // Versão com LINQ (mais avançada, salva como referência):
        // var ruleTexts = string.Join(" ", 
        //     _rules.Where(rule => number % rule.Key == 0)
        //           .Select(rule => rule.Value));
        // string result = ruleTexts == "" ? number.ToString() : number + " " + ruleTexts;
        
        // Versão simples com foreach:
        string result = number.ToString();
        foreach (var rule in _rules)
        {
            if (number % rule.Key == 0)
                result += " " + rule.Value;
        }
        
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var fizzBuzzService = new FizzBuzzService();
        
        for (int i = 1; i <= 105; i++)
        {
            Console.WriteLine(fizzBuzzService.GetFizzBuzzValue(i));
        }
    }
}
