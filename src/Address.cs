using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturaMaker.src
{
    /// <summary>
    /// Represents an address with detailed information.
    /// </summary>
    public class Address
    {
        private string city; // The city where the address is located.
        private string street; // The street of the address.
        private int houseNumber; // The house number of the address.
        private string postalCode; // The postal code of the address.

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with the specified city, street, house number, and postal code.
        /// </summary>
        /// <param name="city">The city where the address is located.</param>
        /// <param name="street">The street of the address.</param>
        /// <param name="houseNumber">The house number of the address.</param>
        /// <param name="postalCode">The postal code of the address.</param>
        public Address(string city, string street, int houseNumber, string postalCode)
        {
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.postalCode = postalCode;
        }

        /// <summary>
        /// Gets or sets the city where the address is located.
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Gets or sets the street of the address.
        /// </summary>
        public string Street { get => street; set => street = value; }

        /// <summary>
        /// Gets or sets the house number of the address.
        /// </summary>
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public string PostalCode { get => postalCode; set => postalCode = value; }
    }
}
