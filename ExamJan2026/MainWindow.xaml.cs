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
    //Created in the namespace, outside of the MainWindow class
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

            //Call DownloadSkill after robots constructed, inside the constructor body
            ((HouseholdRobot)GardenMate).DownloadSkill(HouseholdSkill.Gardening);
            ((HouseholdRobot)Housemate3000).DownloadSkill(HouseholdSkill.Cooking);
            ((HouseholdRobot)Housemate3000).DownloadSkill(HouseholdSkill.Laundry);
        }

        #region Created Objects
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
                MessageBox.Show("No robot selected to charge.", "Select a Robot");
                return;
            }
            selectedRobot.Charge();

        }
    }
}