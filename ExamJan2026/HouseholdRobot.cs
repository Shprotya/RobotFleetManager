using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamJan2026
{
    // HouseholdRobot class inheriting from Robot
    public class HouseholdRobot : Robot
    {
        // List to hold the skills of the household robot
        private List<HouseholdSkill> Skills { get; set; }

        // Constructor to initialize the skills list with Cleaning skill by default
        public HouseholdRobot()
        {
            Skills = new List<HouseholdSkill>();
            Skills.Add(HouseholdSkill.Cleaning);
        }

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            var skillsText = (Skills == null || Skills.Count == 0) ? "None" : string.Join(", ", Skills);
            return $"I am a Household Robot.\n\n I can help with chores around the house \n\nSkills: {skillsText} \n\n{DisplayBatteryInformation()}";
        }

        // Method to download a new skill to the household robot
        public void DownloadSkill(HouseholdSkill skill)
        {

            Skills.Add(skill);
        }

    }
}
