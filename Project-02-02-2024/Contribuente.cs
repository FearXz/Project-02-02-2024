using System;

namespace Project_02_02_2024
{
    internal class Contribuente
    {
        // Proprietà della classe Contribuente
        private string _nome;
        public string Nome { get => _nome; set => _nome = value; }

        private string _cognome;
        public string Cognome { get => _cognome; set => _cognome = value; }

        private DateTime _dataNascita;
        public DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }

        private string _codiceFiscale;
        public string CodiceFiscale { get => _codiceFiscale; set => _codiceFiscale = value; }

        private string _sesso;
        public string Sesso { get => _sesso; set => _sesso = value; }

        private string _comuneResidenza;
        public string ComuneResidenza { get => _comuneResidenza; set => _comuneResidenza = value; }

        private double _redditoAnnuale;
        public double RedditoAnnuale { get => _redditoAnnuale; set => _redditoAnnuale = value; }

        private double _imposta;
        public double Imposta { get => _imposta; set => _imposta = value; }

        private double _redditoAnnualeNetto;
        public double RedditoAnnualeNetto { get => _redditoAnnualeNetto; set => _redditoAnnualeNetto = value; }

        // Costruttore della classe Contribuente, potevo anche non metterlo perchè è di default ma l'ho messso perchè lo chiedeva l'esercizio
        public Contribuente() { }

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

