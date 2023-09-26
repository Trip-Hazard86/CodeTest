using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace CodeTest
{
    public class TestThree
    {
        public TestThree()
        {
            ConsoleLog.LogHeader("Test 3 Begin");

            this.ParseString();

            ConsoleLog.LogHeader("Test 3 End");
        }

        /// <summary>
        /// This should print the required outcomes in order.
        /// </summary>
        public void ParseString()
        {
            string value = "B2et_74fr5e9d3681!";

            ConsoleLog.LogSub("Test 3: Parse String");

            //TODO: Remove the non-alphanumeric characters

            value = value.Replace("_", "");
            value = value.Replace("!", "");

            ConsoleLog.LogResult($"String only alphanumeric: {value}");
            //TODO: Print the numbers in order

            List<int> numbers = new List<int>();
            
            //treat string as array of chars
            //cast c as string, then parse as int so compat with list
            foreach (char c in value)
            {
                if (Char.IsDigit(c))
                {
                    numbers.Add(int.Parse(c.ToString()));
                }                               
            }
            
            var orderedNumbers = numbers.OrderBy(x => x).ToList();

            ConsoleLog.LogResult("Numbers in order:");

            foreach (int number in orderedNumbers)
            {
                ConsoleLog.LogResult(number.ToString());
            }


            //TODO: Print the remianing non numeric characters in the current order, in uppercase.

            string onlyUpper = "";

            foreach (char c in value)
            {
                if (Char.IsLetter(c))
                {
                    onlyUpper += c.ToString().ToUpper();
                }
            }

            ConsoleLog.LogResult($"Uppercase letters only: {onlyUpper}");

            ConsoleLog.LogSub("Test 3 End: Parse String");
        }
    }
}
