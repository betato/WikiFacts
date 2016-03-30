using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public static WikiArticle parseJson(string json)
        {
            WikiArticle article = new WikiArticle();
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

            // Get attribute values
            article.pageid = Int32.Parse(json.Substring(pageidStart, pageidEnd - pageidStart));
            article.title = json.Substring(titleStart, titleEnd - titleStart);
            article.extract = json.Substring(extractStart, extractEnd - extractStart);

            // Convert html to text and return article
            // (I'll work on this next)

            return article;
        }
    }
}