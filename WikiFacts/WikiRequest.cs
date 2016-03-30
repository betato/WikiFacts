using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WikiFacts
{
    class WikiRequest
    {
        private const string REQUEST_URL_START = "https://en.wikipedia.org/w/api.php?action=query";
        private const string REQUEST_URL_END = "&prop=extracts&format=json";
        private const string RANDOM_PARAMETER = "&generator=random";
        private const string PAGEID_PARAMETER = "&pageids=";
        private const string MAX_CHARS_PARAMETER = "&exchars=";

        public string getArticle(int pageid, int maxChars)
        {
            // Make webrequest
            WebRequest request = WebRequest.Create(getUrl(pageid, maxChars));
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();

            // Read and return stream
            string json;
            using (StreamReader sr = new StreamReader(data))
            {
                json = sr.ReadToEnd();
            }
            return json;
        }

        private string getUrl(int pageid, int maxChars)
        {
            string url = REQUEST_URL_START;
            if (pageid <= 0)
            {
                // Get random article
                url += RANDOM_PARAMETER;
            }
            else
            {
                // Get article from pageid
                url += PAGEID_PARAMETER + pageid;
            }

            if (maxChars > 0)
            {
                // Set maximum characters
                url += MAX_CHARS_PARAMETER + maxChars;
            }
            // Return complete url
            return url + REQUEST_URL_END;
        }
    }
}
