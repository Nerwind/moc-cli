using System;
using System.IO;

class f {
    public static void Main(String[] args) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Title = "Password changer for MOC tool";
        Console.Write("Нынешний пароль: ");
        string npass = Console.ReadLine();
        FileInfo bbb = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\pass.txt");
        if (!bbb.Exists) {
            Console.WriteLine("Пароль ещё не установлен");
            Console.Read();
            return;
        }
        FileStream sbbb = new FileStream(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\pass.txt", FileMode.Open);
        StreamReader rddd = new StreamReader(sbbb);
        string sbbbb = rddd.ReadToEnd();
        sbbb.Close();
        if (npass != sbbbb) {
            Console.WriteLine("Неправильный пароль.");
            Console.Read();
            return;
        }
        Console.Write("Новый пароль: ");
        string newpass = Console.ReadLine();
        bbb.Delete();
        using (var aaa = bbb.AppendText()) {
            aaa.Write(newpass);
        }
        Console.WriteLine("Новый пароль установлен.");
        Console.Read();
    }
}