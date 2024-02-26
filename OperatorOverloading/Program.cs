using MathObjects;

class Program{
    static void Main(){
        Vector a = new(3){elements=[1,1,1]};
        Vector b = new(3){elements=[1,0,1]};
        Vector c = new(3){elements=[0,1,0]};
        Vector res = a+b-c;
        foreach(var x in res.elements){
            Console.WriteLine(x);
        }

    }
}

namespace MathObjects{
    class Vector{
        public float[] elements;
        public Vector(int dim){
            elements = new float[dim];
        }

        public static Vector operator +(Vector left, Vector right){
            if (left.elements.Length != right.elements.Length){
                throw new InvalidOperationException();
            }
            var result = (float[])left.elements.Clone();
            for(int i=0;i<result.Length;i++){
                result[i] += right.elements[i];
            }

            return new Vector(result.Length){elements = result};
        }

        public static Vector operator -(Vector left, Vector right){
            if (left.elements.Length != right.elements.Length){
                throw new InvalidOperationException();
            }
            var result = (float[])left.elements.Clone();
            for(int i=0;i<result.Length;i++){
                result[i] -= right.elements[i];
            }

            return new Vector(result.Length){elements = result};
        }
    }
}