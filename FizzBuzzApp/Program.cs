// See https://aka.ms/new-console-template for more information
public class FizzBuzzService
{
    public string GetFizzBuzzValue(int number)
    {
        string result = "";
        
        if (number % 3 == 0)
            result += "Fizz";
        
        if (number % 5 == 0)
            result += "Buzz";
        
        return result == "" ? number.ToString() : result;
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
