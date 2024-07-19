using DynamicData.Annotations;
using System;
using System.Linq;

namespace ClientApp
{
    public class Validation
    {
        /// <summary>
        /// провекра имени
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsStringWithoutDigits(string input)
        {
            return !input.Any(char.IsDigit);
        }
        /// <summary>
        /// проверка GUID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsStringGuid(string input)
        {
            return Guid.TryParse(input, out _);
        }
    }
}
