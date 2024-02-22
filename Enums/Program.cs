
enum POSIXIOCTLError {
    EBADF,
    EFAULT,
    EINVAL,
    ENOTTY,
    OK
}

static class ExtensionPOSIXIOCTLError{
    public static void Print(this POSIXIOCTLError x){
        Console.WriteLine(x);
    }
    public static void Print(this int x){
        Console.WriteLine(x);
    }
    public static void Print(this string x){
        Console.WriteLine(x);
    }
    public static void Print(this char x){
        Console.WriteLine(x);
    }
}

class Program{
    static void Main(){

        OpenIO("/dev/ttyUSB1").Print();
        OpenIO("/dev/ttyACM0").Print();
        OpenIO("/dev/ttyACM1").Print();
        OpenIO("/dev/ttyACM2").Print();
        OpenIO("/dev/ttyACM3").Print();


        ((char)OpenIO("")).Print();
        return;
    }

    static POSIXIOCTLError OpenIO(string ttyDevice){
        if (ttyDevice == "/dev/ttyACM0"){
            return POSIXIOCTLError.ENOTTY;
        }
        if (ttyDevice == "/dev/ttyACM1"){
            return POSIXIOCTLError.EINVAL;
        }
        if (ttyDevice == "/dev/ttyACM2"){
            return POSIXIOCTLError.EBADF;
        }
        if (ttyDevice == "/dev/ttyACM3"){
            return POSIXIOCTLError.EFAULT;
        }
        if (ttyDevice == "/dev/ttyUSB0"){
            return POSIXIOCTLError.OK;
        }
        return POSIXIOCTLError.ENOTTY;
    }
}