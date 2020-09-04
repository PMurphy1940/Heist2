using System;

namespace Heist2 {

    public class Robber {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public virtual void PerformSkill (Bank aBank) {
            Console.WriteLine ("Vrooom!");
        }
    }

}