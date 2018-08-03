using System;
using System.Linq;
using P03_Telephony.Interfaces;

namespace P03_Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string inputString)
        {
            var numbers = inputString.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(this.ValidateNumbers)
                .ToArray();

            return string.Join(Environment.NewLine, numbers);
        }

        private string ValidateNumbers(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return $"Invalid number!";
                }
            }

            return $"Calling... {input}";
        }

        public string Browse(string inputString)
        {
            var urls = inputString
                .Split(new[] { ' ' })
                .Select(this.ValidateUrl)
                .ToArray();

            return string.Join(Environment.NewLine, urls);
        }

        private string ValidateUrl(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    return $"Invalid URL!";
                }
            }

            return $"Browsing: {input}!";
        }
    }
}