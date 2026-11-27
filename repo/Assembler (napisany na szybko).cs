class Program
{
    static void Main(string[] args)
    {
        string scierzka = "Ścieżka do pliku";

        string nazwa = "nazwa scorbordu w MC";

        StreamReader plik = new StreamReader(scierzka);
        string kod = plik.ReadToEnd();
        plik.Close();


        Dictionary<string, string> słownik = new Dictionary<string, string>();

        słownik.Add("ADD", "0001");
        słownik.Add("SUB", "0011");
        słownik.Add("AND", "0101");
        słownik.Add("OR", "0111");
        słownik.Add("XOR", "1001");
        słownik.Add("RSH", "1101");
        słownik.Add("LSH", "1011");
        słownik.Add("NOT", "1111");

        słownik.Add("LDI", "0010");
        słownik.Add("LOD", "0100");
        słownik.Add("STR", "01100000");
        słownik.Add("JMP", "1000");
        słownik.Add("HLT", "1010000000000000");

        słownik.Add("r0", "0000");
        słownik.Add("r1", "0001");
        słownik.Add("r2", "0010");
        słownik.Add("r3", "0011");
        słownik.Add("r4", "0100");
        słownik.Add("r5", "0101");
        słownik.Add("r6", "0110");
        słownik.Add("r7", "0111");
        słownik.Add("r8", "1000");
        słownik.Add("r9", "1001");
        słownik.Add("r10", "1010");
        słownik.Add("r11", "1011");
        słownik.Add("r12", "1100");
        słownik.Add("r13", "1101");
        słownik.Add("r14", "1110");
        słownik.Add("r15", "1111");

        słownik.Add("=", "0000");
        słownik.Add("!=", "0100");
        słownik.Add(">=", "0010");
        słownik.Add("<", "0110");
        słownik.Add("<=", "1010");
        słownik.Add(">", "1000");
        słownik.Add("ALWAYS", "1100");




        string[] linie_kodu = kod.Split('\n', '\r');
        string[] odp = new string[linie_kodu.Length];
        for (int i = 0; linie_kodu.Length > i; i += 2)
        {
            string[] polecenia = linie_kodu[i].Split(' ');
            for (int j = 0; j < polecenia.Length; j++)
            {
                if (słownik.ContainsKey(polecenia[j]))
                    odp[i / 2] += słownik[polecenia[j]];
                else
                    odp[i / 2] += na_string(polecenia[j]);
            }
        }

        for (int i = 0; odp.Length > i; i++)
        {
            if (odp[i] is null)
                break;
            if (odp[i].Length == 12)
                odp[i] += "0000";

            odp[i] = $"scoreboard players set {i} {nazwa} " + Convert.ToInt32(odp[i], 2).ToString();

            Console.WriteLine(odp[i]);
        }


    }
    static string na_string(string liczba)
    {
        string odp = Convert.ToString(int.Parse(liczba), 2);
        if (odp.Length > 8)
            throw new Exception("Za duża liczba");
        if (odp.Length == 8)
            return odp;


        int ile = 8 - odp.Length;
        string doczep = "";
        for (int i = 0; ile > i; i++)
        {
            doczep += '0';
        }
        return doczep + odp;

    }
}