using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Console;
using SalaryCalculator.Services;
using Spectre.Console;
using Rule = Spectre.Console.Rule;

var services = new ServiceCollection();
services.AddSingleton<ISalaryCalculatorService, SalaryCalculatorService>();
var serviceProvider = services.BuildServiceProvider();
var salaryCalculatorService = serviceProvider.GetService<ISalaryCalculatorService>();

DisplayRule();

var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title(Constants.CalculateTitle)
        .PageSize(10)
        .AddChoices(Constants.AnnualSalaryFromHourlyWage, Constants.HourlyWageFromAnnualSalary));

if (choice == Constants.AnnualSalaryFromHourlyWage)
{
    ShowAnnualFromHourly();
}
else
{
    ShowHourlyFromAnnual();
}

void DisplayRule()
{
    var salaryCalculatorRule = new Rule(Constants.RuleTitle).RuleStyle(Constants.RuleStyle);
    AnsiConsole.Write(salaryCalculatorRule);
}

void ShowAnnualFromHourly()
{
    var hourlyWage = AnsiConsole.Ask<double>(Constants.EnterHourlyWagePrompt);
    var hoursPerWeek = PromptHoursPerWeek();
    var weeksPerYear = PromptWeeksPerYear();

    var annualSalary = salaryCalculatorService.CalculateAnnualSalaryFromHourlyWage(hourlyWage, hoursPerWeek, weeksPerYear);
    AnsiConsole.MarkupLine(string.Format(Constants.AnnualSalaryResultFormat, annualSalary));
}

void ShowHourlyFromAnnual()
{
    var annualSalary = AnsiConsole.Ask<double>(Constants.EnterAnnualSalaryPrompt);
    var hoursPerWeek = PromptHoursPerWeek();
    var weeksPerYear = PromptWeeksPerYear();

    var hourlyWage = salaryCalculatorService.CalculateHourlyWageFromAnnualSalary(annualSalary, hoursPerWeek, weeksPerYear);
    AnsiConsole.MarkupLine(string.Format(Constants.HourlyWageResultFormat, hourlyWage));
}

int PromptHoursPerWeek() => AnsiConsole.Ask(string.Format(Constants.EnterHoursPerWeekPrompt, Constants.DefaultHoursPerWeek), Constants.DefaultHoursPerWeek);
int PromptWeeksPerYear() => AnsiConsole.Ask(string.Format(Constants.EnterWeeksPerYearPrompt, Constants.DefaultWeeksPerYear), Constants.DefaultWeeksPerYear);