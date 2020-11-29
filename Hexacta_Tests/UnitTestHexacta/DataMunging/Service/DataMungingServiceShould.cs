using DataMunging.Models;
using DataMunging.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTestHexacta.DataMunging.Service
{
    public class DataMungingServiceShould
    {
        [Theory]
        [MemberData(nameof(MockData.DataMungingData), MemberType = typeof(MockData))]
        [Trait("DataMuningService", "ResultSameThreeRecords")]
        public void ResultSameThreeRecords(string categories, string expenses)
        {
            // Arrage
            var input = InitializeValues(categories, expenses);

            // Act
            var result = input.service.GetResult(input.expenses, input.categories);

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Theory]
        [MemberData(nameof(MockData.DataMungingData), MemberType = typeof(MockData))]
        [Trait("DataMuningService", "ResultStarbucksShouldBeTwo")]
        public void ResultStarbucksShouldBeTwo(string categories, string expenses)
        {
            // Arrage
            var input = InitializeValues(categories, expenses);

            // Act
            var result = input.service.GetResult(input.expenses, input.categories)
                .Where(r => r.Contains("Starbucks"));

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Theory]
        [MemberData(nameof(MockData.DataMungingData), MemberType = typeof(MockData))]
        [Trait("DataMuningService", "ResultLastRecordShouldBe317")]
        public void ResultLastRecordShouldBe317(string categories, string expenses)
        {
            // Arrage
            var input = InitializeValues(categories, expenses);

            // Act
            var result = input.service.GetResult(input.expenses, input.categories)
                .Last();

            // Assert
            Assert.Contains("$3.17", result);
        }

        private (DataMungingService service, IEnumerable<Expense> expenses, IEnumerable<Category> categories) InitializeValues(string categories, string expenses)
        {
            var service = new DataMungingService();
            return (service, service.GetExpenses(expenses), service.GetCategories(categories));
        }
    }
}
