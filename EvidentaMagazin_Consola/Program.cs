using System;
using System.Configuration;
using System.IO;

using LibrarieModele;
using NivelStocareDate;

namespace EvidentaAlimente_Consola
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["Alimente.txt"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareAlimente_FisierText adminAlimente = new AdministrareAlimente_FisierText(caleCompletaFisier);
            int nrAlimente = 0;
            Aliment[] alimente = adminAlimente.GetAlimente(out nrAlimente);
            Aliment aliment = new Aliment();
            adminAlimente.GetAlimente(out nrAlimente);
            Client client = new Client();
            string numeFisier2 = ConfigurationManager.AppSettings["Clienti.txt"];
            AdministrareClient_FisierText adminClienti = new AdministrareClient_FisierText("Clienti.txt");
            int nrClienti = 0;
            adminClienti.GetClienti(out nrClienti);
            string optiune;
            do
            {
                Console.WriteLine("\n\n\t\tQ. Introducere informatii aliment.");
                Console.WriteLine("\t\tW. Afisarea ultimului aliment introdus.");
                Console.WriteLine("\t\tE. Afisare aliment din fisier.");
                Console.WriteLine("\t\tR. Salvare aliment in fisier.");
                Console.WriteLine("\t\tT. Cautare aliment dupa anumite criterii.\n");
                Console.WriteLine("\n\t\tA. Introducere informatii client.");
                Console.WriteLine("\t\tS. Afisarea ultimului client introdus.");
                Console.WriteLine("\t\tD. Afisare client din fisier.");
                Console.WriteLine("\t\tF. Salvare client in fisier.");
                Console.WriteLine("\t\tG. Cautare client dupa anumite criterii.\n");
                Console.WriteLine("\t\tX. Inchidere program.\n");
                Console.WriteLine("\n\t\tAlegeti o optiune.\n\n");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "Q":
                        aliment = CitireAlimentTastatura();
                        break;
                    case "W":
                        AfisareAliment(aliment);
                        break;
                    case "E":
                        alimente = adminAlimente.GetAlimente(out nrAlimente);
                        AfisareAlimente(alimente, nrAlimente);
                        break;
                    case "R":
                        int idAliment = nrAlimente + 1;
                        aliment.Cod = idAliment;
                        adminAlimente.AddAliment(aliment);
                        nrAlimente = nrAlimente + 1;
                        Console.WriteLine("\n\t\tAliment salvat cu succes!\n\n");
                        break;
                    case "T":
                        Aliment[] Alimente = adminAlimente.GetAlimente(out nrAlimente);
                        Console.WriteLine("\n\t\tPuteti alege din urmatoarele criterii:\n\t\t\tTip -> 1\n\t\t\tDenumire -> 2\n\t\t\tProducator -> 3\n\n\t\t\tCriteriul: ");
                        CautareAliment(Convert.ToInt32(Console.ReadLine()), nrAlimente, Alimente);
                        break;
                    case "A":
                        client = CitireClientTastatura();
                        break;
                    case "S":
                        AfisareClient(client);
                        break;
                    case "D":
                        Client[] clienti = adminClienti.GetClienti(out nrClienti);
                        AfisareClienti(clienti, nrClienti);
                        break;
                    case "F":
                        int idClient = nrClienti + 1;
                        client.Cod = idClient;
                        adminClienti.AddClient(client);
                        nrClienti = nrClienti + 1;
                        Console.WriteLine("\n\t\tClient salvat cu succes!\n\n");
                        break;
                    case "G":
                        Client[] Clienti = adminClienti.GetClienti(out nrClienti);
                        Console.WriteLine("\n\t\tPuteti alege din urmatoarele criterii:\n\t\t\tPrenume -> 1\n\t\t\tNume -> 2\n\t\t\tVarsta -> 3\n\t\t\tNumar de Telefon -> 4\n\n\t\t\tCriteriul: ");
                        CautareClient(Convert.ToInt32(Console.ReadLine()), nrClienti, Clienti);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("\n\t\tOptiune inexistenta.");
                        break;
                }
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }
        public static void AfisareAliment(Aliment aliment)
        {
            string infoAliment = string.Format("\n\t\tAlimentul ce are codul #{0} este {1}, produs de {2}, este {3}, costa {4} lei si avem {5} bucati.",
                   aliment.Cod,
                   aliment.Denumire ?? " NECUNOSCUT ",
                   aliment.Producator ?? " NECUNOSCUT ",
                   aliment.Tip ?? " NECUNOSCUT ",
                   aliment.Pret,
                   aliment.Stoc);
            Console.WriteLine(infoAliment);
        }
        public static void AfisareAlimente(Aliment[] alimente, int nrAlimente)
        {
            Console.WriteLine("\n\t\tAlimentele sunt:");
            for (int contor = 0; contor < nrAlimente; contor++)
            {
                AfisareAliment(alimente[contor]);
            }
        }
        public static Aliment CitireAlimentTastatura()
        {
            Console.WriteLine("\n\t\tDenumire: ");
            string Denumire = Console.ReadLine();
            Console.WriteLine("\n\t\tProducator: ");
            string Producator = Console.ReadLine();
            Console.WriteLine("\n\t\tTip: ");
            string Tip = Console.ReadLine();
            Console.WriteLine("\n\t\tPret: ");
            int Pret = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\t\tStoc: ");
            int Stoc = int.Parse(Console.ReadLine());
            Aliment aliment = new Aliment(Denumire, Producator, Tip, Pret, Stoc);
            return aliment;
        }
        public static void CautareAliment(int criteriu, int nrAlimente, Aliment[] alimente)
        {
            switch (criteriu)
            {
                case 1:
                    Console.WriteLine("\n\t\tIntroduceti tipul alimentelor pentru cautare: ");
                    string date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatoarele alimente cu proprietati similare: ");
                    for (int i = 0; i < nrAlimente; i++)
                        if (alimente[i].Tip == date)
                            Console.WriteLine(alimente[i].Info());
                    break;
                case 2:
                    Console.WriteLine("\n\t\tIntroduceti denumirea alimentelor pentru cautare: ");
                    date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatoarele alimente cu proprietati similare: ");
                    for (int i = 0; i < nrAlimente; i++)
                        if (alimente[i].Denumire == date)
                            Console.WriteLine(alimente[i].Info());
                    break;
                case 3:
                    Console.WriteLine("\n\t\tIntroduceti producatorul alimentelor pentru cautare: ");
                    date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatoarele alimente cu proprietati similare: ");
                    for (int i = 0; i < nrAlimente; i++)
                        if (alimente[i].Producator == date)
                            Console.WriteLine(alimente[i].Info());
                    break;
                default:
                    Console.WriteLine("\n\t\tOptiunea nu exista!");
                    break;
            }
        }
        public static void AfisareClient(Client client)
        {
            string infoClient = string.Format("Clientul cu ID-ul #{0} se numeste {1} {2}, are {4} ani, numar de telefon: {3}.",
                   client.Cod,
                   client.Prenume ?? " NECUNOSCUT ",
                   client.Nume ?? " NECUNOSCUT ",
                   client.Telefon ?? " NECUNOSCUT ",
                   client.Varsta);
            Console.WriteLine(infoClient);
        }
        public static void AfisareClienti(Client[] clienti, int nrClienti)
        {
            Console.WriteLine("Alimentele sunt:");
            for (int contor = 0; contor < nrClienti; contor++)
            {
                AfisareClient(clienti[contor]);
            }
        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("\n\t\tPrenume: ");
            string Prenume = Console.ReadLine();
            Console.WriteLine("\n\t\tNume: ");
            string Nume = Console.ReadLine();
            Console.WriteLine("\n\t\tNumar telefon: ");
            string Telefon = Console.ReadLine();
            Console.WriteLine("\n\t\tVarsta: ");
            string Varsta = Console.ReadLine();
            Client client = new Client(Prenume, Nume, Telefon, Varsta);
            return client;
        }
        public static void CautareClient(int criteriu, int nrClienti, Client[] clienti)
        {
            switch (criteriu)
            {
                case 1:
                    Console.WriteLine("\n\t\tIntroduceti prenumele clientului pe care il cautati: ");
                    string date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatorii clienti cu acest prenume: ");
                    for (int i = 0; i < nrClienti; i++)
                        if (clienti[i].Prenume == date)
                            Console.WriteLine(clienti[i].Info());
                    break;
                case 2:
                    Console.WriteLine("\n\t\tIntroduceti numele clientului pe care il cautati: ");
                    date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatorii clienti cu acest nume: ");
                    for (int i = 0; i < nrClienti; i++)
                        if (clienti[i].Nume == date)
                            Console.WriteLine(clienti[i].Info());
                    break;
                case 3:
                    Console.WriteLine("\n\t\tIntroduceti varsta clientului pe care il cautati: ");
                    date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatorii clienti cu acesta varsta: ");
                    for (int i = 0; i < nrClienti; i++)
                        if (clienti[i].Varsta == date)
                            Console.WriteLine(clienti[i].Info());
                    break;
                case 4:
                    Console.WriteLine("\n\t\tIntroduceti numarul de telefon al clientului pe care il cautati: ");
                    date = Console.ReadLine();
                    Console.WriteLine("\n\t\tS-au gasit urmatorii clienti cu acest numar de telefon: ");
                    for (int i = 0; i < nrClienti; i++)
                        if (clienti[i].Telefon == date)
                            Console.WriteLine(clienti[i].Info());
                    break;
                default:
                    Console.WriteLine("\n\t\tOptiunea nu exista!");
                    break;
            }
        }
    }
}
