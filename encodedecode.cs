using System;
using System.Collections.Generic;
using prikols;

namespace Moc {
    public class Cipher {
        private static BetterArray<char> alpeng = new BetterArray<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray(), 0);
        private static BetterArray<char> alprus = new BetterArray<char>("абвгдёежзийклмнопрстуфхцчшщъыьэюя".ToCharArray(), 0);
	    private static BetterArray<char> alpsym = new BetterArray<char>("1234567890@#₽_&-+()/*\"':;!?№—–·±[<{]}>★†‡”„“«»’‚‘‹›¡¿‽~`|•√π÷×¶∆§£€$¢¥₱^←↑↓→°∞≠≈=‰℅%©®™✓.".ToCharArray(), 0);

        private static Dictionary<char, int> enc = new Dictionary<char, int>();
        private static Dictionary<char, int> rus = new Dictionary<char, int>();
	    private static Dictionary<char, int> sym = new Dictionary<char, int>();

        private static Dictionary<int, char> encrr = new Dictionary<int, char>();
        private static Dictionary<int, char> rusrr = new Dictionary<int, char>();
	    private static Dictionary<int, char> symrr = new Dictionary<int, char>();

        public Cipher(ulong pass) {
            int a = 0;
            foreach (char cc in alpeng.AsArray) {
                enc.Add(cc, a += 13 + (int)pass);
                encrr.Add(a, cc);
            }
            a = 0;
            foreach (char cc in alprus.AsArray) {
                rus.Add(cc, a += 1581 + (int)pass);
                rusrr.Add(a, cc);
            }
            a = 0;
            foreach (char cc in alpsym.AsArray) {
                sym.Add(cc, a += 18000 + (int)pass);
                symrr.Add(a, cc);
            }
        }

        public string Encode(string input) {
            List<string> retstr = new List<string>();
            foreach (char cc in input.ToCharArray()) {
                if (enc.ContainsKey(Convert.ToChar(cc.ToString().ToLowerInvariant()))) {
                    retstr.Add(enc[Convert.ToChar(cc.ToString().ToLowerInvariant())].ToString());
                } else if (rus.ContainsKey(Convert.ToChar(cc.ToString().ToLowerInvariant()))) {
                    retstr.Add(rus[Convert.ToChar(cc.ToString().ToLowerInvariant())].ToString());
                } else if (cc == ' ') retstr.Add(" ");
                else if (sym.ContainsKey(Convert.ToChar(cc.ToString().ToLowerInvariant()))) {
                    retstr.Add(sym[Convert.ToChar(cc.ToString().ToLowerInvariant())].ToString());
                }
            }
            return String.Join(";", retstr.ToArray());
        }

        public string Decode(string input) {
            string[] penis = input.Split(';');
            string retstr = null;
            foreach (string cc in penis) {
		if (cc == " ") { 
		    retstr += cc;
		    continue;
		}
		int a = Convert.ToInt32(cc);
                if (enc.ContainsValue(a)) {
                    retstr += encrr[a];
                } else if (rus.ContainsValue(a)) {
                    retstr += rusrr[a];
                } else if (sym.ContainsValue(a)) {
                    retstr += symrr[a];
                }
		else retstr += cc;
            }
            return retstr;
        }
    }
}