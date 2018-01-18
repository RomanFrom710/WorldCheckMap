using System.Linq;
using AutoMapper;
using Moq;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Unit.Infrastructure.ServiceLayer
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

            mockMapper.Setup(x => x.Map<AccountDto>(It.IsAny<Account>()))
                .Returns((Account a) => new AccountDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Guid = a.Guid,
                    Created = a.Created,
                    CountryStates = a.CountryStates?.Select(cs => new CountryStateDto
                    {
                        Id = cs.Id,
                        CountryId = cs.CountryId,
                        Status = cs.Status
                    })
                });

            return mockMapper.Object;
        }
    }
}