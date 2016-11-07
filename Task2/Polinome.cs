using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task2
{
    public sealed class Polinome : IEquatable<Polinome>, ICloneable
    {
        private int power;
        private static double epsilon;
        public double[] Index { get; private set; }


        public static double Epsilon
        {
            get { return epsilon; }
            private set
            {
                if (value <= 0 || value >= 1)
                    throw new ArgumentOutOfRangeException();

                epsilon = value;
            }

        }

        public int Power
        {
            get
            {
                if (Index.Length == 1)
                    return 0;
                int i;
                for (i = Index.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(Index[i]) > Epsilon)
                        break;
                }

                return i;
            }
        }

        public Polinome(params double[] coeff)
        {
            if (ReferenceEquals(coeff, null))
                throw new ArgumentNullException();
            if (coeff.Length == 0)
                throw new ArgumentOutOfRangeException();
            Index = new double[coeff.Length];
            coeff.CopyTo(Index, 0);
        }

        static Polinome()
        {
            try
            {
                Epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
            }
            catch (ConfigurationErrorsException exeption)
            {
                throw new ConfigurationErrorsException("Can't get epsilon ", exeption);
            }
            catch (FormatException exception)
            {
                throw new ConfigurationErrorsException("Invalid format", exception);
            }
        }
        /// <summary>
        /// Override the addition method of class polinome 
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "+"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "+"</param>
        /// <returns>A new polinome.</returns>
        public static Polinome operator +(Polinome firstPolinome, Polinome secondPolinome)
        {
            if (ReferenceEquals(firstPolinome, null)) throw new ArgumentNullException();
            if (ReferenceEquals(secondPolinome, null)) throw new ArgumentNullException();
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            Polinome polinome = firstPolinome.power >= secondPolinome.power
                ? firstPolinome.Clone()
                : secondPolinome.Clone();
            for (int i = 0; i < size; i++)
            {
                polinome[i] += firstPolinome.power >= secondPolinome.power ? secondPolinome[i] : firstPolinome[i];
            }
            return polinome;

        }

        /// <summary>
        /// Override the substraction method of class poinome
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "-"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "-"</param>
        /// <returns>A new polinome.</returns>
        public static Polinome operator -(Polinome firstPolinome, Polinome secondPolinome)
        {
            if(ReferenceEquals(firstPolinome,null)) throw new ArgumentNullException();
            if(ReferenceEquals(secondPolinome,null)) throw new ArgumentNullException();
            int size = Math.Max(firstPolinome.Index.Length, secondPolinome.Index.Length);
            Polinome polinome = firstPolinome.power >= secondPolinome.power
                ? firstPolinome.Clone()
                : secondPolinome.Clone();
            for (int i = 0; i < size; i++)
            {
                polinome[i] -= firstPolinome.power >= secondPolinome.power ? secondPolinome[i] : firstPolinome[i];
            }
            return polinome;
        }

        /// <summary>
        /// Override the multiply method of class poinome
        /// </summary>
        /// <param name="firstPolinome">Polinome that stands before sign "*"</param>
        /// <param name="secondPolinome">Poinome that stands after sign "*"</param>
        /// <returns>A new polinome.</returns>
        public static Polinome operator *(Polinome firstPolinome, Polinome secondPolinome)
        {
            if (ReferenceEquals(firstPolinome, null)) throw new ArgumentNullException();
            if (ReferenceEquals(secondPolinome, null)) throw new ArgumentNullException();
            int size = firstPolinome.power + secondPolinome.power;
            double[] mult = new double[size];
            
            for (int i = 0; i < firstPolinome.power; i++)
                {
                    for (int j = 0; j < secondPolinome.power; j++)
                    {
                        double index = firstPolinome.Index[i]*secondPolinome.Index[j];
                        mult[i + j] = mult[i + j] + index;
                    }

                }

           return new Polinome(mult);
        }

        public static Polinome Add(Polinome firstPolinome, Polinome secondPolinome)
        {
            return firstPolinome + secondPolinome;
        }
        public static Polinome Substract(Polinome firstPolinome, Polinome secondPolinome)
        {
            return firstPolinome - secondPolinome;
        }
        public static Polinome Multiply(Polinome firstPolinome, Polinome secondPolinome)
        {
            return firstPolinome * secondPolinome;
        }

        public static bool operator ==(Polinome firstPolinome, Polinome secondPolinome)
        {
            if (ReferenceEquals(firstPolinome, secondPolinome)) return true;
            if (ReferenceEquals(firstPolinome, null) || ReferenceEquals(secondPolinome, null)) return false;
            return Equals(firstPolinome, secondPolinome);
        }

        public static bool operator !=(Polinome firstPolinome, Polinome secondPolinome)
        {
            return !(firstPolinome == secondPolinome);
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
            return obj.GetType() == GetType() && Equals((Polinome)obj);
        }

        public bool Equals(Polinome polinom)
        {
            if (ReferenceEquals(null, polinom))
                return false;
            if (power != polinom.power)
                return false;
            for (int i = 0; i < power; i++)
            {
                if (Index[i] != polinom[i])
                    return false;
            }
            return true;
        }

        public Polinome Clone()
        {
            return new Polinome(Index);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        public double this[int i]
        {
            get
            {
                if (i < 0 || i > power)
                    throw new ArgumentOutOfRangeException();
                return Index[i];
            }
            private set
            {
                if (i < 0 || i > power)
                    throw new ArgumentOutOfRangeException();
                Index[i] = value;
            }

        }
    }
}
