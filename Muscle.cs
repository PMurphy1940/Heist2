using System;

namespace Heist2 {
  
        public class Muscle : Robber, IRobber {
            public override void PerformSkill (Bank aBank) {
                string Target = aBank.ToString ();
                string[] SplitTarget = Target.Split ("Score");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine ($"{Name} is punching the {SplitTarget[0]}. Decreased security by {SkillLevel} points.");

                int ScoreChange = aBank.SecurityGuardScore - SkillLevel;
                if (ScoreChange <= 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine ($"{Name} has disabled the {SplitTarget[0]}.");
                }
                aBank.SecurityGuardScore = ScoreChange;
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }
    
}