
namespace Vehicle;
class Car{

    public Engine engine;
    public Tire tire;
    public string brand;
    public float fuel;

    public Car(Engine engine, Tire tire, string brand, float fuel){
        this.engine = engine;
        this.tire = tire;
        this.brand = brand;
        this.fuel = fuel;
    }
}