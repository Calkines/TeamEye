using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TeamEye.Core.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizarString(this string input)
        {
            return new string(input.Normalize(NormalizationForm.FormD)
                                              .ToCharArray()
                                              .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                              .ToArray()).ToUpper();
        }
    }
}
