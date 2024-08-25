namespace SalaryCalculator.Services;

public interface ISalaryCalculatorService
{
    double CalculateHourlyWageFromAnnualSalary(double annualSalary, int hoursPerWeek, int weeksPerYear);
    double CalculateAnnualSalaryFromHourlyWage(double hourlyWage, int hoursPerWeek, int weeksPerYear);
}