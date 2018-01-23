using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCheckMap.DataAccess.Attributes;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.Services;
using WorldCheckMap.Tests.Common;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer;
using WorldCheckMap.Tests.Unit.Infrastructure.ServiceLayer;

namespace WorldCheckMap.Tests.Unit.ServiceLayer
{
    [TestClass]
    public class CountryServiceTest
    {
        [TestMethod]
        public void GetCountriesTest()
        {
            var repository = DataLayerMocks.GetCountryRepositoryMock().Object;
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new CountryService(repository, mapper);

            var countries = service.GetCountries().ToList();
            var sourceCountries = TestData.GetCountryDtos();
            
            Assert.IsNotNull(countries);
            var areSame = countries.IsEqual(sourceCountries);
            Assert.IsTrue(areSame);
        }

        [TestMethod]
        public void GetCountriesInitialDataDto()
        {
            var repository = DataLayerMocks.GetCountryRepositoryMock().Object;
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new CountryService(repository, mapper);

            var initialData = service.GetCountriesInitialData();
            Assert.IsNotNull(initialData);

            var testCountries = TestData.GetCountryDtos();
            Assert.IsTrue(initialData.Countries.IsEqual(testCountries));

            var enumType = typeof(CountryStatus);
            var enumMembersData = initialData.CountryStatuses.Values;

            var enumValues = Enum.GetValues(enumType).Cast<int>().ToArray();
            Assert.IsTrue(enumValues.IsEqual(enumMembersData.Select(d => d.Code)));

            var enumNames = Enum.GetNames(enumType);
            Assert.IsTrue(enumNames.IsEqual(enumMembersData.Select(d => d.Name)));

            var enumVerbs = enumType
                .GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static)
                .Select(m => m.GetCustomAttributes(typeof(CountryStatusVerbAttribute), false)
                    .Cast<CountryStatusVerbAttribute>()
                    .First()
                    .Verb);
            Assert.IsTrue(enumVerbs.IsEqual(enumMembersData.Select(d => d.StatusVerb)));
        }
    }
}