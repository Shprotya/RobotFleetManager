using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamJan2026
{
    //DeliveryRobot class inheriting from Robot
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
