﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public Guid OriginalId { get; set; }
        public string Number { get; set; }
        [Index]
        [Required]
        public DateTime Date { get; set; }
        [Index]
        public DateTime? DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        [Index]
        public Guid? JobOrderId { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalPrice { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Description { get; set; }
        [Index]
        public bool IsPaid { get; set; }     
        [Index]
        public bool IsOverdue { get; set; }
        
        public PartyInfo Supplier { get; set; }
        public PartyInfo Customer { get; set; }

        [ComplexType] 
        public class PartyInfo
        {
            public Guid OriginalId { get; set; }
            [Index]
            [MaxLength(100)]
            public string Name { get; set; }
            public string StreetName { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string VatIndex { get; set; }
            public string NationalIdentificationNumber { get; set; }
        }
    }
}
