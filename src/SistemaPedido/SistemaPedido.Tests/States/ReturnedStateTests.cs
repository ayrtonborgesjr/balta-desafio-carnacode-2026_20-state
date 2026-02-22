using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests.States;

public class ReturnedStateTests
{
    [Fact]
    public void ReturnedState_Name_ShouldBeReturned()
    {
        // Arrange
        var state = new ReturnedState();

        // Act & Assert
        Assert.Equal("Returned", state.Name);
    }

    [Fact]
    public void ReturnedState_ProcessPayment_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        order.SetState(new ReturnedState());

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Returned", order.Status);
    }

    [Fact]
    public void ReturnedState_Ship_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        order.SetState(new ReturnedState());

        // Act
        order.Ship("TRACK-123");

        // Assert
        Assert.Equal("Returned", order.Status);
        Assert.Null(order.TrackingCode);
    }

    [Fact]
    public void ReturnedState_Deliver_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        order.SetState(new ReturnedState());

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Returned", order.Status);
    }

    [Fact]
    public void ReturnedState_Cancel_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        order.SetState(new ReturnedState());

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Returned", order.Status);
    }

    [Fact]
    public void ReturnedState_RequestReturn_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        order.SetState(new ReturnedState());

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Returned", order.Status);
    }
}

