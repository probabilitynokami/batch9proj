// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Delegates = collection of function pointer, unordered but callable


// rather than creating interface or adapting a lot of classes,
// from inaccessible libraries
// just pass it to a function pointer then call all.
public delegate void MyReceiveDataDelegate(string s);
class Program{
    static void Main(){
        TCP tcp = new();
        SerialConnection serial = new();
        IntergalacticCom icom = new();
        QuantumEntanglementCom qcom = new();

        MyReceiveDataDelegate functionPointers = tcp.Recv;// = new();
        functionPointers += serial.ReceiveDataSerially;
        functionPointers += icom.ReceiveCosmicRay;
        functionPointers += qcom.ReadQuantas;

        functionPointers.Invoke("encryptionkey123");
        return;
    }
}


//---------------- inaccessible code -------------------//

public class TCP{
    public void Recv(string enc_key){
		Console.WriteLine(""+this+enc_key);
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