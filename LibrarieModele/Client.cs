using System;

namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int PRENUME = 0;
        private const int NUME = 1;
        private const int TELEFON = 2;
        private const int VARSTA = 3;
        private const int COS = 4;
        private const int COD = 5;
        public static int idClient { get; set; } = 0;
        public string Prenume { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Varsta { get; set; }
        public int Cos { get; set; }
        public int Cod { get; set; }
        public string NumeComplet { get { return Prenume + " - " + Nume; } }
        public Client(string _prenume = "", string _nume = "", string _telefon = "", string _varsta = "")
        {
            Prenume = _prenume;
            Nume = _nume;
            Telefon = _telefon;
            Varsta = _varsta;
            Cod = ++idClient;
            Cos = 0;
        }
        public Client(string date)
        {
            string[] infoClient = date.Split(SEPARATOR_PRINCIPAL_FISIER);
            Prenume = infoClient[PRENUME];
            Nume = infoClient[NUME];
            Telefon = infoClient[TELEFON];
            Varsta = infoClient[VARSTA];
            Cod = Convert.ToInt32(infoClient[COD]);
            idClient = Cod;
            Cos = Convert.ToInt32(infoClient[COS]);
        }
        public string Info()
        {
            string info = string.Format("\n\t\tCod: {0}\n\t\tPenume: {1}\n\t\tNume: {2}\n\t\tNumar de Telefon: {3}\n\t\tVarsta: {4}\n\t\tCos: {5}\n\n",
                Cod.ToString(),
                (Prenume ?? " NECUNOSCUT "),
                (Nume ?? " NECUNOSCUT "),
                (Telefon ?? " NECUNOSCUT "),
                (Varsta ?? " NECUNOSCUT "),
                Cos.ToString());
            return info;
        }
        public string ConversieLaSir()
        {
            return "#" + Cod.ToString() + " - " + Prenume + " - " + Nume + " - " + Telefon + "\nPret: " + Varsta + "\nStoc: " + Cos.ToString() + "\n";
        }
        public string ConversieLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Prenume ?? "NECUNOSCUT"),
                (Nume ?? " NECUNOSCUT "),
                (Telefon ?? " NECUNOSCUT "),
                (Varsta ?? " NECUNOSCUT "),
                Cod.ToString(),
                Cos.ToString());
            return s;
        }
    }
}