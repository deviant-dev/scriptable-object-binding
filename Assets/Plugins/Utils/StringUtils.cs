using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Deviant.Utils {
	public static class StringUtils {
		/// <summary>
		///   Parses out a string (e.g. file name or camel case ID) into a readable name.
		/// </summary>
		/// <param name="text">The text to convert.</param>
		/// <param name="capitalize">If true, will capitalize the first character of words.</param>
		/// <param name="removeNumbers">If true, will remove numbers.</param>
		/// <returns>The converted human-readable string.</returns>
		public static string ToSpacedName(this string text,
										bool capitalize = true,
										bool removeNumbers = true,
										bool removeSingleLetters = true) {
			text = text.ReplaceRegex(@"[A-Z][a-z]", " $0").ReplaceRegex(@"([0-9])([A-Za-z])|([A-Za-z])([0-9])", "$1$3 $2$4");

			if (removeNumbers) {
				string[] testArray =
					text.Split(new[] {' ', '\t', '.', '_', '#', '$', '%', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'},
								StringSplitOptions.RemoveEmptyEntries);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < testArray.Length; i++) {
					if (testArray[i].Length <= 1 && removeSingleLetters) { continue; }
					if (sb.Length != 0) { sb.Append(" "); }
					sb.Append(testArray[i]);
				}
				text = sb.ToString();
			}
			else if (removeSingleLetters) {
				string[] testArray = text.Split(new[] {' ', '\t', '.', '_', '#', '$', '%'}, StringSplitOptions.RemoveEmptyEntries);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < testArray.Length; i++) {
					if (testArray[i].Length == 1 && !char.IsDigit(testArray[i][0])) { continue; }
					if (sb.Length != 0) { sb.Append(" "); }
					sb.Append(testArray[i]);
				}
				text = sb.ToString();
			}

			return capitalize ? text.ToCapitalized().Trim() : text.Trim();
		}

		/// <summary>
		///   Capitalizes the first letter of each word in the supplied string.
		/// </summary>
		/// <param name="text">The text to capitalize.</param>
		/// <returns>The text with capitalized first characters.</returns>
		public static string ToCapitalized(this string text, bool invariant = false) {
			return invariant
						? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text)
						: CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
		}

		/// <summary>
		///   A convenience extension version of Regex.Replace.
		/// </summary>
		/// <param name="input">The string to search for a match.</param>
		/// <param name="pattern">The regular expression pattern to match.</param>
		/// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>
		///   A new string that is identical to the input string, except that the replacement string takes the place of each
		///   matched string.
		/// </returns>
		public static bool ContainsRegex(this string input, string pattern, RegexOptions options = RegexOptions.None) { return Regex.IsMatch(input, pattern, options); }

		/// <summary>
		///   A convenience extension version of Regex.Replace.
		/// </summary>
		/// <param name="input">The string to search for a match.</param>
		/// <param name="pattern">The regular expression pattern to match.</param>
		/// <param name="replacement">The replacement string.</param>
		/// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>
		///   A new string that is identical to the input string, except that the replacement string takes the place of each
		///   matched string.
		/// </returns>
		public static string ReplaceRegex(this string input,
										string pattern,
										string replacement,
										RegexOptions options = RegexOptions.None) {
			return Regex.Replace(input, pattern, replacement, options);
		}

		[ContractAnnotation("s:null => true")]
		public static bool IsNullOrEmpty(this string s) { return string.IsNullOrEmpty(s); }
	}
}