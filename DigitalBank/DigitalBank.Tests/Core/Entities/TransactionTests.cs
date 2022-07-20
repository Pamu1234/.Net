using DigitalBank.Core.Contracts;
using DigitalBank.Core.Services;

namespace DigitalBank.Tests.Core.Entities
{
    [TestClass]
    public class TransactionTests
    {
        // Positive Test Case 
        [TestMethod]
        public void ShowTransactionHistory()
        {
            // Arrange
            var description = $"All transaction history for {DateTime.Now.ToShortDateString()}";
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            ITransactionService transactionService = new TransactionService();

            // Act
            var transactionHistory = transactionService.GetTransactionHistory(account.Transactions);
            var matchingNoteFound = transactionHistory.TransactionHistory.Contains("Initial amount.", StringComparison.CurrentCultureIgnoreCase);

            // Assert
            Assert.AreEqual(description, transactionHistory.Description);
            Assert.IsTrue(matchingNoteFound);

        }
    }
}
