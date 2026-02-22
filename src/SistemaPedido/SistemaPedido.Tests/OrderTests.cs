using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests;

public class OrderTests
{
    [Fact]
    public void Order_ShouldInitialize_WithCorrectValues()
    {
        // Arrange & Act
        var order = new Order("ORD-001", 100.50m);

        // Assert
        Assert.Equal("ORD-001", order.OrderId);
        Assert.Equal(100.50m, order.TotalAmount);
        Assert.Equal("Pending", order.Status);
        Assert.Null(order.TrackingCode);
        Assert.Null(order.ShippedDate);
        Assert.Null(order.DeliveredDate);
    }

    [Fact]
    public void Order_ShouldStartWith_PendingState()
    {
        // Arrange & Act
        var order = new Order("ORD-002", 250.00m);

        // Assert
        Assert.Equal("Pending", order.Status);
    }

    [Fact]
    public void Order_ProcessPayment_ShouldChangeState_ToPaid()
    {
        // Arrange
        var order = new Order("ORD-003", 150.00m);

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Paid", order.Status);
    }

    [Fact]
    public void Order_Ship_ShouldSetTrackingCodeAndDate_WhenPaid()
    {
        // Arrange
        var order = new Order("ORD-004", 200.00m);
        order.ProcessPayment();

        // Act
        order.Ship("TRACK-123");

        // Assert
        Assert.Equal("Shipped", order.Status);
        Assert.Equal("TRACK-123", order.TrackingCode);
        Assert.NotNull(order.ShippedDate);
    }

    [Fact]
    public void Order_Deliver_ShouldSetDeliveredDate_WhenShipped()
    {
        // Arrange
        var order = new Order("ORD-005", 300.00m);
        order.ProcessPayment();
        order.Ship("TRACK-456");

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Delivered", order.Status);
        Assert.NotNull(order.DeliveredDate);
    }

    [Fact]
    public void Order_Cancel_ShouldChangeState_ToCancelled_WhenPending()
    {
        // Arrange
        var order = new Order("ORD-006", 120.00m);

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void Order_Cancel_ShouldChangeState_ToCancelled_WhenPaid()
    {
        // Arrange
        var order = new Order("ORD-007", 180.00m);
        order.ProcessPayment();

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Cancelled", order.Status);
    }

    [Fact]
    public void Order_RequestReturn_ShouldChangeState_ToReturned_WhenWithin7Days()
    {
        // Arrange
        var order = new Order("ORD-008", 400.00m);
        order.ProcessPayment();
        order.Ship("TRACK-789");
        order.Deliver();

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Returned", order.Status);
    }

    [Fact]
    public void Order_SetState_ShouldChangeState()
    {
        // Arrange
        var order = new Order("ORD-009", 100.00m);
        var paidState = new PaidState();

        // Act
        order.SetState(paidState);

        // Assert
        Assert.Equal("Paid", order.Status);
    }
}

