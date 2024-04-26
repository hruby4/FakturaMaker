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
        private BankPayment bankPayment = null;    // The bank payment associated with the bill.
        private Subject sender;             // The sender of the bill.
        private Subject receiver;           // The receiver of the bill.
        private List<Item> items;           // The list of items included in the bill.
        private DateOnly dueDate;           // The due date for the payment of the bill.
        private DateOnly dateOfIssue;       // The date when the bill is issued.

        /// <summary>
        /// Initializes a new instance of the <see cref="Bill"/> class with specified parameters.
        /// </summary>
        /// <param name="bankPayment">The bank payment associated with the bill.</param>
        /// <param name="sender">The sender of the bill.</param>
        /// <param name="receiver">The receiver of the bill.</param>
        /// <param name="items">The list of items included in the bill.</param>
        /// <param name="dueDate">The due date for the payment of the bill.</param>
        /// <param name="dateOfIssue">The date when the bill is issued.</param>
        public Bill(BankPayment bankPayment, Subject sender, Subject receiver, List<Item> items, DateOnly dueDate, DateOnly dateOfIssue)
        {
            if (items.Count == 0 || items == null)
            {
                throw new ArgumentException("Item list cannot be empty.");
            }
            if (dueDate < dateOfIssue)
            {
                throw new ArgumentOutOfRangeException("Due date cannot be earlier than date of issue.");
            }
            this.bankPayment = bankPayment;
            this.sender = sender;
            this.receiver = receiver;
            this.items = items;
            this.dueDate = dueDate;
            this.dateOfIssue = dateOfIssue;
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
            if (items.Count == 0 || items == null) {
                throw new ArgumentException("Item list cannot be empty.");
            }
            if (dueDate < dateOfIssue) {
                throw new ArgumentOutOfRangeException("Due date cannot be earlier than date of issue.");
            }
            this.sender = sender;
            this.receiver = receiver;
            this.items = items;
            this.dueDate = dueDate;
            this.dateOfIssue = dateOfIssue;
        }

        /// <summary>
        /// Gets or sets the bank payment associated with the bill.
        /// </summary>
        public BankPayment BankPayment { get => bankPayment; set => bankPayment = value; }

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
        /// Selects items with values higher than the specified value.
        /// </summary>
        /// <param name="value">The value to compare.</param>
        /// <returns>A list of items with values higher than the specified value.</returns>
        public List<Item> SelectItemsWithValueHigherThan(double value)
        {
            List<Item> toReturn = Items.Where(i => i.Price > value).ToList();
            return toReturn;
        }

        /// <summary>
        /// Selects items with values lower than the specified value.
        /// </summary>
        /// <param name="value">The value to compare.</param>
        /// <returns>A list of items with values lower than the specified value.</returns>
        public List<Item> SelectItemsWithValueLowerThan(double value)
        {
            List<Item> toReturn = Items.Where(i => i.Price < value).ToList();
            return toReturn;
        }

        /// <summary>
        /// Calculates the total cost of all items without VAT.
        /// </summary>
        /// <returns>The total cost of all items without VAT.</returns>
        public double GetTotal()
        {
            return this.items.Sum(item => item.GetTotal());
        }

        /// <summary>
        /// Calculates the total cost of all items including VAT.
        /// </summary>
        /// <returns>The total cost of all items including VAT.</returns>
        public double GetTotalInclVAT()
        {
            return this.items.Sum(item => item.GetTotalInclVat());
        }


        /// <summary>
        /// Returns the bill information as a formatted string.
        /// </summary>
        /// <returns>The bill information as a string.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Bill Information:");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Sender:");
            sb.AppendLine($"Name: {this.sender.Name}");
            sb.AppendLine($"City: {this.sender.Address.City}");
            sb.AppendLine($"Postal Code: {this.sender.Address.PostalCode}");
            sb.AppendLine($"House number: {this.sender.Address.HouseNumber}");
            sb.AppendLine("---------------------------------------");
            sb.AppendLine("Receiver:");
            sb.AppendLine($"Name: {this.receiver.Name}");
            sb.AppendLine($"City: {this.receiver.Address.City}");
            sb.AppendLine($"Postal Code: {this.receiver.Address.PostalCode}");
            sb.AppendLine($"House number: {this.receiver.Address.HouseNumber}");
            sb.AppendLine("---------------------------------------");
            if (this.bankPayment != null)
            {
                sb.AppendLine("Bank Payment:");
                sb.AppendLine($"Bank Account Number: {this.bankPayment.BankAccountNumber}");
                sb.AppendLine($"Bank Code: {this.bankPayment.BankCode}");
                sb.AppendLine($"Variable Symbol: {this.bankPayment.VarSym}");
                sb.AppendLine("---------------------------------------");
            }
            sb.AppendLine($"Date of Issue: {this.dateOfIssue}");
            sb.AppendLine($"Due Date: {this.dueDate}");
            sb.AppendLine("Items:");

            foreach (Item item in this.items)
            {
                sb.AppendLine($"- Name: {item.Name}");
                sb.AppendLine($"  Price: {item.Price}");
                sb.AppendLine($"  Count: {item.Count}");
                sb.AppendLine($"  Unit: {item.Unit}");
                sb.AppendLine($"  Total: {item.GetTotal()}");
                sb.AppendLine($"  VAT: {item.Vat}");
                sb.AppendLine($"  Total (incl. VAT): {item.GetTotalInclVat()}");
            }

            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"Total Amount: {GetTotal()}");
            sb.AppendLine($"Total Amount (incl. VAT): {GetTotalInclVAT()}");

            return sb.ToString();
        }


    }
}
