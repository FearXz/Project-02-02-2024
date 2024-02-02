using System;

namespace Project_02_02_2024
{
    internal static class AgenziaDelleEntrate
    {
        // Menu Metodo per avviare il programma e chiedere all'utente se vuole calcolare il reddito
        public static void Menu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("A G E N Z I A  D E L L E  E N T R A T E");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("* Benvenuto allo sportello, Vuoi calcolare il tuo reddito ? y/n");

            string confermaYN = Console.ReadLine();

            if (confermaYN == "y")
            {
                Contribuente contribuente = new Contribuente();
                CompileFormData(contribuente);
            }
            else { Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello."); Console.ReadLine(); }
        }
        // CompileFormData Metodo per raccogliere i dati del contribuente 
        public static void CompileFormData(Contribuente contribuente)
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            contribuente.Nome = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo cognome: ");
            contribuente.Cognome = Console.ReadLine();

            contribuente.DataNascita = ControlloDate();

            contribuente.CodiceFiscale = ControlloCodiceFiscale();

            contribuente.Sesso = ControlloSesso();

            Console.WriteLine("Inserisci il tuo comune di residenza: ");
            contribuente.ComuneResidenza = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo reddito annuale: ");
            contribuente.RedditoAnnuale = double.Parse(Console.ReadLine());

            CalcolaRedditoNetto(contribuente);

        }

        // CalcolaRedditoNetto Metodo per calcolare il reddito netto e l'imposta da versare 
        // in base al reddito annuale dichiarato dal contribuente 
        public static void CalcolaRedditoNetto(Contribuente contribuente)
        {
            Console.WriteLine("Vorresti calcolare il tuo Reddito Netto? Y/n");
            string calcolareRedditoNetto = Console.ReadLine();

            if (calcolareRedditoNetto == "y") contribuente.CalcolaImposta();
            else { Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello."); Console.ReadLine(); }

            Console.WriteLine("===============================================");
            Console.WriteLine("C A L C O L O  I M P O S T A  D A  V E R S A R E");
            Console.WriteLine("===============================================\n");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Nato il: {contribuente.DataNascita.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}\n");
            Console.WriteLine($"Reddito Lordo Dichiarato: {contribuente.RedditoAnnuale}");
            Console.WriteLine($"Reddito Netto: {contribuente.RedditoAnnualeNetto}\n");
            Console.WriteLine($"IMPOSTA DA VERSARE: {contribuente.Imposta}");
            Console.WriteLine("===============================================\n");
            Restart();
        }

        // restart Metodo per chiedere all'utente se vuole calcolare un altro reddito
        public static void Restart()
        {
            Console.WriteLine("Vuoi calcolare un altro reddito? y/n");
            string confermaYN = Console.ReadLine();

            if (confermaYN == "y")
            {
                Contribuente contribuente = new Contribuente();
                CompileFormData(contribuente);
            }
            else { Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello."); Console.ReadLine(); }
        }

        // ControlloCodiceFiscale Metodo per controllare che il codice fiscale sia valido
        public static string ControlloCodiceFiscale()
        {
            Console.WriteLine("Inserisci il tuo codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            if (codiceFiscale.Length == 16) return codiceFiscale;
            else
            {
                Console.WriteLine("Errore: Il codice fiscale deve essere di 16 caratteri.");
                return ControlloCodiceFiscale();
            }
        }

        // ControlloDate Metodo per raccogliere la data di nascita del contribuente e controllare che sia valida
        public static DateTime ControlloDate()
        {
            DateTime convertedDate;

            Console.WriteLine("Inserisci la tua data di nascita formato gg/mm/aaaa : ");
            string inputDate = Console.ReadLine();

            // Controllo che la data sia nel formato corretto
            if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out convertedDate))
            { return convertedDate; }
            else
            {
                // Se la data non è nel formato corretto, chiedo all'utente di reinserirlo
                Console.WriteLine("Errore: Inserisci la data nel formato corretto (gg/mm/aaaa).");
                return ControlloDate();
            }

        }
        // ControlloSesso Metodo per controllare che il sesso sia valido
        public static string ControlloSesso()
        {
            Console.WriteLine("Inserisci il tuo sesso M o F: ");
            string sesso = Console.ReadLine().ToUpper();

            if (sesso == "M") return "Uomo";
            else if (sesso == "F") return "Donna";
            else
            {
                Console.WriteLine("Errore: Inserisci M o F.");
                return ControlloSesso();
            }
        }
    }

}
