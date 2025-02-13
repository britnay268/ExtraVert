﻿// See https://aka.ms/new-console-template for more information
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
        AvailableUntil = new DateTime(2024, 11, 11),
    },
    new Plant()
    {
        Species = "Epipremnum Aureum",
        LightNeeds = 2,
        AskingPrice = 14.99M,
        City = "Chicago",
        ZIP = "60601",
        Sold = true,
        AvailableUntil = new DateTime(2024, 6, 21),
    },
    new Plant()
    {
        Species = "Sansevieria Trifasciata",
        LightNeeds = 1,
        AskingPrice = 19.95M,
        City = "Los Angeles",
        ZIP = "90001",
        Sold = false,
        AvailableUntil = new DateTime(2024, 9, 3),
    },
    new Plant()
    {
        Species = "Crassula Ovata",
        LightNeeds = 5,
        AskingPrice = 34.50M,
        City = "Miami",
        ZIP = "33133",
        Sold = true,
        AvailableUntil = new DateTime(2024, 6, 11),
    },
    new Plant()
    {
        Species = "Ficus Lyrata",
        LightNeeds = 3,
        AskingPrice = 59.99M,
        City = "New York",
        ZIP = "10001",
        Sold = true,
        AvailableUntil = new DateTime(2024, 5, 9),
    },
    new Plant()
    {
        Species = "Zea mays (Corn)",
        LightNeeds = 4,
        AskingPrice = 1.99M,
        City = "Ohio",
        ZIP = "67231",
        Sold = false,
        AvailableUntil = new DateTime(2024, 4, 12),
    },
    new Plant()
    {
        Species = "Coffea (Coffee)",
        LightNeeds = 2,
        AskingPrice = 9.99M,
        City = "Oregon",
        ZIP = "38901",
        Sold = false,
        AvailableUntil = new DateTime(2024, 9, 22),
    },
    new Plant()
    {
        Species = "Oryza sativa (Rice)",
        LightNeeds = 1,
        AskingPrice = 4.99M,
        City = "Minnesota",
        ZIP = "59762",
        Sold = false,
        AvailableUntil = new DateTime(2024, 6, 17),
    },
};

Random random = new Random();

Console.WriteLine("Greetings Plant Friend!");

//Console.WriteLine("Here are all the plants:");

//for (int i = 0; i < plants.Count; i++)
//{
//    Console.WriteLine($"{i + 1}. {plants[i].Species} ");
//}

void MainMenu()
{
    Console.WriteLine(@"Choose an option from the Main Menu:
    0. Exit
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5. Plant of the Day
    6. Search Plant by Light Needs
    7. View Plant Statistics");
}

string choice = null;

while (choice != "0")
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
            //throw new NotImplementedException("Delist a plant");
            DelistAPlant();
            break;
        case "5":
            PlantOfTheDay();
            break;
        case "6":
            Search();
            break;
        case "7":
            Statistics();
            break;
        default:
            if (choice.Equals("0"))
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

        Console.WriteLine($"{i + 1}. A {PlantDetails(plants[i])} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} and is available until {plants[i].AvailableUntil}.");
    }
}

void PostAPlant()
{
    bool validDate = false;
    Plant newPlant = null;

    while (!validDate)
    {
        try
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

            Console.WriteLine("Please enter the year the plant will be available until:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the month (1-12) the plant will be available until:");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the day (1-31) the plant will be available until:");
            int day = int.Parse(Console.ReadLine());

            newPlant = new Plant()
            {
                Species = speciesEntered,
                LightNeeds = lightNeededEntered,
                AskingPrice = priceEntered,
                City = cityEntered,
                ZIP = zipcodeEntered,
                Sold = false,
            };

            newPlant.AvailableUntil = new DateTime(year, month, day);

            plants.Add(newPlant);

            Console.WriteLine($"Your plant {PlantDetails(newPlant)} in {newPlant.City}, {newPlant.ZIP} is available for {newPlant.AskingPrice} dollars and is available until {newPlant.AvailableUntil}");
            validDate = true;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("The date you entered is invalid. Please try again!");
            Console.WriteLine($"Error: {ex.Message}");
        } 
    }

    //plants.Add(new Plant
    //{
    //    Species = speciesEntered,
    //    LightNeeds = lightNeededEntered,
    //    AskingPrice = priceEntered,
    //    City = cityEntered,
    //    ZIP = zipcodeEntered,
    //    Sold = false,
    //});
}

void AdoptAPlant()
{
    static List<Plant> AvailablePlants(List<Plant> plants)
    {
        return plants.Where(p => p.Sold == false && p.AvailableUntil > DateTime.Now).ToList();
    }

    // Did this because looping through just plants gave an uneven number for available plants
    List <Plant> availablePlants = AvailablePlants(plants);

    int plantNumber = 1;
    Console.WriteLine("Here are the available plants:");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        if (availablePlants[i].Sold == false && availablePlants[i].AvailableUntil > DateTime.Now)
        {
             Console.WriteLine($"{plantNumber}. {PlantDetails(availablePlants[i])} and is available until {availablePlants[i].AvailableUntil}");
             plantNumber++;
        }
    }

    Console.WriteLine("Select the number to adopt a plant:");
    int plantIndex;

    // This keeps executeing if the input conversion to an int is unsuccessful or plantIndex > 0 or plantIndex is more than the length of available Plants
    while (!int.TryParse(Console.ReadLine(), out plantIndex) || plantIndex > availablePlants.Count || plantIndex < 1)
    {
        Console.WriteLine("Try again! That was not a valid option");
    }

    //This finds the first plant species that is equal to the select option from the availablePlants species and set sold to true
    // I had to minus one cause the index starts at 0
    plants.FirstOrDefault(p => p.Species == PlantDetails(availablePlants[plantIndex - 1])).Sold = true;

    Console.WriteLine($"You have adopted {PlantDetails(availablePlants[plantIndex - 1])}");

}

void DelistAPlant()
{
    int i = 1;
    foreach (Plant plant in plants)
    {
        Console.WriteLine($"{i++}. {PlantDetails(plant)}");
    }

    Console.WriteLine("Choose a number to be remove a plant from the list:");
    int input = int.Parse(Console.ReadLine());

    plants.RemoveAt(input - 1);

    Console.WriteLine("You have successfully removed plant from list!");
}

void PlantOfTheDay()
{
    // Geta a randome index from plants list based on the length of list
    int randomPlantIndex = random.Next(1, plants.Count);

    // While the random generated plant Sold property is true, it generates a new randome plant but when it is false, it goes to line 244 and console warn the details for the plant
    while (plants[randomPlantIndex - 1].Sold)
    {
        randomPlantIndex = random.Next(1, plants.Count);
        
    }
    
    Console.WriteLine($@"Plant of The Day:
            Species - {PlantDetails(plants[randomPlantIndex - 1])}
            Location - {plants[randomPlantIndex - 1].City}
            Light Needs - {plants[randomPlantIndex - 1].LightNeeds}
            Price - ${plants[randomPlantIndex - 1].AskingPrice}");
    
}

void Search()
{
    Console.WriteLine("Enter a maximum light needs number (between 1 and 5)");

    string input = Console.ReadLine();

    int index = 1;

    List<Plant> searchedPlants = new List<Plant>();

    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].LightNeeds == int.Parse(input))
        {
            searchedPlants.Add(plants[i]);
        }

    }

    if (searchedPlants.Count > 0)
    {
        Console.WriteLine("Here are the plants with the entered light need:");
        foreach (Plant plant in searchedPlants)
        {
            Console.WriteLine($"{index++}. {PlantDetails(plant)}");
        }
    }
    else
    {
        Console.WriteLine("There are no plants with the entered light need!");
    }
}

void Statistics()
{
    Plant cheapestPlant = plants.OrderBy(p => p.AskingPrice).FirstOrDefault();
    Console.WriteLine($"Lowest price plant name: {cheapestPlant.Species}");

    int availablePlantsCount = plants.Where(p => p.Sold == false && p.AvailableUntil > DateTime.Now).Count();
    Console.WriteLine($"Number of Plants Available: {availablePlantsCount}");

    Plant hightestLightNeeds = plants.OrderByDescending(p => p.LightNeeds).FirstOrDefault();
    Console.WriteLine($"Name of plant with highest light needs: {hightestLightNeeds.Species}");

    double sumLightNeeds = plants.Select(p => p.LightNeeds).Sum();
    double totalPlants = plants.Count();
    Console.WriteLine($"Average light needs: {sumLightNeeds/(double)totalPlants}");

    double adoptedPlants = plants.Where(p => p.Sold).Count();
    Console.WriteLine($"Percentage of plants adopted: {(adoptedPlants / totalPlants) * 100}%");
}

string PlantDetails(Plant plant)
{
    string plantString = plant.Species;

    return plantString;
}