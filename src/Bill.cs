using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturaMaker.src
{
    /// <summary>
    /// Represents a bill containing payment information, sender and receiver details, items, due date, date of issue, and total amount.
    /// </summary>
    public class Bill
    {
        private CardPayment cardPayment;    // The card payment associated with the bill.
        private Subject sender;             // The sender of the bill.
        private Subject receiver;           // The receiver of the bill.
        private List<Item> items;           // The list of items included in the bill.
        private DateOnly dueDate;           // The due date for the payment of the bill.
        private DateOnly dateOfIssue;       // The date when the bill is issued.
        private double total;               // The total amount of the bill.
        private double totalInclVat;       // The total amount of the bill including VAT (Value Added Tax).

        /// <summary>
        /// Initializes a new instance of the <see cref="Bill"/> class with specified parameters.
        /// </summary>
        /// <param name="cardPayment">The card payment associated with the bill.</param>
        /// <param name="sender">The sender of the bill.</param>
        /// <param name="receiver">The receiver of the bill.</param>
        /// <param name="items">The list of items included in the bill.</param>
        /// <param name="dueDate">The due date for the payment of the bill.</param>
        /// <param name="dateOfIssue">The date when the bill is issued.</param>
        public Bill(CardPayment cardPayment, Subject sender, Subject receiver, List<Item> items, DateOnly dueDate, DateOnly dateOfIssue)
        {
            this.CardPayment = cardPayment;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Items = items;
            this.DueDate = dueDate;
            this.DateOfIssue = dateOfIssue;
            this.Total = this.Items.Sum(item => item.Total);
            this.TotalInclVat = this.Items.Sum(item => item.TotalInclVat);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Bill"/> class with specified parameters.
        /// </summary>
        /// <param name="sender">The sender of the bill.</param>
        /// <param name="receiver">The receiver of the bill.</param>
        /// <param name="items">The list of items included in the bill.</param>
        /// <param name="dueDate">The due date for the payment of the bill.</param>
        /// <param name="dateOfIssue">The date when the bill is issued.</param>
        public Bill(Subject sender, Subject receiver, List<Item> items, DateOnly dueDate, DateOnly dateOfIssue)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.items = items;
            this.dueDate = dueDate;
            this.dateOfIssue = dateOfIssue;
            this.Total = this.Items.Sum(item => item.Total);
            this.TotalInclVat = this.Items.Sum(item => item.TotalInclVat);
        }

        /// <summary>
        /// Gets or sets the card payment associated with the bill.
        /// </summary>
        public CardPayment CardPayment { get => cardPayment; set => cardPayment = value; }

        /// <summary>
        /// Gets or sets the sender of the bill.
        /// </summary>
        public Subject Sender { get => sender; set => sender = value; }

        /// <summary>
        /// Gets or sets the receiver of the bill.
        /// </summary>
        public Subject Receiver { get => receiver; set => receiver = value; }

        /// <summary>
        /// Gets or sets the list of items included in the bill.
        /// </summary>
        public List<Item> Items { get => items; set => items = value; }

        /// <summary>
        /// Gets or sets the due date for the payment of the bill.
        /// </summary>
        public DateOnly DueDate { get => dueDate; set => dueDate = value; }

        /// <summary>
        /// Gets or sets the date when the bill is issued.
        /// </summary>
        public DateOnly DateOfIssue { get => dateOfIssue; set => dateOfIssue = value; }

        /// <summary>
        /// Gets or sets the total amount of the bill.
        /// </summary>
        public double Total { get => total; set => total = value; }

        /// <summary>
        /// Gets or sets the total amount of the bill including VAT (Value Added Tax).
        /// </summary>
        public double TotalInclVat { get => totalInclVat; set => totalInclVat = value; }
    }
}
