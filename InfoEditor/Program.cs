using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new InfoEditorMain());

            if (args.Length > 0)
            {
                // args[0] contains the file path
                string filePath = args[0];
                Application.Run(new InfoEditorMain(filePath));
            }
            else
            {
                Application.Run(new InfoEditorMain());
            }

        }
    }
}
