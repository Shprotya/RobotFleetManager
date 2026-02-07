# Robot Management System

A WPF desktop application for managing different types of robots, including household robots and delivery robots.

## Description

This application allows users to view, filter, and manage a fleet of robots with different capabilities. Users can monitor battery levels, charge robots, and view detailed information about each robot's specifications and skills.

## Features

- **Multiple Robot Types:**
  - **Household Robots**: Assist with household chores (cleaning, cooking, laundry, gardening, childcare)
  - **Delivery Robots**: Handle deliveries via walking, driving, or flying

- **Robot Management:**
  - Filter robots by type (All, Household, Delivery)
  - View detailed robot specifications
  - Monitor battery levels and capacity
  - Charge robots with time estimation

- **Skills System:**
  - Household robots can download additional skills
  - Each robot has customizable capabilities

## Technical Details

- **Framework**: .NET 8.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Language**: C#
- **Architecture**: Object-oriented design with inheritance and polymorphism

## Project Structure

- `Robot.cs` - Abstract base class for all robots
- `HouseholdRobot.cs` - Household robot implementation
- `DeliveryRobot.cs` - Delivery robot implementation
- `MainWindow.xaml/cs` - Main application UI and logic

## Robots Included

### Household Robots:
1. **HouseBot** - General cleaning robot
2. **GardenMate** - Specialized in gardening tasks
3. **Housemate3000** - Multi-skilled (cooking, cleaning, laundry)

### Delivery Robots:
1. **DeliverBot** - Walking delivery (10 kWH capacity)
2. **FlyBot** - Flying delivery (8 kWH capacity)
3. **Driver** - Driving delivery (12 kWH capacity)

## Author

Created as part of January 2026 examination project.
