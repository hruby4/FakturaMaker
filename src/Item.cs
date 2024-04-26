using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturaMaker.src
{
    /// <summary>
    /// Represents an item with its properties such as name, price, count, unit, total, VAT, and total including VAT.
    /// </summary>
    public class Item
    {
        private string name;
        private double price;
        private int count;
        private string unit;
        private double total;
        private double vat;
        private double totalInclVat;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class with specified properties.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="price">The price of the item.</param>
        /// <param name="count">The count of the item.</param>
        /// <param name="unit">The unit of the item.</param>
        /// <param name="vat">The value-added tax (VAT) applied to the item.</param>
        public Item(string name, double price, int count, string unit, double vat)
        {
            if (price < 0) { throw new ArgumentException("Price cannot be negative."); }
            if (count < 0) { throw new ArgumentException("Count cannot be negative."); }
            this.name = name;
            this.price = price;
            this.count = count;
            this.unit = unit;
            this.vat = vat;
        }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        /// <value>The price of the item.</value>
        public double Price { get => price; set => price = value; }

        /// <summary>
        /// Gets or sets the count of the item.
        /// </summary>
        /// <value>The count of the item.</value>
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Gets or sets the unit of the item.
        /// </summary>
        /// <value>The unit of the item.</value>
        public string Unit { get => unit; set => unit = value; }

        /// <summary>
        /// Gets or sets the value-added tax (VAT) applied to the item.
        /// </summary>
        /// <value>The value-added tax (VAT) applied to the item.</value>
        public double Vat { get => vat; set => vat = value; }

        /// <summary>
        /// Calculates the total cost based on the count and price per unit, excluding VAT.
        /// </summary>
        /// <returns>The total cost excluding VAT.</returns>
        public double GetTotal()
        {
            return count * price;
        }

        /// <summary>
        /// Calculates the total cost based on the count, price per unit, and VAT.
        /// </summary>
        /// <returns>The total cost including VAT.</returns>
        public double GetTotalInclVat()
        {
            return this.count * this.price * (1 + this.vat / 100);
        }


    }
}
