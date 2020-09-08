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
            LockSpecialist tom = new LockSpecialist () {
                Name = "Tom",
                PercentageCut = 15,
                SkillLevel = 51
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

            string response;
            do {
                int operatives = rolodex.Count ();

                Console.WriteLine ($"There are {operatives} operatives available in the Rolodex");

                Console.WriteLine ("Let's enter a new operative to the rolodex (hit Enter now to bypass.)");
                response = Console.ReadLine ();
                if (response.Length == 0) {
                    break;
                }
                addOperative (response, rolodex);
            } while (response.Length != 0);

            printRolodex (rolodex);

        }
        /*
        Print the rolodex to the console.
        */
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
            foreach (IRobber robber in sortedRolodex) {
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

        // Method assembles a new operative and adds to the Rolodex

        static void addOperative (string newName, List<IRobber> rolodex) {
            Console.Clear ();
            Console.WriteLine ($"Welcome to the training ground {newName}");
            List<string> specialties = new List<string> () {
                "1) Hacker (Disables alarms)",
                "2) Muscle (Disarms guards)",
                "3) LockSpecialist (Cracks vault)"
            };
            foreach (var job in specialties) {
                Console.WriteLine (job);
            }
            int jobChoice;
            do {
                jobChoice = getSpecialty (newName);
                Console.WriteLine (jobChoice);
            } while (jobChoice < 1 || jobChoice > 3);

            Console.Clear ();
            string currentSkill = specialties[(jobChoice - 1)].ToString ();
            string[] SplitTarget = currentSkill.Split (" ");

            Console.WriteLine ($"{newName} is training to be a {SplitTarget[1]}");
            Console.WriteLine ();
            Console.WriteLine ($"Enter a value for {newName}'s Skill Level (1 - 100.)");

            int skillChoice;
            do {
                skillChoice = getSkillLevel ();
            } while (skillChoice < 1 || skillChoice > 100);

            Console.Clear ();
            Console.WriteLine ($"{newName} is training to be a {SplitTarget[1]}");
            Console.WriteLine ($"{newName} has a {SplitTarget[1]} Skill Level of {skillChoice}");
            Console.WriteLine ();
            Console.WriteLine ($"Enter {newName}'s percentage of the take (1 - 100).");

            int percentageChoice;
            do {
                percentageChoice = getPercentage ();
            } while (percentageChoice < 1 || percentageChoice > 100);

            Console.Clear ();

            Console.WriteLine ($"{newName} is training to be a {SplitTarget[1]}");
            Console.WriteLine ($"{newName} has a {SplitTarget[1]} Skill Level of {skillChoice}");
            Console.WriteLine ($"{newName} gets {percentageChoice}% of the take.");
            Console.WriteLine ($"Would you like to add {newName} to the Rolodex? (y/n)");
            string response;
            do {
                response = Console.ReadLine ().ToLower ();
            }
            while (response != "y" && response != "n");

            if (response == "y") {
                if (jobChoice == 1) {

                    rolodex.Add (new Hacker () {
                        Name = newName,
                            SkillLevel = skillChoice,
                            PercentageCut = percentageChoice
                    });

                } else if (jobChoice == 2) {

                    rolodex.Add (new Muscle () {
                        Name = newName,
                            SkillLevel = skillChoice,
                            PercentageCut = percentageChoice
                    });
                } else if (jobChoice == 3) {

                    rolodex.Add (new LockSpecialist () {
                        Name = newName,
                            SkillLevel = skillChoice,
                            PercentageCut = percentageChoice
                    });

                }
            }

        }

        public static int getSpecialty (string Name) {
            string getChoice;
            int choice;
            do {
                Console.WriteLine ($"Pick a profession for {Name}.");
                getChoice = Console.ReadLine ();

            } while ((int.TryParse (getChoice, out choice) == false));

            return choice;
        }
        public static int getSkillLevel () {
            string getChoice;
            int choice;
            do {
                getChoice = Console.ReadLine ();
            } while (!int.TryParse (getChoice, out choice));

            return choice;
        }
        public static int getPercentage () {
            string getChoice;
            int choice;
            do {
                getChoice = Console.ReadLine ();
            } while (!int.TryParse (getChoice, out choice));

            return choice;
        }
    }
}