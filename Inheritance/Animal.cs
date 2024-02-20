namespace Animalia;

public class Animal
{
    public string gender;
    public Animal(){
        Console.WriteLine("Animal Constructor");
        this.gender = "hohoho";
    }
    public void Walk(){
        Console.WriteLine("animal walk");
    }
    public void Breathe(){
        Console.WriteLine("animal breathe");
    }
}
