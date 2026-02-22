using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests.States;

public class PendingStateTests
{
    [Fact]
    public void PendingState_Name_ShouldBePending()
    {
        // Arrange
        var state = new PendingState();

        // Act & Assert
        Assert.Equal("Pending", state.Name);
    }

    [Fact]
    public void PendingState_ProcessPayment_ShouldChangeState_ToPaid()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        var state = new PendingState();

        // Act
        state.ProcessPayment(order);

        // Assert
        Assert.Equal("Paid", order.Status);
    }

    [Fact]
    public void PendingState_Ship_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        var state = new PendingState();

        // Act
        state.Ship(order, "TRACK-123");

        // Assert
        Assert.Equal("Pending", order.Status);
        Assert.Null(order.TrackingCode);
    }

    [Fact]
    public void PendingState_Deliver_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        var state = new PendingState();

        // Act
        state.Deliver(order);

        // Assert
        Assert.Equal("Pending", order.Status);
        Assert.Null(order.DeliveredDate);
    }

    [Fact]
    public void PendingState_Cancel_ShouldChangeState_ToCancelled()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        var state = new PendingState();

        // Act
        state.Cancel(order);

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void PendingState_RequestReturn_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        var state = new PendingState();

        // Act
        state.RequestReturn(order);

        // Assert
        Assert.Equal("Pending", order.Status);
    }
}

