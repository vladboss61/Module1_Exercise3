using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module1_Exercise3;

/// <summary>
///     Class program.
/// </summary>
internal sealed class Program
{
    public static void Main(string[] args)
    {
        ExampleWithoutParams(new string[] { "1", "2", "3" });

        ExampleParams();

        ExampleParams("1", "2", "3");

        ReadFromConsoleAndParse1();

        //ExampleChars();
        //ExampleOrderArray();
        //ExampleStringBuilder();
        //ExampleStringInterpolation();

        //Example2(ref arr);
        //ExampleChars();
        //ExampleStringBuilder();
        //ExampleUsefulStrFunctions();
    }

    public static void ExampleWithoutParams(string[] args)
    {

    }

    public static void ExampleParams(params string[] args)
    {
    }

    public static void Example1(string[] array)
    {
        if (array.Length >= 2)
        {
            array[0] += " Example1 Changed";
            array[1] += " Example1 Changed";
        }

        array = new [] { "other" };
    }

    /// <summary>
    ///     Example Function.
    /// </summary>
    /// <param name="array">The incoming array.</param>
    public static void Example2(ref string[] array)
    {
        if (array.Length >= 2)
        {
            array[0] += " Example2 Changed";
            array[1] += " Example2 Changed";
        }

        array = new[] { "other" };
    }

    public static void FuncOverloading(int valueNumber)
    {
        Console.WriteLine($"Hello I am the number {valueNumber}.");
    }

    public static void FuncOverloading(string valueStr)
    {
        Console.WriteLine($"I am the string {valueStr}.");
    }

    public static void FuncOverloading(string valueStr, int valueNumber)
    {
        Console.WriteLine($"I am the string {valueStr}.");
        Console.WriteLine($"... And I am the number {valueNumber} too.");
    }

    public static void ExampleStringBuilder()
    {
        //string is immutable type in C#.
        string example = "long text example";
        Console.WriteLine($"example: {example}");
        string subStr = example.Substring(1); // "Vlad".Substring(2) // "lad"

        //example[0] = 'a'; -- not possible to change string
        string newString = example.Replace(' ', '-'); // every operation on string create new one string based on previous.
        Console.WriteLine($"newString: {newString}");

        // StringBuilder is mutable type in C# and you is able to change string behind.
        StringBuilder builderEmpty = new StringBuilder();

        //'\0' '\r' '\n' '\t'

        var test = "text4\ror4";
        Console.WriteLine(test);
        builderEmpty.Append("text");
        builderEmpty.Append("text2");
        builderEmpty.AppendLine("text3");
        builderEmpty.Append("text4");
        builderEmpty.AppendLine("text4");
        var builderEmptyStr = builderEmpty.ToString();
        Console.WriteLine(builderEmptyStr);
        StringBuilder builder = new StringBuilder(newString);

        // You can do this.
        builder[0] = 'P';
        string buildString = builder.ToString();
        Console.WriteLine(buildString);
        Console.WriteLine($"buildString: {buildString}");
    }

    public static void ExampleStringInterpolation()
    {
        string value = "value 10";

        string strPlus = "Your String is " + value + value + value; //1
        string strPlus2 = value + " Your String is " + value; //1
        string interpolationStr = $"{value} Your String is {value}"; //2

        string formatStr = string.Format("Your String is {0}", value); //3
        string format3Str = string.Format("Your String is {0}, {1}, {2}", value, "other", "one more"); //3
        string format3InterpolationStr = $"Your String is {value}, {"other"}, {"one more"}"; //4
    }

    public static void ExampleOrderArray()
    {
        int[] array = { 1, 5, 3, 2 };

        Array.Sort(array);
        Array.Reverse(array);

        // int[] orderedAsc = array.OrderBy(x => x).ToArray();
        // int[] orderedDesc = array.OrderByDescending(x => x).ToArray();
    }

    public static void ExampleChars()
    {
        var chars = new char[] { 'a', '\0', 'b', 'c', '\0' };

        foreach (char ch in chars)
        {
            Console.WriteLine($"ch: {ch}");
            Console.WriteLine($"ch_number: {(int)ch}");
        }

        string str = new string(chars);
        foreach (char str_ch in str)
        {
            Console.WriteLine($"str_ch: {str_ch}");
            Console.WriteLine($"str_ch_number: {(int)str_ch}");
        }

        // Remove '\0' from chars

        int count = 0;
        foreach (char ch in chars)
        {
            if (ch != '\0')
            {
                count++;
            }
        }

        var newChars = new char[count];
        int index = 0;

        foreach (char ch in chars)
        {
            if (ch == '\0')
            {
                continue;
            }
            newChars[index] = ch; // fine.
            index++;
            //newChars[++index] = ch; // Exception, why ?
            //newChars[index++] = ch;

        }
        string nonEmptyCharString = new string(newChars);
        Console.WriteLine(nonEmptyCharString);
    }

    // Practice code.
    public static void ReadFromConsoleAndParse1()
    {
        string text = Console.ReadLine();
        string[] words = text.Split(" "); // "o2ne two thrф1ee4".Split(" ") -> ["one" "two" "three"]

        for (int i = 0; i < words.Length; i++)
        {
            // не парне - i % 2 != 0; i % 2 == 0 - парне
            if (i % 2 != 0)
            {
                words[i] = ReverseString(words[i]);
            }

            words[i] = RemoveDigits(words[i]);
        }

        for (var i = 0; i < words.Length; i++)
        {
            words[i] = Capitalize(words[i]);
        }
    }

    public static string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        char firstChar = char.ToUpper(input[0]); // a -> A; b -> B; "name".ToUpper() -> "NAME";
        string restOfString = input.Substring(1); // Example: "name".Substring(1) -> "ame"
        return firstChar + restOfString; // $"{firstChar}{restOfString}";
    }

    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray); // Or MyReverse(charArray);
        return new string(charArray);
    }

    public static char[] MyReverse(char[] charArray)
    {
        var reversedChars = new char[charArray.Length];
        for (int i = charArray.Length - 1, j = 0; i >= 0 && j < charArray.Length; i--, j++)
        {
            reversedChars[j] = charArray[i];
        }

        return reversedChars;
    }

    public static string RemoveDigits(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    public static void ExampleUsefulStrFunctions()
    {
        string str = "\tmessage\n   ";
        string trimStr = str.Trim();
        Console.WriteLine(trimStr);
        string withoutFirstChar = trimStr.Substring(1);
        Console.WriteLine(withoutFirstChar);
    }
}
