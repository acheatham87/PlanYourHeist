using System;
using System.Collections.Generic;

namespace planYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel} and a courge factor of {member.CourageFactor}");
            }
        }
    }
}

