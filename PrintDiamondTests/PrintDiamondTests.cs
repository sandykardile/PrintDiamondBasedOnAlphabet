using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace PrintCharacterInDiamondTests
{
    [TestClass]
    public class PrintDiamondTests
    {
        private readonly PrintDiamond.PrintDiamond _printDiamond;

        public PrintDiamondTests()
        {
            _printDiamond = new PrintDiamond.PrintDiamond();
        }

        [TestMethod]
        public void VerifyOnlyLetterIsAllowed_Test()
        {
            // Arrange
            char inputCharacter = '6';
            string expectedConsoleOutPut = "Provided input is not a Letter";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(inputCharacter.ToString());
            Console.SetIn(stringReader);
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert
            var output = stringWriter.ToString();
            Assert.AreEqual($"{expectedConsoleOutPut}\r\n", output);
        }

        [TestMethod]
        public void InputChar_A_Return_A_Char_Test()
        {
            // Arrange
            char inputCharacter = 'A';
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(inputCharacter.ToString());
            Console.SetIn(stringReader);
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert
            var output = stringWriter.ToString();
            Assert.AreEqual($"{inputCharacter}\r\n", output);
        }

        [TestMethod]
        public void InputChar_NotA_Return_FirstRowContain_A_Char_Test()
        {
            // Arrange
            char inputCharacter = 'C';
            string expectedConsoleOutPut = "A";            
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert
            Assert.IsTrue(_printDiamond.diamondLetter[0].Contains(expectedConsoleOutPut));
        }

        [TestMethod]
        public void InputChar_NotA_Return_InputCharecterInMiddle_Test()
        {
            // Arrange
            char inputCharacter = 'C';
            string expectedConsoleOutPut = "C";
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert
            Assert.IsTrue(_printDiamond.diamondLetter[2].Contains(expectedConsoleOutPut));
        }

        [TestMethod]
        public void InputChar_NotA_Return_AllOtherLetterOccurTwice_Test()
        {
            // Arrange
            char inputCharacter = 'D';
            char outputCharacterToVerify = 'B';
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert            
            Assert.AreEqual(2, _printDiamond.diamondLetter[1].Count(c => c == outputCharacterToVerify));
        }

        [TestMethod]
        public void InputChar_NotA_Return_AllLetterDisplayWithSpacesToFormDiamond_Test()
        {
            // Arrange
            char inputCharacter = 'D';
            string outputCharacterToVerify_A = "   A   ";
            string outputCharacterToVerify_B = "  B B  ";
            string outputCharacterToVerify_C = " C   C ";
            string outputCharacterToVerify_D = "D     D";
            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert            
            Assert.AreEqual(outputCharacterToVerify_A, _printDiamond.diamondLetter[0]);
            Assert.AreEqual(outputCharacterToVerify_B, _printDiamond.diamondLetter[1]);
            Assert.AreEqual(outputCharacterToVerify_C, _printDiamond.diamondLetter[2]);
            Assert.AreEqual(outputCharacterToVerify_D, _printDiamond.diamondLetter[3]);
        }

        [TestMethod]
        public void InputChar_NotA_Return_FullDiamomd_Test()
        {
            // Arrange
            char inputCharacter = 'D';
            string outputCharacterToVerify_A         = "   A   ";
            string outputCharacterToVerify_B         = "  B B  ";
            string outputCharacterToVerify_C         = " C   C ";
            string outputCharacterToVerify_D         = "D     D";
            string outputCharacterToVerify_Reverse_C = " C   C ";            
            string outputCharacterToVerify_Reverse_B = "  B B  ";
            string outputCharacterToVerify_Reverse_A = "   A   ";

            // Act
            _printDiamond.PrintCharactersInDiamond(inputCharacter);
            // Assert            
            Assert.AreEqual(outputCharacterToVerify_A, _printDiamond.diamondLetter[0]);
            Assert.AreEqual(outputCharacterToVerify_B, _printDiamond.diamondLetter[1]);
            Assert.AreEqual(outputCharacterToVerify_C, _printDiamond.diamondLetter[2]);
            Assert.AreEqual(outputCharacterToVerify_D, _printDiamond.diamondLetter[3]);
            Assert.AreEqual(outputCharacterToVerify_Reverse_C, _printDiamond.diamondLetter[4]);
            Assert.AreEqual(outputCharacterToVerify_Reverse_B, _printDiamond.diamondLetter[5]);
            Assert.AreEqual(outputCharacterToVerify_Reverse_A, _printDiamond.diamondLetter[6]);
            
        }
    }
}
