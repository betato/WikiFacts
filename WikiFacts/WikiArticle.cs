using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiFacts
{
    class WikiArticle
    {
        public WikiArticle(int pageid, string title, string[] extract)
        {
            this.pageid = pageid;
            this.title = title;
            this.extract = extract;
        }

        public int pageid;
        public string title;
        public string[] extract;
    }
}
