using System;

namespace PrintDiamond
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintDiamond printDiamond = new PrintDiamond();
            Console.WriteLine("Please enter a letter between A and Z ");
            char userLetter = Console.ReadKey().KeyChar;
            Console.WriteLine();
            printDiamond.PrintCharactersInDiamond(userLetter);
        }
    }
}
