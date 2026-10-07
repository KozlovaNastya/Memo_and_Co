using System;
namespace MemoAndCo.Utils
{

    public static class FisherYaets
    {
        private static readonly Random rng = new Random();

        public static void Shuffle<T>(T[] array)
        {
            if (array == null || array.Length < 2) return;

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                T temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
    }
}
