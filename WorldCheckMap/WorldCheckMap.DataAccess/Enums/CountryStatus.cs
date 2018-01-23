using WorldCheckMap.DataAccess.Attributes;

namespace WorldCheckMap.DataAccess.Enums
{
    public enum CountryStatus
    {
        [CountryStatusVerb("wasn't")]
        None = 0,

        [CountryStatusVerb("wish to be")]
        Wish = 1,

        [CountryStatusVerb("has been")]
        Been = 2,

        [CountryStatusVerb("lived")]
        Lived = 3
    }
}