using System;
using System.Collections.Generic;

namespace PED.Util
{
    public class Permutation
    {
        int size;
        Random rando;
        uint[] function;

        public Permutation(int theSize = 16)
        {
            size = theSize;
            rando = new Random();
            function = Generate();
        }

        public Permutation(uint[] theFunction)
        {
            size = theFunction.Length;
            rando = new Random();
            function = theFunction;
        }

        public Permutation(Permutation other)
        {
            size = other.size;
            rando = new Random();
            function = other.function;
        }

        uint[] Generate()
        {
            List<uint> key = new List<uint>();

            while (key.Count < size)
            {
                uint nextValue = (uint)rando.Next(0, size);

                if (!key.Contains(nextValue))
                    key.Add(nextValue);
            }

            return key.ToArray();
        }

        public void Regenerate() { function = Generate(); }

        public Permutation Inverse()
        {
            uint[] inverse = new uint[size];

            for(uint i = 0; i < size; i++)
            {
                uint index = function[i];
                inverse[index] = i;
            }

            return new Permutation(inverse);
        }
    }
}
