using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Merp.Accountancy.Web.Models.Invoice
{
    public class RegisterOutgoingInvoiceModel
    {
        public OutgoingDocumentTypes Type { get; set; }

        public PartyInfo Customer { get; set; }

        public string Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Taxes { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public decimal TotalToPay { get; set; }

        [Required]
        public string Description { get; set; }

        public string PaymentTerms { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public bool VatIncluded { get; set; }

        public IEnumerable<InvoiceLineItemModel> LineItems { get; set; }

        public IEnumerable<InvoicePriceByVatModel> PricesByVat { get; set; }

        public IEnumerable<NonTaxableItemModel> NonTaxableItems { get; set; }

        public ProvidenceFundModel ProvidenceFund { get; set; }

        public WithholdingTaxModel WithholdingTax { get; set; }
    }
}
