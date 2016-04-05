using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiFacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WikiRequest wr = new WikiRequest();
            WikiArticle wa = WikiParser.ParseJson(wr.GetArticle(0, 0));

            foreach (string s in wa.extract)
            {
                MessageBox.Show(s);
            }
        }
    }
}
