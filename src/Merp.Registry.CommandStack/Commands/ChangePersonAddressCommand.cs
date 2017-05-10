﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memento;
using Memento.Domain;

namespace Merp.Registry.CommandStack.Commands
{
    public class ChangePersonAddressCommand : Command
    {
        public Guid PersonId { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }


        public ChangePersonAddressCommand(Guid personId, string address, string postalCode, string city, string province, string country)
        {
            PersonId = personId;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PostalCode = postalCode;
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country;
            Province = province;
        }
    }
}
