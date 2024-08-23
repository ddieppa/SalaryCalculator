using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Console;
using Spectre.Console;
using Rule = Spectre.Console.Rule;

// var salaryCalculatorService = new SalaryCalculatorService();

var services = new ServiceCollection();
services.AddSingleton<ISalaryCalculatorService, SalaryCalculatorService>();

var serviceProvider = services.BuildServiceProvider();
var salaryCalculatorService = serviceProvider.GetService<ISalaryCalculatorService>();

var ruleTitle = new Rule("[yellow]Salary Calculator[/]").RuleStyle("blue");

AnsiConsole.Write(ruleTitle);

var annualSalaryFromHourlyWage = "Annual salary from hourly wage";
var hourlyWageFromAnnualSalary = "Hourly wage from annual salary";
var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
                .Title("What would you like to calculate?")
                .PageSize(10)
                .AddChoices(annualSalaryFromHourlyWage,
                            hourlyWageFromAnnualSalary));

if (choice == annualSalaryFromHourlyWage)
{
    ShowAnnualFromHourly();
}
else
{
    ShowHourlyFromAnnual();
}

void ShowAnnualFromHourly()
{
    var hourlyWage = AnsiConsole.Ask<double>("Enter your [green]hourly wage[/] (in dollars):");
    var hoursPerWeek = AnsiConsole.Ask("Enter the number of [green]hours per week[/] (default: 40):", 40);
    var weeksPerYear = AnsiConsole.Ask("Enter the number of [green]weeks per year[/] you work (default: 52):", 52);

    var annualSalary = salaryCalculatorService.CalculateAnnualSalaryFromHourlyWage(hourlyWage,
                                                           hoursPerWeek,
                                                           weeksPerYear);

    AnsiConsole.MarkupLine($"Your [green]annual salary[/] is: [yellow]${annualSalary:N2}[/]");
}

void ShowHourlyFromAnnual()
{
    var annualSalary = AnsiConsole.Ask<double>("Enter your [green]annual salary[/] (in dollars):");
    var hoursPerWeek = AnsiConsole.Ask("Enter the number of [green]hours per week[/] (default: 40):", 40);
    var weeksPerYear = AnsiConsole.Ask("Enter the number of [green]weeks per year[/] you work (default: 52):", 52);

    var hourlyWage = salaryCalculatorService.CalculateHourlyWageFromAnnualSalary(annualSalary,
                                                         hoursPerWeek,
                                                         weeksPerYear);

    AnsiConsole.MarkupLine($"Your [green]hourly wage[/] is: [yellow]${hourlyWage:N2}[/]");
}

