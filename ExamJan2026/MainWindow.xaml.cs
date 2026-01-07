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
            CurrentPowerKWH = 4.0,
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
            Mode = DeliveryMode.Walking
        };

        Robot FlyBot = new DeliveryRobot()
        {
            RobotName = "FlyBot",
            PowerCapacityKWH = 8.0,
            CurrentPowerKWH = 5.0,
            Mode = DeliveryMode.Flying
        };

        Robot Driver = new DeliveryRobot()
        {
            RobotName = "Driver",
            PowerCapacityKWH = 12.0,
            CurrentPowerKWH = 9.0,
            Mode = DeliveryMode.Driving
        };
        #endregion

        private void AllRobots_Radio_Checked(object sender, RoutedEventArgs e)
        {
            List<Robot> robots = new List<Robot>()
            {
                HouseBot,
                GardenMate,
                Housemate3000,
                DeliverBot,
                FlyBot,
                Driver
            };
            RobotListbx.ItemsSource = robots;
        }
        private void Household_Radio_Checked(object sender, RoutedEventArgs e)
        {
            List<Robot> householdRobots = new List<Robot>()
            {
                HouseBot,
                GardenMate,
                Housemate3000
            };
            RobotListbx.ItemsSource = householdRobots;
        }

        private void Delivery_Radio_Checked(object sender, RoutedEventArgs e)
        {
            List<Robot> deliveryRobots = new List<Robot>()
            {
                DeliverBot,
                FlyBot,
                Driver
            };
            RobotListbx.ItemsSource = deliveryRobots;
        }

        // Event handler for selection change in the robot list box
        private void RobotListbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRobot = RobotListbx.SelectedItem as Robot;
            if (selectedRobot == null)
            {
                Details_Txtbl.Text = "No robot selected.";
                return;
            }

            Details_Txtbl.Text = selectedRobot.DescribeRobot();
        }

        // Event handler for the Charge button click
        private void Charge_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedRobot = RobotListbx.SelectedItem as Robot;
            if (selectedRobot == null)
            {
                MessageBox.Show("No robot selected to charge.");
                return;
            }
            selectedRobot.Charge();

        }
    }

    // Enums for different robot types and their specific skills or modes
    public enum HouseholdSkill { Cooking, Cleaning, Laundry, Gardening, ChildCare }
    public enum DeliveryMode { Walking, Driving, Flying }


    public abstract class Robot
    {
        // common properties for all robots
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
            return $"{RobotName} - {GetType().Name}";
        }

        // Method to charge the robot
        public void Charge()
        {
            if (CurrentPowerKWH == PowerCapacityKWH)
            {
                MessageBox.Show($"{RobotName} is already fully charged.");
            }
            else
            {
                double speed = 1.0; // Charging speed in kWH per hour
                double timeToFullCharge = (PowerCapacityKWH - CurrentPowerKWH) / speed;
                MessageBox.Show($"Charging {RobotName}...\nIt will take approximately {timeToFullCharge:F2} hours to fully charge.");
            }
        }
    }

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

    public class DeliveryRobot : Robot
    {
        // Property to hold the delivery mode
        public DeliveryMode Mode { get; set; }

        // DescribeRobot override without using StringBuilder.Append
        public override string DescribeRobot()
        {
            return $"I am a Delivery Robot\n\n I specialize in delivery by {Mode}. The maximum load i can carry is 100.00 kg.\n\n{DisplayBatteryInformation()}";
        }
    }
}