using System;
using System.Threading;

namespace WindowsKeyFinder
{
    class Program
       {
        [STAThread]
        static void Main(string[] args)
        {

            Windows productKey = null;

            try
            {
                productKey = new Windows();
                productKey.FindProductKeyClick();

            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }




            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write("Fetching the key from your device... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 200; i++)
                {
                    progress.Report((double)i / 200);
                    Thread.Sleep(5);
                }   
            }
            Console.WriteLine("Done.");


            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|\tWelcome to Windows Product Key Finder!                                      |");                                                                         
            Console.WriteLine("|\tHere is your Windows Key:                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine($"|                            {productKey.Key}                          |");
            Console.WriteLine("|                                                                    - Kenji T.     |");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("\n\n");
            Console.WriteLine("Link to source code: ");
            Console.WriteLine("\thttps://github.com/kenjitagawa/WindowsKeyFinder");
            Console.WriteLine("\n");
            Console.Write("Press any key to quit.");
            Console.ReadKey();


        }
    }
}
