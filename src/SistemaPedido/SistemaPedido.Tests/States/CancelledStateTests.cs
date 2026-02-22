using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests.States;

public class CancelledStateTests
{
    [Fact]
    public void CancelledState_Name_ShouldBeCancelled()
    {
        // Arrange
        var state = new CancelledState();

        // Act & Assert
        Assert.Equal("Cancelled", state.Name);
    }

    [Fact]
    public void CancelledState_ProcessPayment_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        order.SetState(new CancelledState());

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void CancelledState_Ship_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        order.SetState(new CancelledState());

        // Act
        order.Ship("TRACK-123");

        // Assert
        Assert.Equal("Cancelled", order.Status);
        Assert.Null(order.TrackingCode);
    }

    [Fact]
    public void CancelledState_Deliver_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        order.SetState(new CancelledState());

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Cancelled", order.Status);
        Assert.Null(order.DeliveredDate);
    }

    [Fact]
    public void CancelledState_Cancel_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        order.SetState(new CancelledState());

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void CancelledState_RequestReturn_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        order.SetState(new CancelledState());

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }
}

