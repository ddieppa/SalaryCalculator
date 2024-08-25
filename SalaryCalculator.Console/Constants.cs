namespace SalaryCalculator.Console;

public static class Constants
{
    public const int DefaultHoursPerWeek = 40;
    public const int DefaultWeeksPerYear = 52;

    // Rule configuration constants
    public const string RuleTitle = "[yellow]Salary Calculator[/]";
    public const string RuleStyle = "blue";

    // Choice constants
    public const string AnnualSalaryFromHourlyWage = "Annual salary from hourly wage";
    public const string HourlyWageFromAnnualSalary = "Hourly wage from annual salary";

    // Prompt constants
    public const string CalculateTitle = "What would you like to calculate?";
    public const string EnterHourlyWagePrompt = "Enter your [green]hourly wage[/] (in dollars):";
    public const string EnterAnnualSalaryPrompt = "Enter your [green]annual salary[/] (in dollars):";
    public const string EnterHoursPerWeekPrompt = "Enter the number of [green]hours per week[/] (default: {0}):";
    public const string EnterWeeksPerYearPrompt = "Enter the number of [green]weeks per year[/] you work (default: {0}):";

    // Result display constants
    public const string AnnualSalaryResultFormat = "Your [green]annual salary[/] is: [yellow]${0:N2}[/]";
    public const string HourlyWageResultFormat = "Your [green]hourly wage[/] is: [yellow]${0:N2}[/]";
}