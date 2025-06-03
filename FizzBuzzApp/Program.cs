using System;
using System.Collections.Generic;
using System.Linq;

// See https://aka.ms/new-console-template for more information
public class Rule
{
    public int Key { get; set; }
    public string Value { get; set; }
    public bool IsExclusive { get; set; }
    
    public Rule(int key, string value, bool isExclusive = false)
    {
        Key = key;
        Value = value;
        IsExclusive = isExclusive;
    }
}

public class FizzBuzzService
{
    private readonly List<Rule> _rules;
    
    public FizzBuzzService()
    {
        _rules = new List<Rule>
        {
            new Rule(3, "Fizz"),
            new Rule(5, "Buzz"),
            new Rule(7, "Flavio", true), // Regra exclusiva
            new Rule(21, "Flavioo", true) // Regra exclusiva
        };
    }
    
    public FizzBuzzService(Dictionary<int, string> customRules)
    {
        _rules = customRules.Select(r => new Rule(r.Key, r.Value)).ToList();
    }
    
    public FizzBuzzService(List<Rule> customRules)
    {
        _rules = customRules;
    }
    
    public string GetFizzBuzzValue(int number)
    {
        // Versão com LINQ (mais avançada, com prioridade para regras exclusivas):
        // var exclusiveRule = _rules.Where(rule => rule.IsExclusive && number % rule.Key == 0)
        //                           .OrderBy(rule => rule.Key)
        //                           .FirstOrDefault();
        // if (exclusiveRule != null)
        //     return number + " " + exclusiveRule.Value;
        // var ruleTexts = string.Join("", 
        //     _rules.Where(rule => !rule.IsExclusive && number % rule.Key == 0)
        //           .Select(rule => rule.Value));
        // return ruleTexts == "" ? number.ToString() : number + " " + ruleTexts;
        
        // Verificar regras exclusivas primeiro (menor Key tem prioridade)
        foreach (var rule in _rules.Where(r => r.IsExclusive).OrderBy(r => r.Key))
        {
            if (number % rule.Key == 0)
                return number + " " + rule.Value;
        }
        
        // Processar regras normais (sem espaços entre elas)
        string ruleResults = "";
        foreach (var rule in _rules.Where(r => !r.IsExclusive))
        {
            if (number % rule.Key == 0)
                ruleResults += rule.Value;
        }
        
        return ruleResults == "" ? number.ToString() : number + " " + ruleResults;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var fizzBuzzService = new FizzBuzzService();
        
        for (int i = 1; i <= 30; i++)
        {
            Console.WriteLine(fizzBuzzService.GetFizzBuzzValue(i));
        }
    }
}
