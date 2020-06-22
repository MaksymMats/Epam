using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Task
{
    public interface ICloneable
    {
        object Clone();
    }
    class Matrix : ICloneable
    {
        private int[,] data;
        private int weidth;
        private int height;
       
        public Matrix()
        {

        }
        public Matrix(int weidth,int height)
        {
            this.weidth = weidth;
            this.height = height;
            data = new int[this.weidth, this.height];
        }
        public int this[int i, int j]
        {
            get {
                if (i < 0 && j < 0)
                {
                    throw new ArgumentException("dimensions of Matrix should be positive");
                }
                return data[i, j];
            }
            set { data[i, j] = value; }
        }
        public void Matrixinput(int[,] array)
        {
             if (array.GetLength(0) != weidth || array.GetLength(1) !=height)
                {
                    throw new ArgumentException("wrong number of elements in matrix");
                }
            for (int i = 0; i < weidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    try
                    {
                        data[i, j] = array[i,j];
                    }catch(System.FormatException)
                    {
                        throw new Exception("You enter a value of wrong type, only integer is allow");
                    }
                    
                }
            }
        }
      
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < weidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    sb.Append($"{data[i, j]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
        public object Clone()
        {
            int[,] newmatrix = new int[this.weidth, this.height];
            for (int i = 0; i < weidth; i++)
                for (int j = 0; j < height; j++)
                {
                    newmatrix[i, j] = this[i, j];
                }
            return new Matrix(newmatrix.GetLength(0),newmatrix.GetLength(1));
        }
        public static Matrix operator +(Matrix arg1,Matrix arg2)
        {
            if ((arg1.data.GetLength(0) != arg2.data.GetLength(0) || arg1.data.GetLength(1) != arg2.data.GetLength(1)))
            {
                throw new ArgumentException("Can not add matrixs with differnt dimensions");
            }
            Matrix sum = new Matrix(arg1.data.GetLength(0),arg1.data.GetLength(1));
            for(int i = 0; i < arg1.data.GetLength(0); i++)
            {
                for(int j = 0; j < arg1.data.GetLength(0); j++)
                {
                    sum[i, j] = arg1[i, j] + arg2[i, j];
                }
            }
            return sum;
        }
        public static Matrix operator -(Matrix arg1, Matrix arg2)
        {
            if ((arg1.data.GetLength(0) != arg2.data.GetLength(0) || arg1.data.GetLength(1) != arg2.data.GetLength(1)))
            {
                throw new ArgumentException("Can not substract matrixs with differnt dimensions");
            }
            Matrix substract = new Matrix(arg1.data.GetLength(0),arg1.data.GetLength(1));
            for (int i = 0; i < arg1.data.GetLength(0); i++)
            {
                for (int j = 0; j < arg1.data.GetLength(0); j++)
                {
                    substract[i, j] = arg1[i, j] - arg2[i, j];
                }
            }
            return substract;
        }
        public static Matrix operator *(Matrix arg1,Matrix arg2)
        {
            if (arg1.data.GetLength(1) != arg2.data.GetLength(0))
            {
                throw new ArgumentException("Can not multiply matrixs when number of columns of first matrix differ from number of rows of second matrix");
            }
            Matrix multiplication = new Matrix(arg1.data.GetLength(0), arg2.data.GetLength(1));
            for (int i = 0; i < arg1.data.GetLength(0); i++)
            {
                for (int j = 0; j < arg2.data.GetLength(1); j++)
                {
                    for (int k = 0; k < arg2.data.GetLength(0); k++)
                    {
                        multiplication[i, j] += arg1[i, k] * arg2[k, j];
                    }
                }
            }
            return multiplication;
        }
        public static bool operator ==(Matrix arg1,Matrix arg2)
        {
            if ((arg1.data.GetLength(0) != arg2.data.GetLength(0) || arg1.data.GetLength(1) != arg2.data.GetLength(1)))
            {
                throw new ArgumentException("Can not compare matrix with different dismensions");
            }
            for (int i = 0; i < arg1.data.GetLength(0); i++)
            {
                for (int j = 0; j < arg1.data.GetLength(0); j++)
                {
                    if (arg1[i, j] != arg2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix arg1, Matrix arg2)
        {
            if ((arg1.data.GetLength(0) != arg2.data.GetLength(0) || arg1.data.GetLength(1) != arg2.data.GetLength(1)))
            {
                throw new ArgumentException("Can not compare matrix with different dismensions");
            }
            int counter = 0; 
            int check = arg1.data.GetLength(0) * arg1.data.GetLength(1);
            for (int i = 0; i < arg1.data.GetLength(0); i++)
            {
                for (int j = 0; j < arg1.data.GetLength(0); j++)
                {
                    if (arg1[i, j] == arg2[i, j])
                    {
                        counter++;
                    }
                }
            }
            if (counter == check)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Matrix matrix = obj as Matrix;
            if (matrix as Matrix == null)
                return false;

            return this == matrix;
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix first = new Matrix(2,3);
            Matrix second = new Matrix(2,3);
            first.Matrixinput(new int[,] { { 1, -2,3}, { 1, 2,3} });
            first.Clone();
            Console.WriteLine(first);
            
            if (first == second) 
            {
                Console.WriteLine("equal matrixs");
            }
            else
            {
                Console.WriteLine("not eauls matrixs");

            }
            
           
        }
    }
}
