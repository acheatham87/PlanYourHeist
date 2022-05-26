using System;
using System.Collections.Generic;

namespace planYourHeist
{
    class Program
    {

        static void Main(string[] args)
        {
            int bankDifficultyLevel = 100;
            int skillSum = 0;
            int luckValue = new Random().Next(-10,10);
            bankDifficultyLevel += luckValue;

            Console.WriteLine("Plan your heist!");

            List<TeamMember> memberList = new List<TeamMember>();
            AddNewMember();

            void AddNewMember()
            {
                Console.WriteLine("Please enter your team memeber's name");
                string memberName = Console.ReadLine();

                if(memberName != "")
                {
                    Console.WriteLine("Please enter your team member's skill level");
                    int memberSkillLevel = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Please enter your team member's courage level (0.0 - 2.0)");
                    decimal memberCourageFactor = decimal.Parse(Console.ReadLine());

                    TeamMember newGuy = new TeamMember(memberName, memberSkillLevel, memberCourageFactor);
                    memberList.Add(newGuy);

                    AddNewMember();
                }      
                else
                {
                    return;
                }
            }

            Console.WriteLine($"{memberList.Count}");

            foreach (TeamMember member in memberList)
            {                
                skillSum += member.SkillLevel;
            }

            Console.WriteLine($"The teams combined skill level is {skillSum}.");
            Console.WriteLine($"The banks difficulty is {bankDifficultyLevel}");

            if(skillSum >= bankDifficultyLevel)
            {
                Console.WriteLine("SUCCESS!!!");
            }
            else
            {
                Console.WriteLine("YOU HAVE BEEN CAUGHT");
            }
        }
    }
}

