using System;
using System.Collections.Generic;
using System.Linq;

namespace slovnik
{
    class Program
    {

        static void addWord(Dictionary<string, string> disc) //Funkce pro přidání slova do slovníku
        {
            string newCZ, newEN;
            Console.Write("Zadejte nové slova v angličtině: ");
            newEN = Console.ReadLine();
            Console.Write("Zadejte nové slova v češtině: ");
            newCZ = Console.ReadLine();
            disc.Add(newEN, newCZ);
        }

        static void printDisc(List<string> list, Dictionary<string, string> disc) //Funkce pro výpis slovníku
        {
            Console.WriteLine("|     EN     |     CZ     |");
            foreach (var kvp in list)
            {
                Console.WriteLine("| {0,-10} | {1,-10} |", kvp, disc[kvp]);
            }
            Console.WriteLine("Počet slov je {0}", disc.Count);
        }

        static void answerWord(List<string> list, Dictionary<string, string> disc)
        {
            Random r = new Random();
            for(int i = 0; i < 3; i++) { 
                int index = r.Next(list.Count);
                string word = (list[index]);
                Console.Write("Napište česky slovo '{0}': ", word);
                string answer = Console.ReadLine();
                if (disc[word] == answer)
                {
                    Console.WriteLine("Správně!");
                }
                else
                {
                    Console.WriteLine("Špatně!");
                }
            }
        }


        static void Main(string[] args)
        {
            string test="ano";
            var englishDict = new Dictionary<string, string>(){
                {"dog", "pes"},
                {"cat", "kočka"},
                {"car", "auto"}
            };
            while (test=="ano") {
                addWord(englishDict);
                do {
                    Console.Write("Přejete si přidat další slovo?(ano/ne): ");
                    test = Console.ReadLine();
                    if(test != "ano" && test != "ne")
                    {
                        Console.Write("Chyba. ");
                    }
                } while (test != "ano" && test != "ne");
            }

            var list = englishDict.Keys.ToList();
            list.Sort();

            answerWord(list, englishDict);

            printDisc(list, englishDict);

            Console.ReadLine();
        }
    }
}
