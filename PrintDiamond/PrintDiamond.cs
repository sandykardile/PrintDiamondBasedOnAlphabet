using System;
using System.Linq;

namespace PrintDiamond
{
    public class PrintDiamond
    {
        public string[] diamondLetter;
        public void PrintCharactersInDiamond(char userLetter)
        {
            if (Char.IsLetter(userLetter))
            {
                if (!string.Equals(userLetter.ToString(), "A", StringComparison.OrdinalIgnoreCase))
                {
                    diamondLetter = CreateDiamondArray(userLetter);
                    //Display Array in Correct order.
                    for (int i = 0; i < diamondLetter.Length; i++)
                    {
                        Console.WriteLine(diamondLetter[i]);
                    }
                }
                else
                {
                    Console.WriteLine("A");
                }
            }
            else
            {
                Console.WriteLine("Provided input is not a Letter");
            }
        }

        public string[] CreateDiamondArray(char userLetter)
        {
            char emptySpaceChar = ' ';
            char[] letterList = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();
            int letterNumber = userLetter.ToString().ToUpper().TextToNumber();

            //Construct array with exact lenght
            int arrayCount = (2 * letterNumber) + 1;
            string[] firstHalfDiamondList = new string[letterNumber + 1];

            //construct diamond 
            for (int i = 0; i <= letterNumber; i++)
            {
                string letter = letterList[i].ToString();
                int spaceCountToAppendAtStartEnd = letterNumber + 1 - i;
                //add space before Letter and Letter
                firstHalfDiamondList[i] = letter.PadLeft(spaceCountToAppendAtStartEnd, emptySpaceChar);
                //add space between letters and letter
                if (!string.Equals(letter, "A", StringComparison.OrdinalIgnoreCase))
                {
                    firstHalfDiamondList[i] += letter.PadLeft(2 * i, emptySpaceChar);
                }
                //add space after Letter... (PadRight only works when padding count is greater than the length of String)
                int spaceCountAddedEndofString = (firstHalfDiamondList[i].Length-1) + spaceCountToAppendAtStartEnd;
                firstHalfDiamondList[i] = firstHalfDiamondList[i].PadRight(spaceCountAddedEndofString, emptySpaceChar); 
            }
            //Reverse array and append in same array.
            var secondHalfDiamondList = firstHalfDiamondList.Reverse().Skip(1);
            var diamondList = firstHalfDiamondList.Concat(secondHalfDiamondList).ToArray();
            return diamondList;
        }
    }
}
