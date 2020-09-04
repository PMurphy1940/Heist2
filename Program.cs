using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist2 {
    partial class Program {
        static void Main (string[] args) {
            Console.Clear ();
            Console.WriteLine ("Hello Bankheist!");

            Hacker patrick = new Hacker () {
                Name = "Patrick",
                PercentageCut = 7,
                SkillLevel = 37
            };
            Hacker rose = new Hacker () {
                Name = "Rose",
                PercentageCut = 15,
                SkillLevel = 54
            };
            Hacker mo = new Hacker () {
                Name = "Mo",
                PercentageCut = 15,
                SkillLevel = 54
            };
            Hacker andy = new Hacker () {
                Name = "Andy",
                PercentageCut = 20,
                SkillLevel = 76
            };
            Muscle barney = new Muscle () {
                Name = "Barney",
                PercentageCut = 10,
                SkillLevel = 41
            };
            Muscle vito = new Muscle () {
                Name = "Vito",
                PercentageCut = 15,
                SkillLevel = 56
            };
            Muscle clamps = new Muscle () {
                Name = "Clamps",
                PercentageCut = 20,
                SkillLevel = 72
            };
            LockSpecialist nick = new LockSpecialist () {
                Name = "Nick",
                PercentageCut = 10,
                SkillLevel = 32
            };
            LockSpecialist tom = new LockSpecialist () {
                Name = "Tom",
                PercentageCut = 15,
                SkillLevel = 51
            };
            LockSpecialist jonas = new LockSpecialist () {
                Name = "Jonas",
                PercentageCut = 20,
                SkillLevel = 69
            };

            List<IRobber> rolodex = new List<IRobber> () {
                patrick,
                rose,
                mo,
                andy,
                barney,
                vito,
                clamps,
                nick,
                tom,
                jonas
            };

            List<string> specailities = new List<string> () {
                "Hacker (Disables alarms)",
                "Muscle (Disarms guards)",
                "Lock Specialist (Cracks vault)"
            };

            printRolodex (rolodex);

        }

        static void printRolodex (List<IRobber> rolodex) {
            static string job (IRobber robber) {
                string Target = robber.ToString ();
                string[] SplitTarget = Target.Split (".");
                return SplitTarget[1];
            }
            List<IRobber> sortedRolodex = rolodex.OrderBy (a => job (a)).ToList ();
            // rolodex.Sort((a, b) => string.Compare(a.))
            Console.Clear ();
            Console.WriteLine ("Current Rolodex");
            Console.WriteLine ("---------------");
            foreach (IRobber robber in rolodex) {
                string tab = "\t";
                string Target = robber.ToString ();
                string[] SplitTarget = Target.Split (".");
                int namelength = robber.Name.Length;
                int specialitylength = SplitTarget[1].Length;
                string col1 = tab + tab;
                string col2 = tab + tab;
                string col3 = tab;

                if (namelength >= 7) {
                    col1 = tab;
                }
                if (specialitylength >= 9) {
                    col2 = tab;
                }
                if (SplitTarget[1] == "Hacker") {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else if (SplitTarget[1] == "Muscle") {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else if (SplitTarget[1] == "LockSpecialist") {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine ($"{robber.Name}:{col1}{SplitTarget[1]}, {col2}Skill Level {robber.SkillLevel}, {col3}Cut {robber.PercentageCut}%.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}