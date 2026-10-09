/*
* Name: Zander Malone
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 9, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

//PART 1 - Road Trip
// Calculates Fuel and pizza costs, and adds them together to get the total trip expenses

using System.Text;

Console.WriteLine("How many miles is a round trip? ");
double miles = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("What is your car's miles per gallon? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("How much is a gallon of gas? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

double fuel = FuelCost(miles, milesPerGallon, pricePerGallon);

//Part 1: Pizza
const int pizzaSlices = 8;

Console.WriteLine("How many pizzas are there? ");
int pizzaCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("What is the price of a pizza? ");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());

int totalSlices = pizzaCount * pizzaSlices;
double totalPizzaCost = pizzaCount * pizzaPrice;

decimal tripTotal = (decimal)fuel + (decimal)totalPizzaCost;

//Part 1 output
Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel cost: $" + FuelCost(260, 28, 2.89).ToString("F2"));
Console.WriteLine("Pizza cost: " + totalPizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
Console.WriteLine(" ");


//PART 2 - The Group
// Creates arrays for the group members going on the trip, and calculates the cost of the trip per person.

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };
decimal costPerPerson = tripTotal / names.Length;

Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine($"People going: {names.Length}");
Console.WriteLine($"Slices each: {totalSlices / names.Length}");
Console.WriteLine("Cost per person: $" + (costPerPerson).ToString("F2"));
Console.WriteLine(" ");

//PART 3 - The Report
//Makes final calculations to find out every member's take home pay for their hours worked, and how much they must work to make their cut of the trip's expenses.

const double taxRate = 0.18;   
int totalHours = 0;
double totalTakeHome = 0;
double longest = 0;

Console.WriteLine("=== Part 3: Who Works How Long ===");

for (int i = 0; i < names.Length; i++)
{
    double homePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    decimal takeHomeHourly = (decimal)homePay / (decimal)hoursWorked[i];
    TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double hoursNeeded = HoursToCover((double)costPerPerson, (double)takeHomeHourly);

    totalHours += (int)hoursWorked[i];
    totalTakeHome += homePay;
    longest = Math.Max(longest, hoursNeeded);

    Console.WriteLine($"{names[i]}: takes home ${homePay:F2} for {hoursWorked[i]} hours, ${takeHomeHourly:F2} per hour, must work {hoursNeeded:F2}");
}
Console.WriteLine(" ");
Console.WriteLine($"Total hours worked: {totalHours}");
Console.WriteLine($"Total take home pay: ${totalTakeHome:F2}");
Console.WriteLine($"Longest anyone must work: {longest:F2}");


// METHODS

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    double homePay = grossPay - taxWithheld;
    return homePay;
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    double hoursNeeded = amountOwed / takeHomePerHour;
    return hoursNeeded;
}