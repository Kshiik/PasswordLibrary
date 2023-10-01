using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordLibrary
{
    public class PasswordClass
    {
        /// <summary>
        /// проверка сложности пароля
        /// </summary>
        /// <param name="password">пароль</param>
        /// <returns>
        /// числовое значение сложности пароля
        /// </returns>
        public static int PasswordStrengthCheker(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return 0;
            }
            int result = 0;

            // если пароль имеет длину больше 7 символов сложность повышается на 1 балл
            if (password.Length>7)
            {
                result++;
            }
            //если пароль содержит цифры, то сложность повышается ещё на 1 балл
            if (Regex.Match(password, "[0-9]").Success)
            {
                result++;
            }
            //если пароль содержит латинские буквы в нижнем регистре, то сложность повышается ещё на 1 балл
            if (Regex.Match(password, "[a-z]").Success)
            {
                result++;
            }
            //если пароль содержит Заглавные латинские буквы, то сложность повышается ещё на 1 балл
            if (Regex.Match(password, "[A-Z]").Success)
            {
                result++;
            }
            //если пароль содержит спецсимволы, то сложность повышается ещё на 1 балл
            if (Regex.Match(password, "[\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\-\\=\\_\\+\\[\\]\\{\\}\\;\\:\\'\\,\\.]").Success)
            {
                result++;
            }
            //если пароль содержит кириллические символы,
            //то выдается исключение «Кириллические символы запрещены при вводе пароля»
            if (Regex.Match(password, "[а-яА-ЯёЁ]").Success)
            {
                throw new Exception("Кириллические символы запрещены при вводе пароля");
            }

            return result;

        }
    }
}
