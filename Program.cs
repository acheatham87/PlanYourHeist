using System;
using System.Collections.Generic;

namespace planYourHeist
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Plan your heist!");
            Console.WriteLine("Enter the bank difficulty Level.");
            int bankDifficultyLevel = int.Parse(Console.ReadLine());
            int bankDifficultyCheck = bankDifficultyLevel;

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

            Console.WriteLine("How many trial runs would you like to do?");
            int trialRuns = int.Parse(Console.ReadLine());
            
            int skillSum = 0;         
            foreach (TeamMember member in memberList)
            {                
                skillSum += member.SkillLevel;
            }

            int success = 0;
            int failure = 0;
            
            for(int i = 0; i < trialRuns; i++)
            {
                int luckValue = new Random().Next(-10,10);
                bankDifficultyLevel += luckValue;

                Console.WriteLine($"The teams combined skill level is {skillSum}.");
                Console.WriteLine($"The banks difficulty is {bankDifficultyLevel}");

                if(skillSum >= bankDifficultyLevel)
                {
                    Console.WriteLine("SUCCESS!!!");
                    success++;
            
                }
                else
                {
                    Console.WriteLine("YOU HAVE BEEN CAUGHT");
                    failure++;
                }
                bankDifficultyLevel = bankDifficultyCheck;
            }

            Console.WriteLine($"You succeeded {success} times and failed {failure} times.");
        }
    }
}

