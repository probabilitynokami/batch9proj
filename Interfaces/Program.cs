// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using Microsoft.Win32.SafeHandles;

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


public interface ISaveable {
    public int Write(string fileName); // save to file
}

public interface IDatabase {
    public int ConnectDB(string targetDB);
    public int Write(string data); // write data to database
    public int CloseDB();
}

public class DatabaseProject : ISaveable, IDatabase { // a db project should be able to save the project and interract with DB
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
