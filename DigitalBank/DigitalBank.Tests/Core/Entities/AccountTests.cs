namespace DigitalBank.Tests.Core.Entities
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        // Positive Test Case
        public void Account_ValidOpeningBalance_MustSuccessed()
        {
            // Arrange
            var owner = new Owner("Avishek", "Kumar");
            var opeaningBalance = new Amount { Value = 600, Currency = CurrencyType.INR };
            ulong expectedAccountNumber = 1000000000000000;

            // Act
            var account = new Account(owner, opeaningBalance);

            // Assert
            Assert.AreEqual<decimal>(opeaningBalance.Value, account.Balance);
            Assert.AreEqual("Initial amount.", account.Transactions.First().Note);
            Assert.AreEqual(expectedAccountNumber, account.Number);
        }

        // Negative Test Case
        [TestMethod]
        public void Account_InvalidOpeningBalance_ShouldThrowError()
        {
            // Arrange
            var owner = new Owner("Avishek", "Kumar");
            var opeaningBalance = new Amount { Value = 300, Currency = CurrencyType.INR };

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Account(owner, opeaningBalance));
        }

        // Positive Test Case
        [TestMethod]
        public void Deposite_ValidAmount_MustSuccess()
        {
            // Arrange
            decimal depositAmount = 200m;
            decimal expectedBalance = 700;
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act
            var depositResult = account.Deposite(new Amount { Value= depositAmount , Currency= CurrencyType.INR }, DateTime.Now, "Depositing valid amount.");

            // Assert
            Assert.IsTrue(depositResult);
            Assert.AreEqual(expectedBalance, account.Balance);
        }

        // Negative Test Case
        [DataTestMethod]
        [DataRow(0d)]
        [DataRow(-1.5)]
        public void Deposite_AmountZeroOrLess_ShouldThrowError(double depositAmount)
        {
            // Arrange
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposite(new Amount { Value = (decimal)depositAmount, Currency = CurrencyType.INR }, DateTime.Now, "Depositing valid amount."));

        }

        // Positive Test Case
        [TestMethod]
        public void Withdraw_Amount_Validation_ShouldSucceed()
        {
            // Arrange
            decimal withdrawAmount = 200m;
            decimal expectedBalance = 600;
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount{ Value = 800, Currency = CurrencyType.INR });
        
            // Act
            var withdrawResult = account.Withdraw(new Amount { Value = withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Paying Rent.");


            //Assert
            Assert.IsTrue(withdrawResult);
            Assert.AreEqual(expectedBalance,account.Balance);
        }

        // Negative Test Case
        [DataTestMethod]

        [DataRow(501)]
        [DataRow(-1)]

        public void Withdraw_AmountZeroOrLess_ShouldThrowError(double withdrawAmount)
        {
            // Arrange
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act & Assert 
            if (withdrawAmount < 0)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(new Amount { Value = (decimal)withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Invalid Amount."));
            }
            else if (withdrawAmount >500)
            {
                Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(new Amount { Value = (decimal)withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Invalid Amount."));
            }
        }

        
    }
}
