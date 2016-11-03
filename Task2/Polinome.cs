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
            this.power = index.Length-1;
        }

        public static Polinome operator +(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            double[] sum = new double[size];
            int border = Math.Min(firstPolinome.Index.Length, secondPolinome.Index.Length)-1;
            for (int i = 0; i < border; i++)
            {
                sum[i] = firstPolinome.Index[i] + secondPolinome.Index[i];
            }
            if (firstPolinome.Index.Length > secondPolinome.Index.Length)
            {
                for (int i = border; i < size - 1; i++)
                {
                    sum[i] = firstPolinome.Index[i];
                }
            }
            if (firstPolinome.Index.Length < secondPolinome.Index.Length)
            {
                for (int i = border; i < size - 1; i++)
                {
                    sum[i] = secondPolinome.Index[i];
                }
            }
            return new Polinome(sum);

        }
        public static Polinome operator -(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            double[] sum = new double[size];
            int border = Math.Min(firstPolinome.Index.Length, secondPolinome.Index.Length) - 1;
            for (int i = 0; i < border; i++)
            {
                sum[i] = firstPolinome.Index[i] - secondPolinome.Index[i];
            }
            if (firstPolinome.Index.Length > secondPolinome.Index.Length)
            {
                for (int i = border; i < size - 1; i++)
                {
                    sum[i] = firstPolinome.Index[i];
                }
            }
            if (firstPolinome.Index.Length < secondPolinome.Index.Length)
            {
                for (int i = border; i < size - 1; i++)
                {
                    sum[i] = secondPolinome.Index[i];
                }
            }
            return new Polinome(sum);

        }

        public static Polinome operator *(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size =firstPolinome.Power+secondPolinome.Power;
            double[] mult = new double[size];
            if (firstPolinome.Power > secondPolinome.Power)
            {
                for (int i = 0; i < firstPolinome.Power; i++)
                {
                    for (int j = 0; j < secondPolinome.Power; j++)
                    {
                        double index = firstPolinome.Index[i]*secondPolinome.Index[j];
                        mult[i + j] = mult[i + j] + index;
                    }
                    
                }
                
            }
            if (firstPolinome.Power < secondPolinome.Power)
            {
                for (int i = 0; i < secondPolinome.Power; i++)
                {
                    for (int j = 0; j < firstPolinome.Power; j++)
                    {
                        double index = firstPolinome.Index[i] * secondPolinome.Index[j];
                        mult[i + j] = mult[i + j] + index;
                    }

                }

            }
            return new Polinome(mult);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = Power; i >-1 ; i--)
            {
                if (Index[i] != 0)
                {
                    if (Index[i] > 0)
                    {
                        result.Append(" + ");
                    }
                    else
                    {
                        result.Append(" - ");
                    }
                    if (i != 0)
                        result.Append(Math.Abs(Index[i]) + "x^" + i);
                    else
                        result.Append(Math.Abs(Index[i]));
                }
            }
            return result.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
