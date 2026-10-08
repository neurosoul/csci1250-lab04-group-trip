
//PART 1 - Road Trip
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
//double slicesPerPerson = totalSlices / peopleCount;
double totalPizzaCost = pizzaCount * pizzaPrice;

//Console.WriteLine("Total slices: " + totalSlices.ToString());
//Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F1"));

//Part 1: Pay
const double taxRate = 0.18;  
double homePay = TakeHomePay(20, 14, 0.18);

//Part 1: Total
double hoursNeeded = HoursToCover(35.60, 11.48);
decimal tripTotal = (decimal)fuel + (decimal)totalPizzaCost;
//decimal costPerPerson = tripTotal / (decimal)peopleCount;
decimal takeHomeHourly = (decimal)homePay / 20;

//Part 1: output
Console.WriteLine("=== Part 1: The Trip ===");
Console.WriteLine("Fuel cost: $" + FuelCost(260, 28, 2.89).ToString("F2"));
Console.WriteLine("Pizza cost: " + totalPizzaCost.ToString("C"));
Console.WriteLine("Trip Total: " + tripTotal.ToString("C"));
Console.WriteLine(" ");
//Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));
//Console.WriteLine("Take home pay per hour: " + takeHomeHourly.ToString("C"));
//onsole.WriteLine("Hours you must work to cover your share: " + hoursNeeded.ToString("F2"));

//PART 2 - The Group

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 12.20, 14.80 };

Console.WriteLine("=== Part 2: The Group ===");
Console.WriteLine($"People Going {names.Length}");
Console.WriteLine($"Slices each: {totalSlices / names.Length}");
Console.WriteLine("Cost per person: $" + (tripTotal / names.Length).ToString("F2"));
Console.WriteLine(" ");


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