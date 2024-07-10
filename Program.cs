// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Monstera Deliciosa",
        LightNeeds = 3,
        AskingPrice = 29.99,
        City = "Seattle",
        ZIP = "98109",
        Sold = false,
    },
    new Plant()
    {
        Species = "Epipremnum Aureum",
        LightNeeds = 2,
        AskingPrice = 14.99,
        City = "Chicago",
        ZIP = "60601",
        Sold = true,
    },
    new Plant()
    {
        Species = "Sansevieria Trifasciata",
        LightNeeds = 1,
        AskingPrice = 19.95,
        City = "Los Angeles",
        ZIP = "90001",
        Sold = false,
    },
    new Plant()
    {
        Species = "Crassula Ovata",
        LightNeeds = 5,
        AskingPrice = 34.50,
        City = "Miami",
        ZIP = "33133",
        Sold = true,
    },
    new Plant()
    {
        Species = "Ficus Lyrata",
        LightNeeds = 3,
        AskingPrice = 59.99,
        City = "New York",
        ZIP = "10001",
        Sold = true,
    },
};


Console.WriteLine("Greetings Plant Friend!");

Console.WriteLine("Here are all the plants:");

for (int i = 0; i < plants.Count; i++)
{
    Console.WriteLine($"{i + 1}. {plants[i].Species} ");
}
