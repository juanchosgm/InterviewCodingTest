using SmallWorld.Models;
using SmallWorld.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTestHexacta.SmallWorld.Services
{
    public class SmallWorldServiceShould
    {
        [Theory]
        [MemberData(nameof(MockData.SmallWorldData), MemberType = typeof(MockData))]
        [Trait("SmallWorldService", "ResultSameLengthToInput")]
        public void ResultSameLengthToInput(IList<Point> points)
        {
            // Arrage
            var service = new SmallWorldService(points);

            // Act
            var result = service.GetResult();

            // Assert
            Assert.Equal(points.Count, result.Count());
        }

        [Theory]
        [MemberData(nameof(MockData.SmallWorldData), MemberType = typeof(MockData))]
        [Trait("SmallWorldService", "ResultRecordThreeShouldBe124")]
        public void ResultRecordThreeShouldBe124(IList<Point> points)
        {
            // Arrage
            var service = new SmallWorldService(points);

            // Act
            var result = service.GetResult().ElementAt(2);

            // Assert
            Assert.Equal("3 1,2,4", result);
        }

        [Theory]
        [MemberData(nameof(MockData.SmallWorldData), MemberType = typeof(MockData))]
        [Trait("SmallWorldService", "ResultEachRecordShouldBeLengthThree")]
        public void ResultEachRecordShouldBeLengthThree(IList<Point> points)
        {
            // Arrage
            var service = new SmallWorldService(points);

            // Act
            var result = service.GetResult()
                .Select(r => r.Substring(2).Split(","));

            // Assert
            Assert.True(result.All(r => r.Count() == 3));
        }
    }
}
