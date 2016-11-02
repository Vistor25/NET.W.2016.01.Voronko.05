using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polinome
    {
        private int power;
        private double[] index;

        public int Power
        {
            get { return power; }
        }

        public double[] Index
        {
            get { return index; }
        }

        public Polinome(params double[] index)
        {
            this.index = index;
            this.power = index.Length - 1;
        }

        public static Polinome operator +(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            double[] sum = new double[size];
            int border = Math.Min(firstPolinome.Index.Length, secondPolinome.Index.Length);
            for (int i = 0; i < border; i++)
            {
                sum[i] = firstPolinome.Index[i] + secondPolinome.Index[i];
            }
            
        }

    }
}
