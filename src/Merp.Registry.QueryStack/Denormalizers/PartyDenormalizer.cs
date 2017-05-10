﻿using Merp.Registry.CommandStack.Events;
using Merp.Registry.QueryStack.Model;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Registry.QueryStack.Denormalizers
{
    public class PartyDenormalizer :
        IHandleMessages<LegalAddressSetForPartyEvent>,
        IHandleMessages<ShippingAddressSetForPartyEvent>,
        IHandleMessages<BillingAddressSetForPartyEvent>,
        IHandleMessages<ContactInfoSetForPartyEvent>
    {
        public async Task Handle(LegalAddressSetForPartyEvent message)
        {
            using (var context = new RegistryDbContext())
            {
                var legalAddress = new PostalAddress()
                {
                    Address = message.Address,
                    City = message.City,
                    Country = message.Country,
                    PostalCode = message.PostalCode,
                    Province = message.Province
                };
                var party = (from c in context.Parties
                             where c.OriginalId == message.PartyId
                             select c).Single();
                party.LegalAddress = legalAddress;

                await context.SaveChangesAsync();
            }
        }

        public async Task Handle(ShippingAddressSetForPartyEvent message)
        {
            using (var context = new RegistryDbContext())
            {
                var shippingAddress = new PostalAddress()
                {
                    Address = message.Address,
                    City = message.City,
                    Country = message.Country,
                    PostalCode = message.PostalCode,
                    Province = message.Province
                };
                var party = (from c in context.Parties
                               where c.OriginalId == message.PartyId
                               select c).Single();
                party.ShippingAddress = shippingAddress;

                await context.SaveChangesAsync();
            }
        }

        public async Task Handle(BillingAddressSetForPartyEvent message)
        {
            using (var context = new RegistryDbContext())
            {
                var billingAddress = new PostalAddress()
                {
                    Address = message.Address,
                    City = message.City,
                    Country = message.Country,
                    PostalCode = message.PostalCode,
                    Province = message.Province
                };
                var party = (from c in context.Parties
                             where c.OriginalId == message.PartyId
                             select c).Single();
                party.BillingAddress = billingAddress;

                await context.SaveChangesAsync();
            }
        }

        public async Task Handle(ContactInfoSetForPartyEvent message)
        {
            using (var context = new RegistryDbContext())
            {
                var contactInfo = new ContactInfo()
                {
                    PhoneNumber = message.PhoneNumber,
                    MobileNumber = message.MobileNumber,
                    FaxNumber = message.FaxNumber,
                    WebsiteAddress = message.WebsiteAddress,
                    EmailAddress = message.EmailAddress,
                    InstantMessaging = message.InstantMessaging
                };
                var party = (from c in context.Parties
                             where c.OriginalId == message.PartyId
                             select c).Single();
                party.ContactInfo = contactInfo;

                await context.SaveChangesAsync();
            }
        }
    }
}
