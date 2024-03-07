

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

// go read this https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task

class Program{
    static void Main(){
        Task<int> task = Task.Run<int>(Calculate);

        Console.WriteLine(task.Result); // this will wait for task to return



        List<Task<int>> taskList = [];

        for(int i = 0; i<25; i++){
            taskList.Add(Task.Run<int>(Calculate));
        }

        Task.WhenAny(taskList.ToArray()).ContinueWith((Task<Task<int>> a)=>Console.WriteLine("wheee"+a.Id));

        Console.WriteLine(taskList[5].IsCompleted);
        Console.WriteLine(taskList[5].IsFaulted);
        while(true){
            foreach(var ttask in taskList){
                ;
        //        Console.Write(ttask.Status.ToString()+",");
            }
            // Console.WriteLine();
            Thread.Sleep(1000);
        }


        Console.WriteLine(taskList[5].IsCompleted);
        Console.WriteLine(taskList[5].IsFaulted);

        Console.WriteLine("hoho");
    }
    static int Calculate(){
        int x = 0;
        while(x < int.MaxValue){
            x++;
        }
        return x;
    }
    static void Tmp(){
        ;
    }
}