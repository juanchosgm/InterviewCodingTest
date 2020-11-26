using DataMunging.Service;
using Xunit;

namespace UnitTestHexacta.DataMunging.Service
{
    public class DataMungingServiceShould
    {
        [Theory]
        [MemberData(nameof(MockData.DataMungingData), MemberType = typeof(MockData))]
        [Trait("DataMuningService", "ShowResultCorrectly")]
        public void ReportGeneratedCorrectly(string categories, string expenses)
        {
            // Arrage
            var service = new DataMungingService();

            // Act
            var exception = Record.Exception(() => 
            {
                service.GetCategories(categories);
                service.ShowResult(service.GetExpenses(expenses));
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        [Trait("DataMuningService", "GenerateException")]
        public void ReportDoesNotGeneratedCorrectly()
        {
            // Arrage
            var service = new DataMungingService();

            // Act
            var exception = Record.Exception(() => 
            {
                service.GetCategories(string.Empty);
                service.ShowResult(service.GetExpenses(string.Empty));
            });

            // Assert
            Assert.NotNull(exception);
        }
    }
}
