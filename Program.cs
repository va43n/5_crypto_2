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
                foreach (string i in sp.GetIndices()) { Console.WriteLine(i); }
                Console.WriteLine();
                foreach (string n in sp.GetNames()) { Console.WriteLine(n); }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
