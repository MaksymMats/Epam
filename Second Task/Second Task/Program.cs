using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task
{
    class Polinom
    {
        int size;
        public int[] coeficients;
        int[] powers;
        public Polinom(int size)
        {
            this.size = size;
            coeficients = new int[this.size];
            powers = new int[this.size];
        }
        public int this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentException("can not be negative size of array");
                }
               return coeficients[i];
            } 
            set { coeficients[i] = value; }
        }
        public void PutPowers()
        {
            for (int i = 0; i < powers.Length; i++)
            {
                powers[(powers.Length - 1) - i] = i;
            }
        }
        public void Putcoefs(int[] array)
        {
            PutPowers();
            if (array.Length != size)
            {
                throw new ArgumentException("wrong number of coeficients");
            }
            for (int i = 0; i < array.Length; i++)
            {
                coeficients[i] = array[i];
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = coeficients.Length - 1; i >= 0; --i)
            {
                if (coeficients[i] == 0) continue;
                if (coeficients[i] > 0 && sb.Length > 0) sb.Append('+');
                if (coeficients[i] < 0) sb.Append('-');
                var abs = Math.Abs(coeficients[i]);
                if (abs != 1 || i == 0) sb.Append(abs);
                if (i > 0) sb.Append('x');
                if (i > 1) sb.Append('^').Append(i);
            }
            if (sb.Length == 0) return "0";
            return sb.ToString();
        }
        public int Getcoefs(int n)
        {
            if(n>coeficients.Length)
            { throw new ArgumentException("the power is to big"); }
            return coeficients[n - 1];
        }
        public static Polinom operator +(Polinom arg1, Polinom arg2)
        {
            int n = 0;
            int k = 0;
            if (arg1.coeficients.Length > arg2.coeficients.Length)
            {
                n = arg2.coeficients.Length;
                k = -1;
                Array.Resize(ref arg2.coeficients, arg1.coeficients.Length);
            }
            if (arg1.coeficients.Length < arg2.coeficients.Length)
            {
                n = arg1.coeficients.Length;
                k = 1;
                Array.Resize(ref arg1.coeficients, arg2.coeficients.Length);
            }
            Polinom sum = new Polinom(arg2.coeficients.Length);
            for (int i = 0; i < arg2.coeficients.Length; i++)
            {
                sum[i] = arg1[i] + arg2[i];
            }
            if (k == -1)
            {
                Array.Resize(ref arg2.coeficients, n);
            }
            if (k == 1)
            {
                Array.Resize(ref arg1.coeficients, n);
            }
            return sum;
        }
        public static Polinom operator -(Polinom arg1, Polinom arg2)
        {
            int n = 0;
            int k = 0;
            if (arg1.coeficients.Length > arg2.coeficients.Length)
            {
                n = arg2.coeficients.Length;
                k = -1;
                Array.Resize(ref arg2.coeficients, arg1.coeficients.Length);
            }
            if (arg1.coeficients.Length < arg2.coeficients.Length)
            {
                n = arg1.coeficients.Length;
                k = 1;
                Array.Resize(ref arg1.coeficients, arg2.coeficients.Length);
            }
            Polinom substraction = new Polinom(arg2.coeficients.Length);
            for (int i = 0; i < arg2.coeficients.Length; i++)
            {
                substraction[i] = arg1[i] - arg2[i];
            }
            if (k == -1)
            {
                Array.Resize(ref arg2.coeficients, n);
            }
            if (k == 1)
            {
                Array.Resize(ref arg1.coeficients, n);
            }
            return substraction;
        }
        public static Polinom operator *(Polinom polynom1, Polinom polynom2)
        {
            Polinom multiplication = new Polinom(polynom1.coeficients.Length + polynom2.coeficients.Length - 1);
            for (int i = 0; i < polynom1.coeficients.Length; ++i)
                for (int j = 0; j < polynom2.coeficients.Length; ++j)
                    multiplication[i + j] += polynom1.coeficients[i] * polynom2.coeficients[j];
            return multiplication;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Polinom first = new Polinom(3);
            first.Putcoefs(new int[] { 1,-2,3});
            Console.WriteLine(first);
            Polinom second = new Polinom(3);
            second.Putcoefs(new int[] {1,2,3 });
           // Polinom sum = first + second;
            //sum.Showpolinom();
            //Polinom substract = first - second;
            //substract.Showpolinom();
            Polinom multiplication = first *second;
           // Console.WriteLine("enter a power of what coef you want to know");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine( first.Getcoefs(n) ); 
        }
    }
}
