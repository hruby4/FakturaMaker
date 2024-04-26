using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakturaMaker.src
{
    /// <summary>
    /// Represents a card payment with bank account information.
    /// </summary>
    public class BankPayment
    {
        private string bankAccountNumber; // Represents bank account information for a card payment.
        private string bankCode; // Represents the bank code for a card payment.
        private string varSym; // Represents the variable symbol for a card payment.

        /// <summary>
        /// Initializes a new instance of the <see cref="BankPayment"/> class.
        /// </summary>
        /// <param name="bankAccountNumber">The bank account number.</param>
        /// <param name="bankCode">The bank code.</param>
        /// <param name="varSym">The variable symbol.</param>
        public BankPayment(string bankAccountNumber, string bankCode, string varSym)
        {
            this.bankAccountNumber = bankAccountNumber;
            this.bankCode = bankCode;
            this.varSym = varSym;
        }

        /// <summary>
        /// Gets or sets the bank account number.
        /// </summary>
        public string BankAccountNumber { get => bankAccountNumber; set => bankAccountNumber = value; }

        /// <summary>
        /// Gets or sets the bank code.
        /// </summary>
        public string BankCode { get => bankCode; set => bankCode = value; }

        /// <summary>
        /// Gets or sets the variable symbol.
        /// </summary>
        public string VarSym { get => varSym; set => varSym = value; }

    }
}
