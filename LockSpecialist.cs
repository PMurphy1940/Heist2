using System;

namespace Heist2 {

        public class LockSpecialist : Robber, IRobber {
            public override void PerformSkill (Bank aBank) {
                string Target = aBank.ToString ();
                string[] SplitTarget = Target.Split ("Score");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine ($"{Name} is cracking the {SplitTarget[0]}. Decreased security by {SkillLevel} points.");

                int ScoreChange = aBank.VaultScore - SkillLevel;
                if (ScoreChange <= 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine ($"{Name} has opened the {SplitTarget[0]}.");
                }
                aBank.VaultScore = ScoreChange;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    
}