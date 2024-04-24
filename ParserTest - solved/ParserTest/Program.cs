using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserTest
{
	class Program
	{
		private static readonly string[][] TEST_DATA = new string[][]
		{
			new []{ "", "" },
			new []{ (string)null, "" },
			new []{ "test Test", "-1,-1"},
			new []{ "\t\r\ntest\t TeSt", "-1,-1"},
			new []{ "!@#$test1__TeSt2%^&*", "2,11"},
			new []{ "()^%$test1__TeSt2--&*tes3t", "2,11"},
			new []{ "!@#$1234test__TeSt++^-*tes3t==", "-1"},
		};

		private static readonly TokenAction[] TOKEN_ACTIONS = new[]
		{
			new TokenAction{ Name = "test", Code = -1},
			new TokenAction{ Name = "test1", Code = 2},
			new TokenAction{ Name = "test2", Code = 11},
			new TokenAction{ Name = "test3", Code = 44}
		};


		static void Main(string[] args)
		{
			// Problem:
			// Update StringParser Parse() method so it would return list of actions matching specified tokens from the supplied input string.
			// Each token should be continuous sequence of alphanumeric characters.
			// The sample TEST_DATA are given above, please feel free to extend it if neccessary.
			// The current implementation passes 2 first cases but fails the rest.
			// Please ensure the implementation is production quality- simple, easy to maintain, doesn't allocate unnecessary memory and has performance O(n) where n- length of the input string. The current implementation does not meet these requirements.
			// Please do not use Regex to parse input string.

			StringParser parser = new StringParser();

			for (int i = 0; i < TEST_DATA.Length; i++)
			{
				string[] data = TEST_DATA[i];

				string s = data[0];

				try
				{
					IEnumerable<TokenAction> lst = parser.Parse(s, TOKEN_ACTIONS);

					if (data[1] == string.Join(",", lst.Select(t => t.Code.ToString())))
					{
						Console.WriteLine($"{i}: passed ...");
					}
					else
					{
						Console.WriteLine($"{i}: not passed ...");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"{i}: error: '{ex.Message}'");
				}
			}

			Console.ReadLine();
		}
	}

	class TokenAction
	{
		public string Name { get; set; }

		public int Code { get; set; }
	}
}
