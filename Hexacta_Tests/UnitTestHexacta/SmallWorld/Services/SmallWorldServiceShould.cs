using SmallWorld.Models;
using SmallWorld.Service;
using System.Collections.Generic;
using Xunit;

namespace UnitTestHexacta.SmallWorld.Services
{
    public class SmallWorldServiceShould
    {
        [Theory]
        [MemberData(nameof(MockData.SmallWorldData), MemberType = typeof(MockData))]
        [Trait("SmallWorldService", "ShowResultCorrectly")]
        public void PointsGeneratedCorrectly(IList<Point> points)
        {
            // Arrage
            var service = new SmallWorldService(points);

            // Act
            var exception = Record.Exception(() => service.ShowResult());

            // Assert
            Assert.Null(exception);
        }
    }
}
