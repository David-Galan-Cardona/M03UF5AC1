using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M03UF5AC1
{
    public class Score
    {
        private string player;
        private string mission;
        private int scoring;

        public void SetPlayer(string player)
        {
            if(ComprovaPlayer(player))
            {
                this.player = player;
            }
            else
            {
                Console.WriteLine("Error: El nom del jugador no és correcte");
            }
        }
        public static bool ComprovaPlayer(string cadena)
        {
            return Regex.IsMatch(cadena, @"^[a-zA-Z]+$");
        }
        public string GetPlayer()
        {
            return this.player;
        }

        public void SetMission(string mission)
        {
            if(ComprovaMission(mission))
            {
                this.mission = mission;
            }
            else
            {
                Console.WriteLine("Error: El nom de la missió no és correcta");
            }
        }
        public string GetMission()
        {
            return this.mission;
        }
        public static bool ComprovaMission(string cadena)
        {
            return Regex.IsMatch(cadena, @"^(Alfa|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-[0-9]{3}$");
        }

        public void SetScoring(int scoring)
        {
            if(ComprovaScoring(scoring))
            {
                this.scoring = scoring;
            }
            else
            {
                Console.WriteLine("Error: La puntuació no és correcta");
            }
        }
        public int GetScoring()
        {
            return this.scoring;
        }
        public static bool ComprovaScoring(int valor)
        {
            return valor >= 0 && valor <= 500;
        }

        public Score(string player, string mission, int scoring)
        {
            SetPlayer(player);
            SetMission(mission);
            SetScoring(scoring);
        }
        public override string ToString()
        {
            return "Player: " + GetPlayer() + " Mission: " + GetMission() + " Scoring: " + GetScoring();
        }
        public static List<Score> generateUniqueRanking(List<Score> scoreList)
        {
            List<Score> uniqueRanking = new List<Score>();
            List<string> missions = new List<string>();
            List<string> players = new List<string>();
            foreach (Score s in scoreList)
            {
                if (!missions.Contains(s.GetMission()))
                {
                    missions.Add(s.GetMission());
                }
                if (!players.Contains(s.GetPlayer()))
                {
                    players.Add(s.GetPlayer());
                }
            }
            foreach (string player in players)
            {
                foreach (string mission in missions)
                {
                    int max = 0;
                    foreach (Score score in scoreList)
                    {
                        if (score.GetPlayer() == player && score.GetMission() == mission && score.GetScoring() > max)
                        {
                            max = score.GetScoring();
                        }
                    }
                    if (max != 0)
                    {
                        uniqueRanking.Add(new Score(player, mission, max));
                    }
                }
            }
            uniqueRanking = uniqueRanking.OrderByDescending(o => o.GetScoring()).ToList();
            return uniqueRanking;
        }
    }
}
