using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;

namespace Web.Helper
{
    public static class DataHelper
    {
        public static string RemapVniToAsciiText(string text)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = text.Normalize(NormalizationForm.FormD).ToLower();
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(' ', '-');
        }
    }
}