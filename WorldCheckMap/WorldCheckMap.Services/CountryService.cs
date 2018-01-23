using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WorldCheckMap.DataAccess.Attributes;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Repositories.Interfaces;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            return _repository.GetCountries().Select(c => _mapper.Map<CountryDto>(c));
        }

        public CountriesInitialDataDto GetCountriesInitialData()
        {
            var countries = GetCountries();

            var enumType = typeof(CountryStatus);
            var enumData = Enum.GetValues(enumType).Cast<int>().ToDictionary(
                enumValue => Enum.GetName(enumType, enumValue).ToLower(),
                enumValue =>
                {
                    var name = Enum.GetName(enumType, enumValue);
                    var verb = enumType.GetMember(name)
                        .First()
                        .GetCustomAttributes(typeof(CountryStatusVerbAttribute), false)
                        .Cast<CountryStatusVerbAttribute>()
                        .First()
                        .Verb;

                    return new CountryStatusEnumMemberDto
                    {
                        Code = enumValue,
                        Name = name,
                        StatusVerb = verb
                    };
                });

            return new CountriesInitialDataDto
            {
                Countries = countries,
                CountryStatuses = enumData
            };
        }
    }
}