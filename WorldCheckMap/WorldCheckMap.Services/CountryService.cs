using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    }
}