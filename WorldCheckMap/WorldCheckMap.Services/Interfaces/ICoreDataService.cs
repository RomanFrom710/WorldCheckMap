using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Services.Interfaces
{
    public interface ICoreDataService
    {
        ClientInitDataDto GetClientInitData();
    }
}