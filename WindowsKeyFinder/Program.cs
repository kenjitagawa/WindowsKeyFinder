using System;

namespace WindowsKeyFinder
{
    class Program
       {
        [STAThread]
        static void Main(string[] args)
        {


            Windows productKey = new Windows();

            productKey.FindProductKeyClick();

            Console.ForegroundColor = ConsoleColor.DarkGreen;


            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("|\tWelcome to Windows Product Key Finder!                                      |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|\tHere is your Windows Key:                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine($"|                            {productKey.Key}                          |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                                   |");
            Console.WriteLine("|                                                                    - Kenji T.     |");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            



            
            Console.Write("Press any key to quit.");
            Console.ReadKey();


        }
    }
}
