using Merp.Accountancy.CommandStack.Model;
using Merp.Accountancy.CommandStack.Services;
using Moq;
using SharpTestsEx;
using System;
using System.Collections.Generic;
using Xunit;

namespace Merp.Accountancy.CommandStack.Tests.Model
{
    public class OutgoingCreditNoteFixture
    {
        public class Factory
        {
            [Fact]
            public void Issue_should_throw_ArgumentNullException_if_outgoingCreditNoteNumberGenerator_is_null()
            {
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                var lineItems = new Invoice.InvoiceLineItem[0];
                var pricesByVat = new Invoice.InvoicePriceByVat[0];
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Issue(
                    null,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalPrice,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo("generator");
            }

            [Fact]
            public void Issue_should_throw_ArgumentNullException_if_lineItems_are_null()
            {
                var generator = new Mock<IOutgoingCreditNoteNumberGenerator>().Object;
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                IEnumerable<Invoice.InvoiceLineItem> lineItems = null;
                var pricesByVat = new Invoice.InvoicePriceByVat[0];
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Issue(
                    generator,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalPrice,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo(nameof(lineItems));
            }

            [Fact]
            public void Issue_should_throw_ArgumentNullException_if_pricesByVat_are_null()
            {
                var generator = new Mock<IOutgoingCreditNoteNumberGenerator>().Object;
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                var lineItems = new Invoice.InvoiceLineItem[0];
                IEnumerable<Invoice.InvoicePriceByVat> pricesByVat = null;
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Issue(
                    generator,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalPrice,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo(nameof(pricesByVat));
            }

            [Fact]
            public void Register_should_throw_ArgumentException_if_creditNoteNumber_is_null_or_whitespace()
            {
                var creditNoteNumber = string.Empty;
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                decimal totalToPay = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                var lineItems = new Invoice.InvoiceLineItem[0];
                var pricesByVat = new Invoice.InvoicePriceByVat[0];
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Register(
                    creditNoteNumber,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalToPay,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo(nameof(creditNoteNumber));
            }

            [Fact]
            public void Register_should_throw_ArgumentNullException_if_lineItems_are_null()
            {
                var creditNoteNumber = "1";
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                decimal totalToPay = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                IEnumerable<Invoice.InvoiceLineItem> lineItems = null;
                var pricesByVat = new Invoice.InvoicePriceByVat[0];
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Register(
                    creditNoteNumber,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalToPay,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo(nameof(lineItems));
            }

            [Fact]
            public void Register_should_throw_ArgumentNullException_if_pricesByVat_are_null()
            {
                var creditNoteNumber = "1";
                var userId = Guid.NewGuid();
                var creditNoteDate = DateTime.Today;
                string currency = "EUR";
                decimal amount = 101;
                decimal taxes = 42;
                decimal totalPrice = 143;
                decimal totalToPay = 143;
                string description = "fake";
                string paymentTerms = "none";
                string purchaseOrderNumber = "42";
                var customerId = Guid.NewGuid();
                string customerName = "Managed Designs S.r.l.";
                string customerAddress = "Via Torino 51";
                string customerCity = "Milan";
                string customerPostalCode = "20123";
                string customerCountry = "Italy";
                string customerVatIndex = "04358780965";
                string customerNationalIdentificationNumber = "04358780965";
                string supplierName = "Mastreeno ltd";
                string supplierAddress = "8, Leman street";
                string supplierCity = "London";
                string supplierPostalCode = "";
                string supplierCountry = "England - United Kingdom";
                string supplierVatIndex = "XYZ";
                string supplierNationalIdentificationNumber = "04358780965";
                var lineItems = new Invoice.InvoiceLineItem[0];
                IEnumerable<Invoice.InvoicePriceByVat> pricesByVat = null;
                var nonTaxableItems = new Invoice.NonTaxableItem[0];

                Executing.This(() => OutgoingCreditNote.Factory.Register(
                    creditNoteNumber,
                    creditNoteDate,
                    currency,
                    amount,
                    taxes,
                    totalPrice,
                    totalToPay,
                    description,
                    paymentTerms,
                    purchaseOrderNumber,
                    customerId,
                    customerName,
                    customerAddress,
                    customerCity,
                    customerPostalCode,
                    customerCountry,
                    customerVatIndex,
                    customerNationalIdentificationNumber,
                    supplierName,
                    supplierAddress,
                    supplierCity,
                    supplierPostalCode,
                    supplierCountry,
                    supplierVatIndex,
                    supplierNationalIdentificationNumber,
                    lineItems, false, pricesByVat, nonTaxableItems, null, null, null, null, null, null, null, userId))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .And
                    .ValueOf
                    .ParamName
                    .Should()
                    .Be
                    .EqualTo(nameof(pricesByVat));
            }
        }
    }
}
