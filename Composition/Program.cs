// See https://aka.ms/new-console-template for more information


class Program{

    static void Main(){

        Engine engine = new Engine(8,2,"rotary");
        Tire tire = new Tire("michellin",100);
        Car car = new Car(engine, tire, "hehe",1.0f);

        engine.type = "huhu";

        Console.WriteLine(car.engine.type);
        return;
    }
}
