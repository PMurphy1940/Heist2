using System;
using System.Collections.Generic;

namespace Heist2 {
    partial class Program {
        static void Main (string[] args) {
            Console.Clear();
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

            List<string> specailities = new List<string> (){
                "Hacker (Disables alarms)", "Muscle (Disarms guards)", "Lock Specialist (Cracks vault)"
            };
            foreach (IRobber robber in rolodex) 
            {
                string Target = robber.ToString ();
                string[] SplitTarget = Target.Split (".");
                Console.WriteLine($"{robber.Name}: {SplitTarget[1]}, Skill Level {robber.SkillLevel}, Cut {robber.PercentageCut}%.");
            }


        }
    }
}