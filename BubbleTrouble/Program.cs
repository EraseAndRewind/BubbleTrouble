using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        public static bool OpenSelectChar { get; set; }
        public static bool OpenMainMenu { get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenDetailFormOnClose = false;
            OpenSelectChar = false;
            OpenMainMenu = true;
            
            while(true){

                if (OpenMainMenu)
                {
                    Application.Run(new MainMenu());
                    OpenMainMenu = false;
                }

                if (OpenSelectChar)
                {
                    SelectCharacter selectChar = new SelectCharacter();
                    Application.Run(selectChar);
                    OpenSelectChar = false;

                    if (OpenDetailFormOnClose)
                    {
                        Application.Run(new Form1(selectChar.selected));
                        OpenDetailFormOnClose = false;
                    }
                }
                else if (OpenDetailFormOnClose)
                {
                    Application.Run(new Form1(1));
                    OpenDetailFormOnClose = false;
                }

                if (!OpenMainMenu && !OpenSelectChar) break;

                

            }
            
        }
    }
}
