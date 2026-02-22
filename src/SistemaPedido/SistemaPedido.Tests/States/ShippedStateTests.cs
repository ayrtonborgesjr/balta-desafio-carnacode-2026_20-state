using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests;

public class ShippedStateTests
{
    [Fact]
    public void ShippedState_Name_ShouldBeShipped()
    {
        // Arrange
        var state = new ShippedState();

        // Act & Assert
        Assert.Equal("Shipped", state.Name);
    }

    [Fact]
    public void ShippedState_ProcessPayment_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        order.SetState(new ShippedState());

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Shipped", order.Status);
    }

    [Fact]
    public void ShippedState_Ship_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        order.SetState(new ShippedState());

        // Act
        order.Ship("TRACK-456");

        // Assert
        Assert.Equal("Shipped", order.Status);
    }

    [Fact]
    public void ShippedState_Deliver_ShouldChangeState_ToDelivered()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        order.SetState(new ShippedState());

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Delivered", order.Status);
        Assert.NotNull(order.DeliveredDate);
    }

    [Fact]
    public void ShippedState_Cancel_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        order.SetState(new ShippedState());

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Shipped", order.Status);
    }

    [Fact]
    public void ShippedState_RequestReturn_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        order.SetState(new ShippedState());

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Shipped", order.Status);
    }
}

