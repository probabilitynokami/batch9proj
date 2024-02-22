// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

PropertyDemo p = new();

Console.WriteLine(p.readOnlyVar);
p.setReadOnlyVar(9);
Console.WriteLine(p.readOnlyVar);

// p.readOnlyVar = 1; //compile error

Console.WriteLine(p.readOnlyVar);

// Console.WriteLine(p.WriteOnlyVar); //compile error

class PropertyDemo {
    public int readOnlyVar {get; private set;}
    public int WriteOnlyVar {private get; set;}

    public int readWriteOnlyVar {private get; set;}
    public void setReadOnlyVar(int value){
        this.readOnlyVar = value;
    }

}
