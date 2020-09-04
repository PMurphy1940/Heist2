using System;

namespace Heist2 {

    public class Hacker : Robber, IRobber {

        public override void PerformSkill (Bank aBank) {
            string Target = aBank.ToString ();
            string[] SplitTarget = Target.Split ("Score");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine ($"{Name} is hacking the {SplitTarget[0]} system. Decreased security by {SkillLevel} points.");

            int ScoreChange = aBank.AlarmScore - SkillLevel;
            if (ScoreChange <= 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($"{Name} has disabled the {SplitTarget[0]}.");
            }
            aBank.AlarmScore = ScoreChange;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

}