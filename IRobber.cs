namespace Heist2
{
    partial class Program
    {
        public interface IRobber {
            string Name { get; }
            int SkillLevel { get; }
            int PercentageCut { get; }

            void PerformSkill (Bank aBank);
        }
    }
}
