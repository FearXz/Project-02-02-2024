using System;

namespace Project_02_02_2024
{
    internal static class AgenziaDelleEntrate
    {
        // Metodo per avviare il programma e chiedere all'utente se vuole calcolare il reddito
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
        // Metodo per raccogliere i dati del contribuente e calcolare l'aliquota
        public static void CompileFormData(Contribuente contribuente)
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            contribuente.Nome = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo cognome: ");
            contribuente.Cognome = Console.ReadLine();

            contribuente.DataNascita = CreateDate();

            Console.WriteLine("Inserisci il tuo codice fiscale: ");
            contribuente.CodiceFiscale = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo sesso: ");
            contribuente.Sesso = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo comune di residenza: ");
            contribuente.ComuneResidenza = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo reddito annuale: ");
            contribuente.RedditoAnnuale = double.Parse(Console.ReadLine());

            contribuente.CalcolaImposta();
            CalcolaRedditoNetto(contribuente);

        }
        // Metodo per raccogliere la data di nascita del contribuente e controllare che sia valida
        public static DateTime CreateDate()
        {
            DateTime convertedDate;
            bool isValidDate;

            do
            {
                Console.WriteLine("Inserisci la tua data di nascita: ");
                string inputDate = Console.ReadLine();
                // Controllo che la data sia nel formato corretto
                isValidDate = DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out convertedDate);

                if (isValidDate == false)
                {
                    Console.WriteLine("Errore: Formato data non valido. Inserisci una data nel formato dd/MM/yyyy.");
                }
            } while (isValidDate == false);

            return convertedDate;
        }

        // Metodo per calcolare il reddito netto e l'imposta da versare 
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
            restart();
        }

        // Metodo per chiedere all'utente se vuole calcolare un altro reddito
        public static void restart()
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
    }

}
