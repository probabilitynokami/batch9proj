// See https://aka.ms/new-console-template for more information

using KitchenStuff;
using Vehicle;


class Program{

    static void Main(){

        Engine engine = new(8,2,"rotary");
        Vehicle.Tire tire = new("michellin",100);
        Car car = new(engine, tire, "hehe",1.0f);

        engine.type = "huhu";

        Console.WriteLine(car.engine.type);
        return;
    }
}
