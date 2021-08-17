using System;
using Moc;
using System.IO;

class passworder {
    public static void Main() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Title = "MOC tool V3";
        FileInfo aye = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\pass.txt");
        if (!aye.Exists) {
            Console.Write("Придумайте пароль (только цифры): ");
            string pass = Console.ReadLine();
            Console.Write("Пароль ещё раз: ");
            string pass22 = Console.ReadLine();
            if (pass != pass22) {
                Console.WriteLine("Пароли не совпадают.");
                Console.Read();
                return;
            }
            using (var penis = aye.AppendText()) {
                penis.Write(pass);
                penis.Close();
            }
            Console.WriteLine("Пароль установлен.");
        }
        Console.Write("Введите пароль: ");
        string tttttttttt = Console.ReadLine();
        FileStream sbbb = new FileStream(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\pass.txt", FileMode.Open);
        StreamReader rddd = new StreamReader(sbbb);
        string sbbbb = rddd.ReadToEnd();
        sbbb.Close();
        if (tttttttttt != sbbbb) {
            Console.WriteLine("Неправильный пароль.");
            Console.Read();
            return;
        }
        Cipher enc = new Cipher((ulong)Convert.ToInt32(sbbbb));
        Console.WriteLine("1 - закодировать\n2 - расшифровать");
        string b = Console.ReadLine();
        if (b == "1") {
            Console.Write("Путь к файлу: ");
            string txt = Console.ReadLine();
            FileInfo text = new FileInfo(txt);
            Console.Write("Текст для зашифровки: ");
            string tte = Console.ReadLine();
            using (var bgb = text.AppendText()) {
                bgb.Write(enc.Encode(tte));
                bgb.Close();
            }
            Console.WriteLine("Успешно записано.");
        } else if (b == "2") {
            Console.Write("Путь к файлу: ");
            string txt = Console.ReadLine();
            FileInfo text = new FileInfo(txt);
            if (!text.Exists) {
                Console.WriteLine("Такого файла не существует");
                Console.Read();
                return;
            }
            FileStream stream = new FileStream(txt, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string str = reader.ReadToEnd();
            stream.Close();
            Console.WriteLine("Результат: " + enc.Decode(str));
        }
        Console.Read();
    }
}