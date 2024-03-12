using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
class Program{
    static void Main(){
        DataClass d = new(10);
        Console.WriteLine(JsonSerializer.Serialize(d)); // only public fields captured
        Console.WriteLine();

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataClass));
        xmlSerializer.Serialize(Console.OpenStandardOutput(),d); // public variable captured

        // using(var fs = new FileStream("./test.xml",FileMode.Create)){
        //     xmlSerializer.Serialize(fs,d); // public variable captured
        //     fs.Flush();
        // }

        using(var fs = new FileStream("./test.xml",FileMode.Open,FileAccess.Read)){
            DataClass d2 = (DataClass)xmlSerializer.Deserialize(fs);
            Console.WriteLine(d2.ABC);
        }
        
        using(var fs = new FileStream("./test.json",FileMode.Open,FileAccess.Read)){
            DataClass d2 = JsonSerializer.Deserialize<DataClass>(fs);
            Console.WriteLine(d2.ABC);
        }

    }
}

public class DataClass{
    private int x;
    public int a = 0;
    public int Yeah{get;set;}
    public int[] ABC{get;set;}
    void SetX(int x){
        this.x = x;
    }

    int getX(){
        return x;
    }

    public DataClass() : this(0){
    }

    public DataClass(int x){
        this.x = x;
        ABC = [1,2,3,4];
    }
}