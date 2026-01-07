using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamJan2026
{
    // Abstract Robot class (can be changed only using inherited classes)
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
}
