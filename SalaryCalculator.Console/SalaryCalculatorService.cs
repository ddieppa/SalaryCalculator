namespace SalaryCalculator.Console;

public class SalaryCalculatorService : ISalaryCalculatorService
{
    public double CalculateHourlyWageFromAnnualSalary(double annualSalary, int hoursPerWeek, int weeksPerYear)
    {
        var hourlyWage = annualSalary / (hoursPerWeek * weeksPerYear);
        return hourlyWage;
    }

    public double CalculateAnnualSalaryFromHourlyWage(double hourlyWage, int hoursPerWeek, int weeksPerYear)
    {
        var annualSalary = hourlyWage * hoursPerWeek * weeksPerYear;
        return annualSalary;
    }
}