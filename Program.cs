using System;

namespace _5_crypto_2
{
    class Program
    {
        static void Main()
        {
            try
            {
                StartParameters sp = new("J:\\С#\\source\\repos\\5_crypto_2\\probabilities.txt");
                foreach(double p in sp.GetProbabilities()) { Console.WriteLine(p); }
                Console.WriteLine();
                foreach (string n in sp.GetNames()) { Console.WriteLine(n); }
                Console.WriteLine();
                foreach (string c in sp.GetCodeWords()) { Console.WriteLine(c); }
                Console.WriteLine();
                foreach (string i in sp.GetIndices()) { Console.WriteLine(i); }
                Console.WriteLine();

                //sp.CodeMessage("J:\\С#\\source\\repos\\5_crypto_2\\input.txt", "J:\\С#\\source\\repos\\5_crypto_2\\output.txt");
                sp.DecodeMessage("J:\\С#\\source\\repos\\5_crypto_2\\output.txt", "J:\\С#\\source\\repos\\5_crypto_2\\input.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
