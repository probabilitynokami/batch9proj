namespace Animalia;

public class Cat : Animal
{
    public Cat() : base("male"){
        Console.WriteLine("Cat constructor");
    }
    public void Meow(){
        Console.WriteLine("meow");
    }
}
