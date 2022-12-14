using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MementoFX.Persistence;
using MementoFX;
using MementoFX.Domain;
using Merp.Accountancy.CommandStack.Events;
using Merp.Accountancy.CommandStack.Services;

namespace Merp.Accountancy.CommandStack.Model
{
    public class JobOrder : Aggregate,
        IApplyEvent<IncomingCreditNoteLinkedToJobOrderEvent>,
        IApplyEvent<IncomingInvoiceLinkedToJobOrderEvent>,
        IApplyEvent<OutgoingCreditNoteLinkedToJobOrderEvent>,
        IApplyEvent<OutgoingInvoiceLinkedToJobOrderEvent>,
        IApplyEvent<JobOrderExtendedEvent>,
        IApplyEvent<JobOrderCompletedEvent>,
        IApplyEvent<JobOrderRegisteredEvent>
    {
        public Guid CustomerId { get; protected set; }
        public Guid? ContactPersonId { get; protected set; }
        public Guid ManagerId { get; protected set; }

        public string Name { get; protected set; }

        public string Number { get; protected set; }

        public DateTime DateOfStart { get; protected set; }

        public DateTime? DateOfCompletion { get; protected set; }

        public DateTime DueDate { get; private set; }

        public PositiveMoney Price { get; private set; }

        public bool IsCompleted { get; protected set; }

        public string PurchaseOrderNumber { get; protected set; }

        public string Description { get; protected set; }

        public decimal Balance { get; private set; }

        public class CustomerInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }

            public CustomerInfo(Guid id, string name)
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Id cannot be empty", nameof(id));
                if(string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Name cannot be null or empty", nameof(name));
                Id = id;
                Name = name;
            }
        }

        public class ManagerInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }

            public ManagerInfo(Guid id, string name)
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Id cannot be empty", "id");
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be null or empty", "name");
                }
                Id = id;
                Name = name;
            }
        }

        public void ApplyEvent(IncomingCreditNoteLinkedToJobOrderEvent evt)
        {
            this.Balance -= evt.Amount;
        }

        public void ApplyEvent(IncomingInvoiceLinkedToJobOrderEvent evt)
        {
            this.Balance -= evt.Amount;
        }

        public void ApplyEvent(OutgoingCreditNoteLinkedToJobOrderEvent evt)
        {
            this.Balance += evt.Amount;
        }

        public void ApplyEvent(OutgoingInvoiceLinkedToJobOrderEvent evt)
        {
            this.Balance += evt.Amount;
        }

        public void ApplyEvent(JobOrderExtendedEvent evt)
        {
            this.DueDate = evt.NewDueDate;
            this.Price = new PositiveMoney(evt.Price, this.Price.Currency);
        }

        public void ApplyEvent(JobOrderCompletedEvent evt)
        {
            this.DateOfCompletion = evt.DateOfCompletion;
            this.IsCompleted = true;
        }

        public void ApplyEvent(JobOrderRegisteredEvent evt)
        {
            Id = evt.JobOrderId;
            CustomerId = evt.CustomerId;
            ContactPersonId = evt.ContactPersonId;
            ManagerId = evt.ManagerId;
            DateOfStart = evt.DateOfStart;
            DueDate = evt.DueDate;
            Name = evt.JobOrderName;
            Number = evt.JobOrderNumber;
            IsCompleted = false;
            PurchaseOrderNumber = evt.PurchaseOrderNumber;
            Description = evt.Description;
            if (evt.Price.HasValue)
                Price = new PositiveMoney(evt.Price.Value, evt.Currency);
            else
                evt.Price = null;
        }

        /// <summary>
        /// Associate an incoming credit note to the current Job Order
        /// </summary>
        /// <param name="eventStore">The event store</param>
        /// <param name="creditNoteId">The Id of the Credit note to be associated to the current Job Order</param>
        /// <param name="userId">The Id of the current user</param>
        /// <exception cref="InvalidOperationException">Thrown if the specified creditNoteId refers to an invoice which has already been associated to a Job Order</exception>
        public void LinkIncomingCreditNote(IEventStore eventStore, Guid creditNoteId, DateTime dateOfLink, decimal amount, Guid userId)
        {
            if (this.IsCompleted)
                throw new InvalidOperationException("Can't relate new revenues to a completed job order");
            var @event = new IncomingCreditNoteLinkedToJobOrderEvent(creditNoteId, this.Id, dateOfLink, amount, userId);
            RaiseEvent(@event);
        }

        /// <summary>
        /// Associate an incoming invoice to the current Job Order
        /// </summary>
        /// <param name="eventStore">The event store</param>
        /// <param name="invoiceId">The Id of the Invoice to be associated to the current Job Order</param>
        /// <param name="userId">The Id of the current user</param>
        /// <exception cref="InvalidOperationException">Thrown if the specified invoiceId refers to an invoice which has already been associated to a Job Order</exception>
        public void LinkIncomingInvoice(IEventStore eventStore, Guid invoiceId, DateTime dateOfLink, decimal amount, Guid userId)
        {
            if (this.IsCompleted)
                throw new InvalidOperationException("Can't relate new costs to a completed job order");
            var @event = new IncomingInvoiceLinkedToJobOrderEvent(invoiceId, this.Id, dateOfLink, amount, userId);
            RaiseEvent(@event);
        }

        /// <summary>
        /// Associate an outgoing credit note to the current Job Order
        /// </summary>
        /// <param name="eventStore">The event store</param>
        /// <param name="creditNoteId">The Id of the Credit note to be associated to the current Job Order</param>
        /// <param name="userId">The Id of the current user</param>
        /// <exception cref="InvalidOperationException">Thrown if the specified creditNoteId refers to a credit note which has already been associated to a Job Order</exception>
        public void LinkOutgoingCreditNote(IEventStore eventStore, Guid creditNoteId, DateTime dateOfLink, decimal amount, Guid userId)
        {
            if (this.IsCompleted)
            {
                throw new InvalidOperationException("Can't relate new costs to a completed job order");
            }

            var @event = new OutgoingCreditNoteLinkedToJobOrderEvent(creditNoteId, this.Id, dateOfLink, amount, userId);
            RaiseEvent(@event);
        }

        /// <summary>
        /// Associate an outgoing invoice to the current Job Order
        /// </summary>
        /// <param name="eventStore">The event store</param>
        /// <param name="invoiceId">The Id of the Invoice to be associated to the current Job Order</param>
        /// <param name="userId">The Id of the current user</param>
        /// <exception cref="InvalidOperationException">Thrown if the specified invoiceId refers to an invoice which has already been associated to a Job Order</exception>
        public void LinkOutgoingInvoice(IEventStore eventStore, Guid invoiceId, DateTime dateOfLink, decimal amount, Guid userId)
        {
            if (this.IsCompleted)
                throw new InvalidOperationException("Can't relate new revenues to a completed job order");
            var @event = new OutgoingInvoiceLinkedToJobOrderEvent(invoiceId, this.Id, dateOfLink, amount, userId);
            RaiseEvent(@event);
        }

        public void Extend(DateTime newDueDate, decimal price, Guid userId)
        {
            if (this.IsCompleted)
                throw new InvalidOperationException("Can't extend a completed job order.");
            if (this.DueDate > newDueDate)
                throw new ArgumentException("A job order length cannot be reduced.", nameof(newDueDate));

            var @event = new JobOrderExtendedEvent(
                this.Id,
                newDueDate,
                price,
                userId
            );
            RaiseEvent(@event);
        }

        public void MarkAsCompleted(DateTime dateOfCompletion, Guid userId)
        {
            if (this.DateOfStart > dateOfCompletion)
                throw new ArgumentException("The date of completion cannot precede the date of start.", nameof(dateOfCompletion));
            if (this.IsCompleted)
                throw new InvalidOperationException("The Job Order has already been marked as completed");

            var @event = new JobOrderCompletedEvent(
                this.Id,
                dateOfCompletion,
                userId
            );
            RaiseEvent(@event);
        }

        public class Factory
        {
            public static JobOrder RegisterNew(IJobOrderNumberGenerator jobOrderNumberGenerator, Guid customerId, string customerName, Guid? contactPersonId, Guid managerId, decimal? price, string currency, DateTime dateOfStart, DateTime dueDate, bool isTimeAndMaterial, string name, string purchaseOrderNumber, string description, Guid userId)
            {
                if (jobOrderNumberGenerator == null)
                    throw new ArgumentNullException(nameof(jobOrderNumberGenerator));
                if (price < 0)
                    throw new ArgumentException("The price must be zero or higher", nameof(price));
                if (string.IsNullOrWhiteSpace(currency))
                    throw new ArgumentException("The currency must me specified", nameof(currency));
                if (dueDate < dateOfStart)
                    throw new ArgumentException("The due date cannot precede the starting date", nameof(dueDate));
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("The job order must have a name", nameof(name));

                var @event = new JobOrderRegisteredEvent(
                    Guid.NewGuid(),
                    customerId,
                    customerName,
                    contactPersonId,
                    managerId,
                    price,
                    currency,
                    DateTime.Now,
                    dateOfStart,
                    dueDate,
                    isTimeAndMaterial,
                    name,
                    jobOrderNumberGenerator.Generate(),
                    purchaseOrderNumber,
                    description,
                    userId
                    );
                var jobOrder = new JobOrder();
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }

            public static JobOrder Import(Guid jobOrderId, string jobOrderNumber, Guid customerId, string customerName, Guid? contactPersonId, Guid managerId, decimal? price, string currency, DateTime dateOfRegistration, DateTime dateOfStart, DateTime dueDate, bool isTimeAndMaterial, string name, string purchaseOrderNumber, string description, Guid userId)
            {
                if (string.IsNullOrWhiteSpace(jobOrderNumber))
                    throw new ArgumentNullException(nameof(jobOrderNumber), "A job order number must be provided");
                if (price < 0 && price != -1)
                    throw new ArgumentException("The price must be zero or higher", nameof(price));
                if (string.IsNullOrWhiteSpace(currency))
                    throw new ArgumentException("The currency must me specified", nameof(currency));
                if (dueDate < dateOfStart)
                    throw new ArgumentException("The due date cannot precede the starting date", nameof(dueDate));
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("The job order must have a name", nameof(name));

                var @event = new JobOrderRegisteredEvent(
                    jobOrderId,
                    customerId,
                    customerName,
                    contactPersonId,
                    managerId,
                    price,
                    currency,
                    dateOfRegistration,
                    dateOfStart,
                    dueDate,
                    isTimeAndMaterial,
                    name,
                    jobOrderNumber,
                    purchaseOrderNumber,
                    description,
                    userId);
                var jobOrder = new JobOrder();
                jobOrder.RaiseEvent(@event);
                return jobOrder;
            }
        }
    }
}
