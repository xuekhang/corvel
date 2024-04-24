using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserTest
{
    class StringParser
    {
        public IEnumerable<TokenAction> Parse(string input, TokenAction[] tokenActions)
        {
            List<TokenAction> result = new List<TokenAction>();

            int start = -1; // Start index of current token
            int length = 0; // Length of current token
            if (input == null) return Enumerable.Empty<TokenAction>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLetterOrDigit(c))
                {
                    if (start == -1)
                    {
                        start = i; // Start a new token
                        length = 1;
                    }
                    else
                    {
                        length++; // Continue current token
                    }
                }
                else if (start != -1) // End of token
                {
                    string token = input.Substring(start, length);
                    TokenAction action = tokenActions.FirstOrDefault(t => t.Name.Equals(token, StringComparison.OrdinalIgnoreCase));
                    if (action != null)
                    {
                        result.Add(action);
                    }
                    start = -1; // Reset start index
                }
            }

            // Check for token at the end of the input
            if (start != -1)
            {
                string token = input.Substring(start, length);
                TokenAction action = tokenActions.FirstOrDefault(t => t.Name.Equals(token, StringComparison.OrdinalIgnoreCase));
                if (action != null)
                {
                    result.Add(action);
                }
            }

            return result;
        }
    }
}
