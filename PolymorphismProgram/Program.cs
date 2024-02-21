// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BaseClass a = new BaseClass();
a.Call();
a = new DerivedClass1();
a.Call();
a = new DerivedClass2();
a.Call();
Console.WriteLine("\n");
(new DerivedClass1()).Call();
(new DerivedClass2()).Call(); // method hiding


class BaseClass{
    public virtual void Call(){
        Console.WriteLine("base class Called");
    }
}

class DerivedClass1 : BaseClass {
    public override void Call(){
        Console.WriteLine("derived class1 Called");
    }

}

class DerivedClass2 : BaseClass{
    public void Call(){
        Console.WriteLine("derived class2 Called");
    }

}