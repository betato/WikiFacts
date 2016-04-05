using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WikiFacts;

namespace WikiFacts
{
    static class WikiParser
    {
        private const string PAGEID_STRING = "\"pageid\":";
        private const string NS_STRING = ",\"ns\":";
        private const string TITLE_STRING = ",\"title\":\"";
        private const string EXTRACT_STRING = "\",\"extract\":\"";
        private const string END_STRING = "\"";

        public static WikiArticle ParseJson(string json)
        {
            string[] splitString = new string[6];

            // Get start indexes of attributes
            int pageidStart = json.IndexOf(PAGEID_STRING);
            int nsStart = json.IndexOf(NS_STRING);
            int titleStart = json.IndexOf(TITLE_STRING);
            int extractStart = json.IndexOf(EXTRACT_STRING);

            // Get end indexes of attributes
            int pageidEnd = nsStart;
            int nsEnd = titleStart;
            int titleEnd = extractStart;
            int extractEnd = json.LastIndexOf(END_STRING);

            // Remove search strings lengths from values
            pageidStart += 9;
            nsStart += 6;
            titleStart += 10;
            extractStart += 13;

            // Convert html to text 
            string text = ConvertHtml(json.Substring(extractStart, 
                extractEnd - extractStart));

            // Format text
            text = ReplaceUnicodeEscapes(text);
            text = ReplaceQuotationEscapes(text);
            string[] extract = BreakLines(text);

            // Set attribute values
            WikiArticle article = new WikiArticle(Int32.Parse(
                // PageID
                json.Substring(pageidStart, pageidEnd - pageidStart)),
                // Title
                json.Substring(titleStart, titleEnd - titleStart),
                // Extract
                extract);

            // Return article
            return article;
        }

        private static string ConvertHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            string text = "";
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                text += node.InnerText;
            }
            return text;
        }

        private static Regex newline = new Regex(@"\\n");
        private static string[] BreakLines(string text)
        {
            // Split at every \n and remove whitespace splits
            string[] lines = newline.Split(text)
                .Where(s => s != String.Empty).ToArray();
            return lines;
        }

        private static Regex unicodeEscape = new Regex(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);
        private static string ReplaceUnicodeEscapes(string text)
        {
            // Replace all unicode escape sequences 
            return unicodeEscape.Replace(text, m => ((char)int.Parse(
                m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
        }

        private static Regex quoteEscape = new Regex("\\\\\"");
        private static string ReplaceQuotationEscapes(string text)
        {
            return quoteEscape.Replace(text, "\"");
        }
    }
}