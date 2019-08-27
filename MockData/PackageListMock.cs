using System.Collections.Generic;
using Metodologias1.Kingdom.Interfaces;
using Metodologias1.Kingdom.Objects;

namespace Metodologias1.Kingdom.MockData
{
    public static class PackageListMock
    {
        public static List<IMerchandise> GetPackage1()
        {
            return new List<IMerchandise>()
            {
                new Package()
                {
                    Weight = 25
                },
                new Package()
                {
                    Weight = 40
                },
                new Package()
                {
                    Weight = 10
                },
                new Package()
                {
                    Weight = 35
                },
                new Package()
                {
                    Weight = 70
                },
                new Package()
                {
                    Weight = 10
                }
            };
        }

        public static List<IMerchandise> GetPackage2()
        {
            return new List<IMerchandise>()
            {
                new Package()
                {
                    Weight = 55
                },
                new Package()
                {
                    Weight = 20
                },
                new Package()
                {
                    Weight = 35
                },
                new Package()
                {
                    Weight = 60
                },
                new Package()
                {
                    Weight = 100
                }
            };
        }
    }
}