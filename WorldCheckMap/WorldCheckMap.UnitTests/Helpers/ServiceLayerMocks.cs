using AutoMapper;
using Moq;
using WorldCheckMap.Data.Models;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Helpers
{
    internal static class ServiceLayerMocks
    {
        internal static IMapper GetMapperMock()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<CountryDto>(It.IsAny<Country>()))
                .Returns((Country c) => new CountryDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                });

            return mockMapper.Object;
        }
    }
}