using FluentAssertions;
using NSubstitute;
using SalaryCalculator.Services;
using Xunit;

namespace SalaryCalculator.Tests
{
    public class SalaryCalculatorServiceTest
    {
        private readonly ISalaryCalculatorService _service = Substitute.For<ISalaryCalculatorService>();

        [Theory]
        [InlineData(52000, 40, 52, 25.0)]
        [InlineData(0, 40, 52, 0)]
        [InlineData(52000, 0, 52, 0)]
        [InlineData(52000, 40, 0, 0)]
        [InlineData(-52000, 40, 52, -25.0)]
        public void CalculateHourlyWageFromAnnualSalary_ShouldCalculateCorrectly(double annualSalary, int hoursPerWeek, int weeksPerYear, double expected)
        {
            // Arrange
            _service.CalculateHourlyWageFromAnnualSalary(annualSalary, hoursPerWeek, weeksPerYear).Returns(expected);

            // Act
            var actual = _service.CalculateHourlyWageFromAnnualSalary(annualSalary, hoursPerWeek, weeksPerYear);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(25.0, 40, 52, 52000)]
        [InlineData(0, 40, 52, 0)]
        [InlineData(25.0, 0, 52, 0)]
        [InlineData(25.0, 40, 0, 0)]
        [InlineData(-25.0, 40, 52, -52000)]
        public void CalculateAnnualSalaryFromHourlyWage_ShouldCalculateCorrectly(double hourlyWage, int hoursPerWeek, int weeksPerYear, double expected)
        {
            // Arrange
            _service.CalculateAnnualSalaryFromHourlyWage(hourlyWage, hoursPerWeek, weeksPerYear).Returns(expected);

            // Act
            var actual = _service.CalculateAnnualSalaryFromHourlyWage(hourlyWage, hoursPerWeek, weeksPerYear);

            // Assert
            actual.Should().Be(expected);
        }
    }
}