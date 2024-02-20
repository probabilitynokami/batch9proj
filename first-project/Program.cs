class Car {
    public string name;
    public float speed;
    public float height;

    public void PrintName(){
        Console.WriteLine(name);
    }

    public void Start(){
        Console.WriteLine("start");
    }

    public void Gas(){
        Console.WriteLine("Gass");
    }

    public void Stop(){
        Console.WriteLine("stop");
    }
    
}




class Program{
    static void Main(){
        Car gato = new Car();
        gato.name = "testname";
        gato.name += "hahaha";
        gato.name = "hahaha"+gato.name;
        gato.PrintName();
        gato.Start();
        gato.Gas();
        gato.Stop();
    }
}