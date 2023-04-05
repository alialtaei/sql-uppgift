using ConsoleApp.Services;
using System;

StatusService statusService = new();
MenuService menuService = new();
AnvändareService userService = new();

/* Här initierar du programmet */
await statusService.CreateStatusTypeAsync();

var currentUser = await userService.GetAsync(x => x.Email == "AliErjon@hotmail.com");
if (currentUser == null)
    currentUser = await menuService.CreateUserAsync();

/* här Kör man programmet */
while (true)
{
    await menuService.MainMenu(currentUser.Id);
    Console.ReadKey();
}

//Arbete skapad av Ali och Erjon