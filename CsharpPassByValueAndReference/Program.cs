class ReferenceTypeClass{
    public int member;
}



class Program{
    static void Main(){
        int x = 0;
        ReferenceTypeClass y = new(){member=0};
        Function(x,y);
        Console.WriteLine(x+" "+y.member); // output: 0 1

        Function2(ref x);
        Console.WriteLine(x); // output: 1

        int a;
        // Function2(ref a); // Illegal, ref require it to be assigned before being read
        Function3(out a);
        Console.WriteLine(a); // output: 4

        Function4(in a);

        Function5(in y);
        Console.WriteLine(y.member);


        // real use of out

        string to_parse = "69";
        bool status = int.TryParse(to_parse, out int result);
        Console.WriteLine(status+" "+result); // identifier result magically can be used without declaring lol

        to_parse = "69lol"; // should fail
        status = int.TryParse(to_parse, out int result2); // exception handling with manual catch -> better than regular exception handling
        Console.WriteLine(status+" "+result2);         

    }

    // lets make a parameter mutating function
    // that takes a value type and reference type
    static void Function(int x, ReferenceTypeClass y){
        x = x+1;
        y.member = y.member+1;
    }

    // parameter mutating function with ValueType param
    static void Function2(ref int x){ // ref kw -> like pointer but with some restriction. (see Main())
        x = x+1;
    }

    static void Function3(out int x){
        // Console.WriteLine(x); // illegal to read before assignment in method
        x = 3;
        x = x+1;
    }

    static void Function4(in int x){ // forced immutable param, for compile-time optimization
        // x = 1; //illegal
        ;
    }

    static void Function5(in ReferenceTypeClass x){
        x.member = 999; // legal because it doesn't mutate x, but x.member instead..
    }
}
