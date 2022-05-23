using System;
using System.IO;
using System.Collections.Generic;

namespace AESALGORITMAS
{
    class Program
    {
        static void Main (string[] args)
        {
            // string key = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Console.WriteLine("1. Uzsifruoti teksta naudojant AES algoritma");
            Console.WriteLine("2. Desifruoto teksto ikelimas is failo");
            Console.WriteLine("3. Baigti darba");

            try
            {


                while (true)
                {
                    Console.WriteLine("\n" + "Pasirinkite veiksma:");
                    int sk = int.Parse(Console.ReadLine());

                    switch (sk)
                    {
                        case 1:

                            Console.WriteLine("Iveskite norima uzsifruoti teksta");
                            string text = Console.ReadLine();

                            Console.WriteLine("Iveskite saugumo rakta");
                            string key = Console.ReadLine();


                            var UzsifruotasTekstas = AES.Uzsifruoti(key, text);
                            Console.WriteLine($"Encrypted: {UzsifruotasTekstas}");
                           
                            var DesifruotasTekstas = AES.Desifruoti(key, UzsifruotasTekstas);
                            Console.WriteLine($"Decrypted: {DesifruotasTekstas} ");

                            File.WriteAllText(@"C:\Testas\text.txt", UzsifruotasTekstas);
                           
                            break;
                        case 2:

                            string readText = File.ReadAllText(@"C:\Testas\desifruoti.txt");
                            string readKEY = File.ReadAllText(@"C:\Testas\raktas.txt");
                           

                            Console.WriteLine($"Tekstas is failo: {readText}");

                            var UzsifruotasTekstas1 = AES.Uzsifruoti(readKEY, readText);
                            Console.WriteLine($"Encrypted: {UzsifruotasTekstas1}");

                            var DesifruotasTekstas1 = AES.Desifruoti(readKEY, UzsifruotasTekstas1);
                            Console.WriteLine($"Decrypted: {DesifruotasTekstas1} ");
                            break;

                        case 3:
                            {
                                Environment.Exit(0);
                                break;
                            }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error: {exc.Message} ");
            }
             
        }
    }
}