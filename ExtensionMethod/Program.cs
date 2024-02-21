// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


3.Hehe();
3.Huhu(2);

3.Add(2).Mul(3).Add(1).Hehe();

static class ExtensionMethod{
    public static void Hehe(this int x){
        Console.WriteLine(x);
    }
    public static void Huhu(this int x, int y){
        Console.WriteLine(x+y);
    }

    public static int Add(this int x, int y){
        return x+y;
    }
    public static int Mul(this int x, int y){
        return x*y;
    }
}
