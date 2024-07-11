// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Monstera Deliciosa",
        LightNeeds = 3,
        AskingPrice = 29.99M,
        City = "Seattle",
        ZIP = "98109",
        Sold = false,
    },
    new Plant()
    {
        Species = "Epipremnum Aureum",
        LightNeeds = 2,
        AskingPrice = 14.99M,
        City = "Chicago",
        ZIP = "60601",
        Sold = true,
    },
    new Plant()
    {
        Species = "Sansevieria Trifasciata",
        LightNeeds = 1,
        AskingPrice = 19.95M,
        City = "Los Angeles",
        ZIP = "90001",
        Sold = false,
    },
    new Plant()
    {
        Species = "Crassula Ovata",
        LightNeeds = 5,
        AskingPrice = 34.50M,
        City = "Miami",
        ZIP = "33133",
        Sold = true,
    },
    new Plant()
    {
        Species = "Ficus Lyrata",
        LightNeeds = 3,
        AskingPrice = 59.99M,
        City = "New York",
        ZIP = "10001",
        Sold = true,
    },
};


Console.WriteLine("Greetings Plant Friend!");

//Console.WriteLine("Here are all the plants:");

//for (int i = 0; i < plants.Count; i++)
//{
//    Console.WriteLine($"{i + 1}. {plants[i].Species} ");
//}

void MainMenu()
{
    Console.WriteLine(@"Choose an option from the Main Menu:
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5.Exit");
}

string choice = null;

while (choice != "5")
{
    MainMenu();
    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            //Console.WriteLine("Display all plants"); //I would do this so it do not exit the program
            //hrow new NotImplementedException("Display all plants");
            Console.Clear();
            DisplayPlants();
            break;
        case "2":
            //throw new NotImplementedException("Post a plant to be adopted");
            PostAPlant();
            break;
        case "3":
            //throw new NotImplementedException("Adopt a plant");
            AdoptAPlant();
            break;
        case "4":
            throw new NotImplementedException("Delist a plant");
        default:
            if (choice.Equals("5"))
            {
                Console.WriteLine("You have exited the app!");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please choose an option between 1 and 5!");
            }
            break;
    }
}

void DisplayPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        // <Number>. <Name of Plant> in <City> <is available/was sold> for <Price> dollars
        //Examples:
        //    1.A Ficus in Pasadena was sold for 15 dollars
        //    2.A Hydrangea in Walla Walla is available for 25 dollars"

        Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }
}

void PostAPlant()
{
    Console.WriteLine("What is the species of the plant?");
    string? speciesEntered = Console.ReadLine();

    Console.WriteLine("From a scale from 1-5 with 1 being the least and 5 being the most, how much light does the plant need?");
    int lightNeededEntered = int.Parse(Console.ReadLine());

    Console.WriteLine("What is the price of the plant?");
    decimal priceEntered = Math.Round(decimal.Parse(Console.ReadLine()), 2);

    Console.WriteLine("What city is the plant located?");
    string? cityEntered = Console.ReadLine();

    Console.WriteLine("What zip code is the plant located in?");

    //If the length is greater than 5, it extracts the first 5 characters using Console.ReadLine().Substring(0, 5)
    string? zipcodeEntered = Console.ReadLine();
    if (zipcodeEntered.Length > 5)
    {
        zipcodeEntered = zipcodeEntered.Substring(0, 5);
    }



    Plant newPlant = new Plant()
    {
        Species = speciesEntered,
        LightNeeds = lightNeededEntered,
        AskingPrice = priceEntered,
        City = cityEntered,
        ZIP = zipcodeEntered,
        Sold = false,
    };

    //plants.Add(new Plant
    //{
    //    Species = speciesEntered,
    //    LightNeeds = lightNeededEntered,
    //    AskingPrice = priceEntered,
    //    City = cityEntered,
    //    ZIP = zipcodeEntered,
    //    Sold = false,
    //});

    plants.Add(newPlant);

    Console.WriteLine($"Your plant {newPlant.Species} in {newPlant.City}, {newPlant.ZIP} is available for {newPlant.AskingPrice} dollars");
}

void AdoptAPlant()
{
    Console.WriteLine("Here are the available plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold == false)
         Console.WriteLine($"- {plants[i].Species}");
    }
}