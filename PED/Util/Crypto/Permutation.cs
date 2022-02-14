using System;
using System.Collections.Generic;

namespace PED.Util
{
    public static class Permutation
    {
        public const int SIZE = 16;

        static Random rando = new Random();

        public static uint[] Generate()
        {
            List<uint> key = new List<uint>();

            while (key.Count < SIZE)
            {
                uint nextValue = (uint)rando.Next(0, SIZE);

                if (!key.Contains(nextValue))
                    key.Add(nextValue);
            }

            return key.ToArray();
        }

        public static uint[] GenerateInverse(uint[] permutation)
        {
            uint[] inverse = new uint[SIZE];

            for(uint i = 0; i < SIZE; i++)
            {
                uint index = permutation[i];
                inverse[index] = i;
            }

            return inverse;
        }
    }
}
