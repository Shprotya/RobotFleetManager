using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// The link to the repository is: https://github.com/Shprotya/ExamJan2026

namespace ExamJan2026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Created Objects
        public MainWindow()
        {
            InitializeComponent();

            //Call DownloadSkill after robots constructed, inside the constructor body
            ((HouseholdRobot)GardenMate).DownloadSkill(HouseholdSkill.Gardening);
            ((HouseholdRobot)Housemate3000).DownloadSkill(HouseholdSkill.Cooking);
            ((HouseholdRobot)Housemate3000).DownloadSkill(HouseholdSkill.Laundry);
        }

        Robot HouseBot = new HouseholdRobot()
        {
            RobotName = "HouseBot",
            PowerCapacityKWH = 5.0,
            CurrentPowerKWH = 3.5,
        };

        Robot GardenMate = new HouseholdRobot()
        {
            RobotName = "GardenMate",
            PowerCapacityKWH = 4.0,
            CurrentPowerKWH = 2.0,
        };

        Robot Housemate3000 = new HouseholdRobot()
        {
            RobotName = "Housemate3000",
            PowerCapacityKWH = 6.0,
            CurrentPowerKWH = 4.5,
        };

        Robot DeliverBot = new DeliveryRobot()
        {
            RobotName = "DeliverBot",
            PowerCapacityKWH = 10.0,
            CurrentPowerKWH = 7.5,
        };

        Robot FlyBot = new DeliveryRobot()
        {
            RobotName = "FlyBot",
            PowerCapacityKWH = 8.0,
            CurrentPowerKWH = 5.0,
        };

        Robot Driver = new DeliveryRobot()
        {
            RobotName = "Driver",
            PowerCapacityKWH = 12.0,
            CurrentPowerKWH = 9.0,
        };
        #endregion
    }

    // Enums for different robot types and their specific skills or modes
    public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }
    public enum DeliveryMode { Walking, Driving, Flying }

    public abstract class Robot
    {
        public string RobotName { get; set; }
        public double PowerCapacityKWH { get; set; }
        public double CurrentPowerKWH { get; set; }

        public double GetBatteryPercentage()
        {
            return (CurrentPowerKWH / PowerCapacityKWH) * 100;
        }

        public string DisplayBatteryInformation()
        {
            return $"Battery Information\nCapacity: {PowerCapacityKWH} kWH, \nCurrent Power: {CurrentPowerKWH} kWH \nBattery Level: {GetBatteryPercentage():F2}%";
        }

        // used in subclasses to display text information about the robot.
        public abstract string DescribeRobot();

        // used to give robot name and type of robot. 
        public override string ToString()
        {
            return $"{RobotName} - ";
        }

    }

    public class HouseholdRobot : Robot
    {
        private List<HouseholdSkill> Skills { get; set; }

        public HouseholdRobot()
        {
            Skills.Add(HouseholdSkill.Cleaning);
        }

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            var skillsText = (Skills == null || Skills.Count == 0) ? "None" : string.Join(", ", Skills);
            return $"I am a Household Robot.\n\n I can help with chores around the house \nSkills: {skillsText} \n{DisplayBatteryInformation()}";
        }

        public void DownloadSkill(HouseholdSkill skill)
        {
            
            Skills.Add(skill);
        }

    }

    public class DeliveryRobot : Robot
    {
        private DeliveryMode Mode { get; set; }

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            var modeText = Mode.ToString();
            return $"I am a Delivery Robot\n\n I specialize in delivery by {modeText}. The maximum load i can carry is 100.00 kg.\n{DisplayBatteryInformation()}";
        }


    }
}