using System;

namespace Project_02_02_2024
{
    internal class Contribuente
    {
        // Proprietà della classe Contribuente
        private string nome;
        public string Nome { get => nome; set => nome = value; }

        private string cognome;
        public string Cognome { get => cognome; set => cognome = value; }

        private DateTime dataNascita;
        public DateTime DataNascita { get => dataNascita; set => dataNascita = value; }

        private string codiceFiscale;
        public string CodiceFiscale { get => codiceFiscale; set => codiceFiscale = value; }

        private string sesso;
        public string Sesso { get => sesso; set => sesso = value; }

        private string comuneResidenza;
        public string ComuneResidenza { get => comuneResidenza; set => comuneResidenza = value; }

        private double redditoAnnuale;
        public double RedditoAnnuale { get => redditoAnnuale; set => redditoAnnuale = value; }

        private double imposta;
        public double Imposta { get => imposta; set => imposta = value; }

        private double redditoAnnualeNetto;
        public double RedditoAnnualeNetto { get => redditoAnnualeNetto; set => redditoAnnualeNetto = value; }

        // Metodo per calcolare l'aliquota in base al reddito annuale in base alla tabella delle aliquote
        public double CalcolaImposta()
        {
            switch (RedditoAnnuale)
            {
                case var reddito when reddito >= 0 && reddito <= 15000:
                    Imposta = RedditoAnnuale * 23 / 100;
                    break;
                case var reddito when reddito <= 28000:
                    Imposta = 3450 + ((RedditoAnnuale - 15000) * 27 / 100);
                    break;
                case var reddito when reddito <= 55000:
                    Imposta = 6960 + ((RedditoAnnuale - 28000) * 38 / 100);
                    break;
                case var reddito when reddito <= 75000:
                    Imposta = 17220 + ((RedditoAnnuale - 55000) * 41 / 100);
                    break;
                case var reddito when reddito > 75000:
                    Imposta = 25420 + ((RedditoAnnuale - 75900) * 43 / 100);
                    break;
                default:
                    Console.WriteLine("Reddito annuale non inserito. Riprova ad inserire");
                    Console.WriteLine("il tuo reddito annuale per effettuare il calcolo.");
                    AgenziaDelleEntrate.Menu();
                    break;
            }
            return RedditoAnnualeNetto = RedditoAnnuale - Imposta;
        }
    }
}

