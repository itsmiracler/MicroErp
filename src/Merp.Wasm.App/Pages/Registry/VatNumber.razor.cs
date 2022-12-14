using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Merp.Wasm.App.Http;

namespace Merp.Wasm.App.Pages.Registry
{
    public partial class VatNumber
    {
        [Inject] RegistryInternalApiHttpClient RegistryInternalApi { get; set; }
        private string vatIndex;
        private string countryCode;

        private IEnumerable<RegistryInternalApiHttpClient.Country> countries = new List<RegistryInternalApiHttpClient.Country>();

        [Parameter]
        public EventCallback<PartyInfo> OnLookup { get; set; }

        [Parameter]
        public PartyType Type { get; set; }

        [Parameter]
        public string Value
        {
            set
            {
                if (value != null && value.Length > 3 && countries.Any(c => c.Code == value.Substring(0, 2)))
                {
                    countryCode = value.Substring(0, 2);
                    vatIndex = value.Substring(2);
                }
                else
                {
                    vatIndex = value;
                }
            }
            get
            {
                return vatIndex switch
                {
                    null => null,
                    "" => null,
                    string vi when vi.Length == 0 => null,
                    string vi when vi.Length > 0 => string.Concat(countryCode, vi),
                    _ => vatIndex
                };
            }
        }

        protected override async Task OnInitializedAsync()
        {
            countries = await RegistryInternalApi.GetCountriesAsync();
        }

        //public VatNumber()
        //{
        //    countries = RegistryInternalApi.GetCountriesAsync().Result;
        //}

        private async void Lookup()
        {
            if (string.IsNullOrWhiteSpace(this.countryCode) || string.IsNullOrWhiteSpace(this.vatIndex))
                return;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegistryInternalApiHttpClient.GetCompanyInfoByVatNumberModel, PartyInfo>();
                cfg.CreateMap<RegistryInternalApiHttpClient.GetPersonInfoByVatNumberModel, PartyInfo>();
            });

            PartyInfo partyInfo = null;
            IMapper mapper = config.CreateMapper();
            switch(Type)
            {
                case PartyType.Company:
                    var companyInfo = await this.RegistryInternalApi.GetCompanyInfoByVatNumberAsync(vatIndex, countryCode);
                    partyInfo = mapper.Map<RegistryInternalApiHttpClient.GetCompanyInfoByVatNumberModel, PartyInfo>(companyInfo);
                    break;
                case PartyType.Person:
                    var personInfo = await this.RegistryInternalApi.GetPersonInfoByVatNumberAsync(vatIndex, countryCode);
                    partyInfo = mapper.Map<RegistryInternalApiHttpClient.GetPersonInfoByVatNumberModel, PartyInfo>(personInfo);
                    break;
            }
            if (partyInfo != null)
                await OnLookup.InvokeAsync(partyInfo);

            Console.WriteLine(partyInfo?.FirstName);
        }

        private IEnumerable<RegistryInternalApiHttpClient.Country> MockGetCountries()
        {
            return new List<RegistryInternalApiHttpClient.Country>()
            {
                new RegistryInternalApiHttpClient.Country { Code="AT", DisplayName = "Austria" },
                new RegistryInternalApiHttpClient.Country { Code="BE", DisplayName = "Belgium" },
                new RegistryInternalApiHttpClient.Country { Code="BG", DisplayName = "Bulgaria" },
                new RegistryInternalApiHttpClient.Country { Code="CY", DisplayName = "Cyprus" },
                new RegistryInternalApiHttpClient.Country { Code="CZ", DisplayName = "Czech Republic" },
                new RegistryInternalApiHttpClient.Country { Code="DE", DisplayName = "Germany" },
                new RegistryInternalApiHttpClient.Country { Code="DK", DisplayName = "Denmark" },
                new RegistryInternalApiHttpClient.Country { Code="EE", DisplayName = "Estonia" },
                new RegistryInternalApiHttpClient.Country { Code="EL", DisplayName = "Greece" },
                new RegistryInternalApiHttpClient.Country { Code="ES", DisplayName = "Spain" },
                new RegistryInternalApiHttpClient.Country { Code="FI", DisplayName = "Finland" },
                new RegistryInternalApiHttpClient.Country { Code="FR", DisplayName = "France" },
                new RegistryInternalApiHttpClient.Country { Code="GB", DisplayName = "United Kingdom" },
                new RegistryInternalApiHttpClient.Country { Code="HR", DisplayName = "Croatia" },
                new RegistryInternalApiHttpClient.Country { Code="HU", DisplayName = "Hungary" },
                new RegistryInternalApiHttpClient.Country { Code="IE", DisplayName = "Ireland" },
                new RegistryInternalApiHttpClient.Country { Code="IT", DisplayName = "Italy" },
                new RegistryInternalApiHttpClient.Country { Code="LT", DisplayName = "Lithuania" },
                new RegistryInternalApiHttpClient.Country { Code="LU", DisplayName = "Luxemburg" },
                new RegistryInternalApiHttpClient.Country { Code="LV", DisplayName = "Latvia" },
                new RegistryInternalApiHttpClient.Country { Code="MT", DisplayName = "Malta" },
                new RegistryInternalApiHttpClient.Country { Code="NL", DisplayName = "Netherlands" },
                new RegistryInternalApiHttpClient.Country { Code="PL", DisplayName = "Poland" },
                new RegistryInternalApiHttpClient.Country { Code="PT", DisplayName = "Portugal" },
                new RegistryInternalApiHttpClient.Country { Code="RO", DisplayName = "Romania" },
                new RegistryInternalApiHttpClient.Country { Code="SE", DisplayName = "Sweden" },
                new RegistryInternalApiHttpClient.Country { Code="SI", DisplayName = "Slovenia" },
                new RegistryInternalApiHttpClient.Country { Code="SK", DisplayName = "Slovakia" },
            };
        }

        public enum PartyType
        {
            Company,
            Person
        }

        public class PartyInfo
        {
            public string CompanyName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string VatNumber { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Province { get; set; }
            public string Country { get; set; }
        }
    }
}
