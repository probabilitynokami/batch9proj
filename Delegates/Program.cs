// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Delegates = collection of function pointer, unordered but callable


// rather than creating interface or adapting a lot of classes,
// from inaccessible libraries
// just pass it to a function pointer then call all.
using System.Reflection;
using System.Runtime.InteropServices;

public delegate void MyReceiveDataDelegate(string s);
public delegate int ValueReturningDelegate(int x);
class Program{
    static void Main(){
        TCP tcp = new();
        SerialConnection serial = new();
        IntergalacticCom icom = new();
        QuantumEntanglementCom qcom = new();

        MyReceiveDataDelegate functionPointers = tcp.Recv;// = new();
        using (TCP newcom = new())
        {

            functionPointers += serial.ReceiveDataSerially;
            functionPointers += icom.ReceiveCosmicRay;
            functionPointers += qcom.ReadQuantas;

            functionPointers += newcom.ModifyTest("hehehe").Recv; // dangling FP?? GC won't delete the object since a pointer of the objet is still in use in the delegate

        }
        functionPointers.Invoke("encryptionkey123"); // newcom should be destroyed here but the func stil called??

        //delegates on functions that returns
        ValueReturningDelegate dlg = Test;
        dlg += Tost;
        dlg += Test;
        dlg += Tost;

        int result = dlg.Invoke(0); // only return the last added function
        Console.WriteLine(result);

        // Invocation list
        // invoke delegates onebyone to get the returns of each function
        Delegate[] separatedDelegates = dlg.GetInvocationList();
        foreach(Delegate dg in separatedDelegates){ // you can also change Delegate to MyReceiveDataDelegate here...
            Console.WriteLine(dg.GetMethodInfo().Name+":"+((ValueReturningDelegate)dg).Invoke(0)); 
        }
        
        return;
    }
    public static int Test(int x){
        return 0;
    }
    public static int Tost(int x){
        return 1;
    }
}


//---------------- inaccessible code -------------------//

public class TCP : IDisposable{
    public string test="n";
    public void Recv(string enc_key){
		Console.WriteLine(""+this+enc_key);
        Console.WriteLine(test);
    }
    public TCP ModifyTest(string s){
        test = s;
        return this;
    }

    public void Dispose()
    {
        Console.WriteLine("TCP Disposed");
    }
}

public class SerialConnection{
    public void ReceiveDataSerially(string enc_key){
		Console.WriteLine(""+this+enc_key);
    }
}

public class IntergalacticCom{
    public void ReceiveCosmicRay(string enc_key){
		Console.WriteLine(""+this+enc_key);
	}
}
public class QuantumEntanglementCom{
    public void ReadQuantas(string enc_key){
		Console.WriteLine(""+this+enc_key);
	}
}
/// ------------------- end of inaccessible code --------------------///