using System;
using System.IO;

namespace _5_crypto_2
{
    class StartParameters
    {
        private int N;
        private double[] probabilities;
        private string[] names;
        private string[] indices;

        public StartParameters(string nameOfProbFile)
        {
            string[] parameters;
            int counter = 0;
            double temp = 0;
            int min1, min2;
            bool[] used;

            if (File.Exists(nameOfProbFile))
            {
                using (StreamReader sr = new(nameOfProbFile))
                {
                    string text;
                    text = sr.ReadLine();

                    parameters = text.Split(" ");
                }
            }
            else { throw new Exception("Файл \"" + nameOfProbFile + "\" не сущеcтвует."); }

            N = parameters.Length;
            if (N % 2 != 0 || N == 0) { throw new Exception("Неправильная запись данных в файле с вероятностями: элементов должно быть четное число, нечетные элементы - буквы алфавита, четные элементы - соответствующие буквам вероятности. Скорее всего элементов в файле не хватает либо их нет вообще."); }

            N /= 2;

            names = new string[N];
            probabilities = new double[N + N];
            probabilities[N + N - 1] = 2;

            foreach(string p in parameters)
            {
                if (counter % 2 == 0)
                {
                    if (Array.Exists(names, element => element == p)) { throw new Exception("Алфавит должен состоять из неповторяющихся элементов. Элемент \"" + p + "\" повторяется."); }
                    names[counter / 2] = p;
                }
                else
                {
                    try { probabilities[(counter - 1) / 2] = Convert.ToDouble(p); }
                    catch { throw new Exception("Вероятность \"" + p + "\" не является числом. Возможно следует поменять \".\" на \",\"."); }

                    if (probabilities[(counter - 1) / 2] < 0) { throw new Exception("Вероятность \"" + p + "\" меньше 0, а должна быть больше или равна 0."); }

                    temp += probabilities[(counter - 1) / 2];
                }

                counter++;
            }

            if (temp != 1) { throw new Exception("Сумма всех вероятностей должна быть равна 1. Сейчас она равна " + temp + "."); }

            indices = new string[N + N - 1];
            used = new bool[N + N - 1];

            for (int i = 0; i < N; i++) { indices[i] = Convert.ToString(i); }

            for (int i = N; i < 2 * N - 1; i++)
            {
                min1 = N + N - 1;
                min2 = N + N - 1;
                for (int j = 0; j < i; j++)
                {
                    if (probabilities[j] < probabilities[min1] && j != min1 && !used[j])
                    {
                        min2 = min1;
                        min1 = j;
                    }
                    else if (probabilities[j] < probabilities[min2] && j != min1 && !used[j]) { min2 = j; }
                }
                probabilities[i] = probabilities[min1] + probabilities[min2];
                indices[i] = Convert.ToString(min2) + ":" + Convert.ToString(min1);
                used[min1] = true;
                used[min2] = true;
            }
        }

        public double[] GetProbabilities()
        {
            return probabilities;
        }

        public string[] GetIndices()
        {
            return indices;
        }

        public string[] GetNames()
        {
            return names;
        }
    }
}
