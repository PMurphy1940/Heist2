namespace Heist2 {
    partial class Program {
        public class Robber : IRobber {
            public string Name { get; set; }
            public int SkillLevel { get; set; }
            public int PercentageCut { get; set; }

            public virtual void PerformSkill (Bank aBank) {
                //
            }
        }
    }
}