﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polinome
    {
        private int power => index.Length;
        private double[] index;

        public double[] Index
        {
            get { return index; }
        }

        public Polinome(params double[] index)
        {
            this.index = index;
        }
        /// <summary>
        /// Override the addition method of class polinome 
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "+"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "+"</param>
        /// <returns>A new polinome.</returns>
        public static Polinome operator +(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            double[] sum = new double[size];
            int border = Math.Min(firstPolinome.Index.Length, secondPolinome.Index.Length) - 1;
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
        /// <summary>
        /// Override the substraction method of class poinome
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "-"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "-"</param>
        /// <returns>A new polinome.</returns>
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
        /// <summary>
        /// Override the multiply method of class poinome
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "*"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "*"</param>
        /// <returns>A new polinome.</returns>
        public static Polinome operator *(Polinome firstPolinome, Polinome secondPolinome)
        {
            int size = firstPolinome.power + secondPolinome.power;
            double[] mult = new double[size];
            if (firstPolinome.power > secondPolinome.power)
            {
                for (int i = 0; i < firstPolinome.power; i++)
                {
                    for (int j = 0; j < secondPolinome.power; j++)
                    {
                        double index = firstPolinome.Index[i] * secondPolinome.Index[j];
                        mult[i + j] = mult[i + j] + index;
                    }

                }

            }
            if (firstPolinome.power < secondPolinome.power)
            {
                for (int i = 0; i < secondPolinome.power; i++)
                {
                    for (int j = 0; j < firstPolinome.power; j++)
                    {
                        double index = firstPolinome.Index[i] * secondPolinome.Index[j];
                        mult[i + j] = mult[i + j] + index;
                    }

                }

            }
            return new Polinome(mult);
        }
        /// <summary>
        /// Override the ToString method of class polinome
        /// </summary>
        /// <returns>A string representation of polinome</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = power; i > -1; i--)
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
        /// <summary>
        /// Override the GetHashCode method of polinome
        /// </summary>
        /// <returns>HashCode of polinome.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        /// <summary>
        /// Override the Equals method of polinome
        /// </summary>
        /// <param name="obj">Object that we get equalized to</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return Equals(obj as Polinome);
        }

        public bool Equals(Polinome polinom)
        {
            if (ReferenceEquals(null, polinom))
                return false;
            if (power != polinom.power)
                return false;
            for (int i = 0; i < power; i++)
            {
                if (Index[i] != polinom.Index[i])
                    return false;
            }
            return true;
        }
    }
}
