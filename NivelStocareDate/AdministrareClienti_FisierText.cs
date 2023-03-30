using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareClient_FisierText
    {
        private const int NR_MAX_CLIENTI = 100;
        private string numeFisier;
        public AdministrareClient_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddClient(Client client)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }
        public Client[] GetClienti(out int nrClienti)
        {
            Client[] clienti = new Client[NR_MAX_CLIENTI];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrClienti = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti[nrClienti++] = new Client(linieFisier);
                }
            }
            return clienti;
        }
    }
}