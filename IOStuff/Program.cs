using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text;
class Program{
    static void Main(){
        Console.WriteLine(Directory.GetCurrentDirectory());

        using(FileStream fs = new FileStream("./Program.cs",FileMode.Open,FileAccess.Read)){
            StreamReader sr = new(fs);
            int counter = 0;
            while(true){
                string? result = sr.ReadLine();
                if (result is null){
                    break;
                }
                Console.WriteLine(counter.ToString("D2")+" "+result);
                counter++;
            }
        }

        using(FileStream fs = new FileStream("./test.txt",FileMode.Append,FileAccess.Write,FileShare.Read)){
            int counter = 0;
            while(true){
                string s = "hello world\n";
                byte[] bytes = new byte[s.Length];
                bytes = Encoding.ASCII.GetBytes(s);
                fs.Write(bytes,0,bytes.Length);
                fs.Flush();
                Thread.Sleep(1000);
                counter++;
                if (counter > 10){
                    break;
                }
            }
        }

        using(FileStream fs = new FileStream("./Program.cs",FileMode.Open,FileAccess.Read)){
            byte[] bytes = new byte[1000]; 
            fs.Read(bytes,0,1000);
            char[] code = Encoding.UTF8.GetChars(bytes);
            Console.WriteLine(code);
        }



    }
}