using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordLibrary;

namespace PasswordLibraryTests
{
    [TestClass]
    public class PasswordStrengthCheker
    {
        /// <summary>
        /// Верних регистр 1, нижний регистр 1, цифра 1, спецсимвол 1, длина строки > 7 (сложность 5)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_AllChars_5Points()
        {
            //arrange
            string password = "P2ssw0rd#";
            int expected = 5;
            //act
            int actual = PasswordClass.PasswordStrengthCheker(password);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Верних регистр 1, нижний регистр 1, за длину строки 1 (сложность 4)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_UpperCase_5Points()
        {
            //arrange
            string password = "Password";
            int expected = 4;
            //act
            int actual = PasswordClass.PasswordStrengthCheker(password);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Верних регистр 1, нижний регистр 1, за длину строки 1, цифра 1 (сложность 4)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_ContainsNumbers_4Points()
        {
            //arrange
            string password = "Passw0ord";
            int expected = 4;
            //act
            int actual = PasswordClass.PasswordStrengthCheker(password);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Верних регистр 1, нижний регистр 1, за длину строки 1, цифра 1, спецсимвол 1 (сложность 5)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_ContainsSpecialChar_4Points()
        {
            //arrange
            string password = "Passw0rd@";
            int expected = 5;
            //act
            int actual = PasswordClass.PasswordStrengthCheker(password);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// пустая строка
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_EmptyString_4Points()
        {
            //arrange
            string password = String.Empty;
            int expected = 0;
            //act
            int actual = PasswordClass.PasswordStrengthCheker(password);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// криллица
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_KirillicaString_4Points()
        {
            //arrange
            string password = "Акуьплоуткь";

            //act
            Action actual = () => new PasswordClass().PasswordStrengthCheker(password);
            //assert
            Assert.ThrowsException<ArgumentException>(actual);
        }
    }
}
