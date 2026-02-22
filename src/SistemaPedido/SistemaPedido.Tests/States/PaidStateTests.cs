using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests.States;

public class PaidStateTests
{
    [Fact]
    public void PaidState_Name_ShouldBePaid()
    {
        // Arrange
        var state = new PaidState();

        // Act & Assert
        Assert.Equal("Paid", state.Name);
    }

    [Fact]
    public void PaidState_ProcessPayment_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        order.SetState(new PaidState());

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Paid", order.Status);
    }

    [Fact]
    public void PaidState_Ship_ShouldChangeState_ToShipped()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        order.SetState(new PaidState());

        // Act
        order.Ship("TRACK-123");

        // Assert
        Assert.Equal("Shipped", order.Status);
        Assert.Equal("TRACK-123", order.TrackingCode);
        Assert.NotNull(order.ShippedDate);
    }

    [Fact]
    public void PaidState_Deliver_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        order.SetState(new PaidState());

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Paid", order.Status);
        Assert.Null(order.DeliveredDate);
    }

    [Fact]
    public void PaidState_Cancel_ShouldChangeState_ToCancelled()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        order.SetState(new PaidState());

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void PaidState_RequestReturn_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        order.SetState(new PaidState());

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Paid", order.Status);
    }
}

