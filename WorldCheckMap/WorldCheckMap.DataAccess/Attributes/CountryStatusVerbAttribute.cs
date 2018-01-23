using System;

namespace WorldCheckMap.DataAccess.Attributes
{
    public class CountryStatusVerbAttribute : Attribute
    {
        public string Verb { get; set; }

        public CountryStatusVerbAttribute(string verb)
        {
            Verb = verb;
        }
    }
}