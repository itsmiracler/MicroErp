using System;

namespace Acl.RegistryResolutionServices.Mappers
{
    internal class ATPersonInformationMapper : PersonInformationMapper
    {
        protected override void MapAddress(PersonInformation person, string address)
        {
            var addressParts = address.Split(new[] { "\n" }, StringSplitOptions.None);
            person.Address = addressParts.Length > 0 ? addressParts[0] : null;
            person.City = addressParts.Length > 1 ? addressParts[1] : null;
        }
    }
}
