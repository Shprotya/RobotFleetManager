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
    // Enums for different robot types and their specific skills or modes
    public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }
    public enum DeliveryMode { Walking, Driving, Flying }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


    }

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
            return $"Battery Information,\nCapacity: {PowerCapacityKWH} kWH, \nCurrent Power: {CurrentPowerKWH} kWH \nBattery Level: {GetBatteryPercentage():F2}%";
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

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            var skillsText = (Skills == null || Skills.Count == 0) ? "None" : string.Join(", ", Skills);
            return $"{RobotName} - Household Robot\n{DisplayBatteryInformation()}\nSkills: {skillsText}";
        }

    }

    public class DeliveryRobot : Robot
    {
        private DeliveryMode Mode { get; set; }

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            var modeText = Mode.ToString();
            return $"{RobotName} - Delivery Robot\n{DisplayBatteryInformation()}\nDelivery Mode: {modeText}";
        }
    }
}