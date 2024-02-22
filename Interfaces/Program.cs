// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using InterfaceTEst;
class Program{
    static void Main(){
        DatabaseProject proj = new();
        WriteToDB(proj,"HEHEHE");
        SaveToFile(proj,"/home/user/postgres");
    }

    static void SaveToFile(ISaveable obj, string path){
        obj.Write(path);
    }

    static void WriteToDB(IDatabase db, string data){
        db.ConnectDB("postgres");
        db.Write(data);
        db.CloseDB();
    }

}

namespace InterfaceTEst{

    public interface ISaveable {
        public int Write(string fileName); // save to file
    }

    public interface IDatabase {
        public int ConnectDB(string targetDB);
        public int Write(string data); // write data to database
        public int CloseDB();
    }

    // a db project should be able to save the project and interract with DB
    public class DatabaseProject : ISaveable, IDatabase {     
        int ISaveable.Write(string fileName){
            Console.WriteLine("saving database project to "+fileName);
            return 0; // success code
        }
        int IDatabase.Write(string data){
            Console.WriteLine($"saving {data} to db");
            return 0;
        }
        int IDatabase.ConnectDB(string targetDB)
        {
            Console.WriteLine("Connected to "+targetDB);
            return 0;
        }

        int IDatabase.CloseDB()
        {
            Console.WriteLine("close DB");
            return 0;
        }
    }

}

namespace InterfaceSegregation{ 
    // suffix _Wrong means doesn't adhere to interface segregation

    public interface IBird_Wrong{
        void Eat();
        void Fly();
    }

    public class Eagle_Wrong : IBird_Wrong{
        public void Eat(){}
        public void Fly(){}
    }
    public class Penguin_Wrong : IBird_Wrong
    {
        public void Eat(){}
        public void Fly()
        {
            throw new NotImplementedException(); // penguin can't fly
        }
    }
    
    // correct interface segregation

    public interface IBird{
        void Eat();
    }

    public interface IFlyingBird : IBird{
        void Fly();
    }

    public class Eagle : IFlyingBird
    {
        public void Eat(){}
        public void Fly(){}
    }
    public class Penguin : IBird
    {
        public void Eat(){}
    }

}