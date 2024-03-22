using NUnit.Framework;
using System.Security.Principal;


[TestFixture]
public class AccountTests
{
    [Test]
    public void WithDraw_SufficientBalance_ReturnsTrueAndUpdatesBalance()
    {
        // Arrange
        Account account = new Account(1, "Savings", 1000);

        // Act
        bool withdrawResult = account.WithDraw(500);

        // Assert
        Assert.IsTrue(withdrawResult);
        Assert.AreEqual(500, account.Balance);
    }

    [Test]
    public void WithDraw_InsufficientBalance_ReturnsFalseAndDoesNotUpdateBalance()
    {
        // Arrange
        Account account = new Account(1, "Savings", 100);

        // Act
        bool withdrawResult = account.WithDraw(500);

        // Assert
        Assert.IsFalse(withdrawResult);
        Assert.AreEqual(100, account.Balance);
    }

    [Test]
    public void GetDetails_ReturnsCorrectDetails()
    {
        // Arrange
        Account account = new Account(1, "Savings", 1000);
        string expectedDetails = "Account Id: 1\nAccount Type: Savings\nBalance: 1000";

        // Act
        string actualDetails = account.GetDetails();

        // Assert
        Assert.AreEqual(expectedDetails, actualDetails);
    }
}
