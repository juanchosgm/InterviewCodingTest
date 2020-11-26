using SmallWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestHexacta
{
    public class MockData
    {
        public static IEnumerable<object[]> SmallWorldData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] 
                    { 
                        new List<Point>
                        {
                            new Point(0d,0d),
                            new Point(10.1d, -10.1d),
                            new Point(-12.2, 12.2),
                            new Point(38.3, 38.3),
                            new Point(79.99, 179.99)
                        }
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataMungingData
        {
            get
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        "CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N",
                        "Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS"
                    }
                };
            }
        }
    }
}
