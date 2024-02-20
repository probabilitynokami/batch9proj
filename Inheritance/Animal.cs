namespace Animalia;

public class Animal
{
    public string gender;
    public Animal(string gender){
        Console.WriteLine("Animal Constructor");
        this.gender = gender;
    }
    public void Walk(){
        Console.WriteLine("animal walk");
    }
    public void Breathe(){
        Console.WriteLine("animal breathe");
    }
}
