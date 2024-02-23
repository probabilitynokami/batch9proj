class Program{
    static void Main(){
        Console.WriteLine("select exception");
        if(! int.TryParse(Console.ReadLine(), out int input)){
            Console.WriteLine("input better value");
            return;
        }

        try{
            DoException(input);
        }
        catch(DivideByZeroException e){
            Console.WriteLine("divby0: "+e);
        }
        catch(FormatException e){
            Console.WriteLine("format: "+e);
        }
        catch(Exception e){
            Console.WriteLine("otherexception: "+e);
        }

        Console.WriteLine("program end");
        
    }
    static void DoException(int input){
        if (input == 0){
            int x = 1/input; // divisionby0exception
            Console.WriteLine(x);
            return;
        }
        if (input == 1){
            throw new InternalBufferOverflowException();
        }
        if (input == 2){
            throw new FormatException();
        }
        if (input == 3){
            return;
        }
        throw new IndexOutOfRangeException();
    }

}
