using System;

namespace M03UF5AC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string Intro = "Introdueix 10 scores", Player = "Introdueix el nom del jugador", Mission = "Introdueix la missió", 
                Scoring = "Introdueix la puntuació", Ranking = "El ranking de jugadors és: ";
            List<Score> scores = new List<Score>();
            string player, mission;
            int scoring;
                Console.WriteLine(Intro);
            while (scores.Count < 10)
            {
                Console.WriteLine(Player);
                player = Console.ReadLine() ?? "";
                Console.WriteLine(Mission);
                mission = Console.ReadLine() ?? "";
                Console.WriteLine(Scoring);
                scoring = int.Parse(Console.ReadLine());
                if (Score.ComprovaPlayer(player) && Score.ComprovaMission(mission) && Score.ComprovaScoring(scoring))
                {
                    scores.Add(new Score(player, mission, scoring));
                }
            }
            //test values
            /*scores.Add(new Score("Laura", "Alfa-001", 120));
            scores.Add(new Score("Hugo", "Alfa-002", 150));
            scores.Add(new Score("Laura", "Alfa-001", 135));
            scores.Add(new Score("Tomas", "Alfa-001", 200));
            scores.Add(new Score("Laura", "Alfa-002", 175));*/
            Console.WriteLine(Ranking);

            foreach (Score s in Score.generateUniqueRanking(scores))
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}