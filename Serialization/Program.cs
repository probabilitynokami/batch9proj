using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Serialization;
class Program{
    static void Main(){
        DataClass d = new(10);
        Console.WriteLine(JsonSerializer.Serialize(d)); // only public fields captured
        Console.WriteLine();

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataClass));
        xmlSerializer.Serialize(Console.OpenStandardOutput(),d); // public variable captured
        Console.WriteLine();

        // using(var fs = new FileStream("./test.xml",FileMode.Create)){
        //     xmlSerializer.Serialize(fs,d); // public variable captured
        //     fs.Flush();
        // }

        using(var fs = new FileStream("./test.xml",FileMode.Open,FileAccess.Read)){
            DataClass d2 = (DataClass)xmlSerializer.Deserialize(fs);
            Console.WriteLine(string.Join(" ",d2.ABC));
        }
        
        using(var fs = new FileStream("./testt.json",FileMode.Open,FileAccess.Read)){
            DataClass d2 = JsonSerializer.Deserialize<DataClass>(fs);
            Console.WriteLine(string.Join(" ",d2.ABC));
        }


        SerializableDataClass sd = new();

        // using(var fs = new FileStream("./serializabledataclass.json",FileMode.Create,FileAccess.Write)){
        //     DataContractJsonSerializer serializer = new(typeof(SerializableDataClass));
        //     serializer.WriteObject(fs,sd);
        // }
        using(var fs = new FileStream("./serializabledataclass.json",FileMode.Open,FileAccess.Read)){
            DataContractJsonSerializer serializer = new(typeof(SerializableDataClass));
            var sdd = (SerializableDataClass)serializer.ReadObject(fs);
            Console.WriteLine(sd.GetData1() + " " +sd.data2+" "+sd.data3);
            Console.WriteLine(sdd.GetData1() + " " +sdd.data2+" "+sdd.data3);
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


[DataContract]
class SerializableDataClass{

    [DataMember]
    private int data1 = 1;

    [DataMember]
    public int data2 = 2;

    public int data3 = 3;
    public int GetData1(){
        return data1;
    }

}