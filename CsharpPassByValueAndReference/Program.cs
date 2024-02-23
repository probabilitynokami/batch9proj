class ReferenceTypeClass{
    public int member;
}



class Program{
    static void Main(){
        int x = 0;
        ReferenceTypeClass y = new(){member=0};
        Function(x,y);
        Console.WriteLine(x+" "+y.member); // output: 0 1
    }

    // lets make a parameter mutating function
    // that takes a value type and reference type
    static void Function(int x, ReferenceTypeClass y){
        x = x+1;
        y.member = y.member+1;
    }
}
