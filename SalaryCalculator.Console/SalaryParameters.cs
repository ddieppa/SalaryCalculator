namespace SalaryCalculator.Console;

public class SalaryParameters
{
    /// <summary>
    /// Represents the wage of an individual.
    /// </summary>
    /// <remarks>
    /// The wage is typically measured as the amount of money earned per unit of time, such as an hour or a year.
    /// It is used in calculations related to salary and compensation.
    /// </remarks>
    public double Wage { get; set; }

    /// <summary>
    /// Represents the number of hours worked in a week.
    /// </summary>
    /// <remarks>
    /// The HoursPerWeek property is used as input in calculations related to salary and compensation.
    /// It is used together with the annual salary to calculate the hourly wage, or with the hourly wage to calculate the annual salary.
    /// The default value is 40 hours per week.
    /// </remarks>
    public int HoursPerWeek { get; set; } = 40;

    /// <summary>
    /// Represents the number of weeks in a year.
    /// </summary>
    /// <remarks>
    /// The WeeksPerYear property is used in the salary calculations to determine the total number of weeks in a year.
    /// It is typically set to 52 weeks, which is the standard number of weeks in a year.
    /// However, it can be customized to a different value if necessary.
    /// </remarks>
    public int WeeksPerYear { get; set; } = 52;

}