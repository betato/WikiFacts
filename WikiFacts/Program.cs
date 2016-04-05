using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiFacts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                // Format argument
                string arg1 = args[0].ToLower().Trim().Replace('/', '-');

                switch (arg1)
                {
                    case "-s":
                        // Fullscreen mode
                        Run();
                        break;

                    case "-c":
                        // Configuration mode
                        Config();
                        break;

                    case "-p":
                        // Preview mode
                        Preview();
                        break;

                    default:
                        // Unknown argument
                        Run();
                        break;
                }
            }
            else
            {
                // No arguments
                Config();
            }
        }

        public static void Run()
        {
            
        }

        public static void Preview()
        { 

        }

        public static void Config()
        {
            // Open configuration window
            Application.Run(new Form1());
        }
    }
}
