using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturaMaker.src
{
    /// <summary>
    /// Represents a subject with basic information.
    /// </summary>
    public class Subject
    {
        private string name; // The name of the subject.
        private int idNumber; // The identification number of the subject.
        private string taxIdNumber; // The tax identification number of the subject.
        private Address address; // The address of the subject.
        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class with the specified name, ID number, and tax ID number.
        /// </summary>
        /// <param name="name">The name of the subject.</param>
        /// <param name="idNumber">The identification number of the subject.</param>
        /// <param name="taxIdNumber">The tax identification number of the subject.</param>
        /// <param name="address">The address of the subject.</param>
        public Subject(string name, int idNumber, string taxIdNumber, Address address)
        {
            this.name = name;
            this.idNumber = idNumber;
            this.taxIdNumber = taxIdNumber;
            this.address = address;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class with the specified name and ID number.
        /// </summary>
        /// <param name="name">The name of the subject.</param>
        /// <param name="idNumber">The identification number of the subject.</param>
        /// <param name="address">The address of the subject.</param>
        public Subject(string name, int idNumber, Address address)
        {
            this.name = name;
            this.idNumber = idNumber;
            this.taxIdNumber = taxIdNumber;
            this.address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the subject.</param>

        /// <param name="address">The address of the subject.</param>
        public Subject(string name, Address address)
        {
            this.name = name;
            this.taxIdNumber = taxIdNumber;
            this.address = address;
        }

        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the identification number of the subject.
        /// </summary>
        public int IdNumber { get => idNumber; set => idNumber = value; }

        /// <summary>
        /// Gets or sets the tax identification number of the subject.
        /// </summary>
        public string TaxIdNumber { get => taxIdNumber; set => taxIdNumber = value; }

        /// <summary>
        /// Gets or sets the address of the subject.
        /// </summary>
        public Address Address { get => address; set => address = value; }
    }
}
