using Merp.Accountancy.QueryStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.QueryStack
{
    public interface IDatabase
    {
        IQueryable<JobOrder> JobOrders { get; }
        IQueryable<IncomingCreditNote> IncomingCreditNotes { get; }
        IQueryable<IncomingInvoice> IncomingInvoices { get; }
        IQueryable<OutgoingCreditNote> OutgoingCreditNotes { get; }
        IQueryable<OutgoingInvoice> OutgoingInvoices { get; }
    }
}
