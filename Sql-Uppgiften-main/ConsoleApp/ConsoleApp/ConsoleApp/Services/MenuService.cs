using ConsoleApp.Moduler.Enheter;
using System.Threading.Tasks;
using System;

namespace ConsoleApp.Services;

internal class MenuService
{
    private readonly AnvändareService _userService = new();
    private readonly ÄrendeService _caseService = new();


    public async Task<AnvändareEntity> CreateUserAsync()
    {
        var _entity = new AnvändareEntity();
        Console.Clear();
        Console.WriteLine("-- Lägg Till Ny Administratör --");
        Console.Write("Skriv in ditt Förnamn: ");
        _entity.Förnamn = Console.ReadLine() ?? "";
        Console.Write("Skriv in ditt efternman: ");
        _entity.Efternamn = Console.ReadLine() ?? "";
        Console.Write("Skriv in din Email: ");
        _entity.Email = Console.ReadLine() ?? "";

        return await _userService.CreateAsync(_entity);
    }



    public async Task MainMenu(int userId)
    {
        Console.Clear();
        Console.WriteLine("-- Ali & Erjon´s program --");
        Console.WriteLine("1. Visa Alla Aktiva Ärenden");
        Console.WriteLine("2. Visa Administratörerna");
        Console.WriteLine("3. Skapa/Kör ett nytt Ärende");
        Console.Write("Välj ett av alternativern ovanför: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ActiveCasesAsync();
                break;

            case "2":
                await HandlersAsync();
                break;

            case "3":
                await NewCaseAsync(userId);
                break;

            default:
                Console.Clear();
                Console.Write("Error! ett av valen du gjorde är ej giltlig.");
                break;
        }
    }


    private async Task ActiveCasesAsync()
    {
        Console.Clear();
        Console.WriteLine("-- Alla Aktiva Ärenden --");
        foreach (var _case in await _caseService.GetAllActiveAsync())
        {
            Console.WriteLine($"Ärendenummer: {_case.Id}");
            Console.WriteLine($"Skapad: {_case.Created}");
            Console.WriteLine($"Modifierad: {_case.Modified}");
            Console.WriteLine($"Status: {_case.Status.StatusNamn}");
            Console.WriteLine("");
        }
    }

    private async Task HandlersAsync()
    {
        Console.Clear();
        Console.WriteLine("-- Alla Administratörer --");
        foreach (var _user in await _userService.GetAllAsync())
        {
            Console.WriteLine($"Admin-ID: {_user.Id}");
            Console.WriteLine($"Namn: {_user.Förnamn} {_user.Efternamn}");
            Console.WriteLine($"Email: {_user.Email}");
            Console.WriteLine("");
        }
    }

    private async Task NewCaseAsync(int userId)
    {
        var _entity = new ÄrendeEntity { UserId = userId };
        Console.Clear();
        Console.WriteLine("-- Skapa Nytt Ärende --");
        Console.Write("Skriv in kundens namn: ");
        _entity.KundNamn = Console.ReadLine() ?? "";
        Console.Write("Skriv in Email: ");
        _entity.KundEmail = Console.ReadLine() ?? "";
        Console.Write("Beskriv ditt ärende/problem: ");
        _entity.Beskrivning = Console.ReadLine() ?? "";

        await _caseService.CreateAsync(_entity);
        await ActiveCasesAsync();
    }
}