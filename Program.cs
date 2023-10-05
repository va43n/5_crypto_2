using System;

namespace _5_crypto_2
{
    class Program
    {
        static void Main()
        {
            string[] names, code_words;
            try
            {
                StartParameters sp = new("J:\\С#\\source\\repos\\5_crypto_2\\probabilities.txt");
                names = sp.names;
                code_words = sp.code_words;

                for (int i = 0; i < sp.N; i++) { Console.WriteLine(names[i] + " " + code_words[i]); }
                Console.WriteLine(sp.max_code_word_length + " " + sp.average_length + " " + sp.redundancy + " " + sp.KraftInequality);
                if (sp.KraftInequality < 1) { Console.WriteLine("Ok"); }
                else if (sp.KraftInequality == 1) { Console.WriteLine("OPTIMAL"); }
                else { Console.WriteLine("No"); }

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
