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
                        run();
                        break;

                    case "-c":
                        // Configuration mode
                        config();
                        break;

                    case "-p":
                        // Preview mode
                        preview();
                        break;

                    default:
                        // Unknown argument
                        run();
                        break;
                }
            }
            else
            {
                // No arguments
                config();
            }
        }

        public static void run()
        {
            
        }

        public static void preview()
        { 

        }

        public static void config()
        {
            // Open configuration window
            Application.Run(new Form1());
        }
    }
}
