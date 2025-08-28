using CartEntities;

namespace Store.Tests;

[TestClass]
public class CartEntitiesTests
{
    [TestMethod]
    public void CartCalculation_SubtotalTaxTotalItemCount_CalculatedCorrectly()
    {
        // Arrange
        var cart = new Cart();
        cart.Items.Add(new CartItem 
        { 
            ProductId = 1, 
            Name = "Product 1", 
            Price = 10.00m, 
            Quantity = 2 
        });
        cart.Items.Add(new CartItem 
        { 
            ProductId = 2, 
            Name = "Product 2", 
            Price = 15.50m, 
            Quantity = 1 
        });
        cart.Items.Add(new CartItem 
        { 
            ProductId = 3, 
            Name = "Product 3", 
            Price = 7.25m, 
            Quantity = 3 
        });

        // Act & Assert
        // Subtotal: (10.00 * 2) + (15.50 * 1) + (7.25 * 3) = 20.00 + 15.50 + 21.75 = 57.25
        Assert.AreEqual(57.25m, cart.Subtotal, "Subtotal calculation is incorrect");

        // Tax: 57.25 * 0.08 = 4.58
        Assert.AreEqual(4.58m, cart.Tax, "Tax calculation is incorrect");

        // Total: 57.25 + 4.58 = 61.83
        Assert.AreEqual(61.83m, cart.Total, "Total calculation is incorrect");

        // ItemCount: 2 + 1 + 3 = 6
        Assert.AreEqual(6, cart.ItemCount, "Item count calculation is incorrect");
    }

    [TestMethod]
    public void CartCalculation_EmptyCart_ReturnsZero()
    {
        // Arrange
        var cart = new Cart();

        // Act & Assert
        Assert.AreEqual(0m, cart.Subtotal);
        Assert.AreEqual(0m, cart.Tax);
        Assert.AreEqual(0m, cart.Total);
        Assert.AreEqual(0, cart.ItemCount);
    }

    [TestMethod]
    public void CartItem_Total_CalculatedCorrectly()
    {
        // Arrange
        var cartItem = new CartItem
        {
            Price = 12.99m,
            Quantity = 4
        };

        // Act & Assert
        Assert.AreEqual(51.96m, cartItem.Total);
    }

    [TestMethod]
    public void CartItem_Total_WithZeroQuantity_ReturnsZero()
    {
        // Arrange
        var cartItem = new CartItem
        {
            Price = 12.99m,
            Quantity = 0
        };

        // Act & Assert
        Assert.AreEqual(0m, cartItem.Total);
    }

    [TestMethod]
    public void CartCalculation_WithDecimalPrices_RoundsCorrectly()
    {
        // Arrange
        var cart = new Cart();
        cart.Items.Add(new CartItem 
        { 
            ProductId = 1, 
            Name = "Product 1", 
            Price = 9.99m, 
            Quantity = 1 
        });

        // Act & Assert
        // Subtotal: 9.99
        Assert.AreEqual(9.99m, cart.Subtotal);

        // Tax: 9.99 * 0.08 = 0.7992, should round to 0.80
        Assert.AreEqual(0.80m, Math.Round(cart.Tax, 2));

        // Total: 9.99 + 0.7992 = 10.7892, should be 10.79 when components are rounded
        Assert.AreEqual(10.79m, Math.Round(cart.Total, 2));
    }
}