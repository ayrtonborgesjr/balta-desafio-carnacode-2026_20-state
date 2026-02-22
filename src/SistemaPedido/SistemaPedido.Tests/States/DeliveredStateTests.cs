using SistemaPedido.Console.Context;
using SistemaPedido.Console.States;

namespace SistemaPedido.Tests.States;

public class DeliveredStateTests
{
    [Fact]
    public void DeliveredState_Name_ShouldBeDelivered()
    {
        // Arrange
        var state = new DeliveredState();

        // Act & Assert
        Assert.Equal("Delivered", state.Name);
    }

    [Fact]
    public void DeliveredState_ProcessPayment_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-001", 100.00m);
        order.SetState(new DeliveredState());

        // Act
        order.ProcessPayment();

        // Assert
        Assert.Equal("Delivered", order.Status);
    }

    [Fact]
    public void DeliveredState_Ship_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-002", 100.00m);
        order.SetState(new DeliveredState());

        // Act
        order.Ship("TRACK-123");

        // Assert
        Assert.Equal("Delivered", order.Status);
    }

    [Fact]
    public void DeliveredState_Deliver_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-003", 100.00m);
        order.SetState(new DeliveredState());

        // Act
        order.Deliver();

        // Assert
        Assert.Equal("Delivered", order.Status);
    }

    [Fact]
    public void DeliveredState_Cancel_ShouldNotChangeState()
    {
        // Arrange
        var order = new Order("ORD-004", 100.00m);
        order.SetState(new DeliveredState());

        // Act
        order.Cancel();

        // Assert
        Assert.Equal("Delivered", order.Status);
    }

    [Fact]
    public void DeliveredState_RequestReturn_ShouldChangeState_ToReturned_WhenWithin7Days()
    {
        // Arrange
        var order = new Order("ORD-005", 100.00m);
        order.SetState(new DeliveredState());
        order.DeliveredDate = DateTime.Now;

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Returned", order.Status);
    }

    [Fact]
    public void DeliveredState_RequestReturn_ShouldNotChangeState_WhenAfter7Days()
    {
        // Arrange
        var order = new Order("ORD-006", 100.00m);
        order.SetState(new DeliveredState());
        order.DeliveredDate = DateTime.Now.AddDays(-8);

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Delivered", order.Status);
    }

    [Fact]
    public void DeliveredState_RequestReturn_ShouldNotChangeState_WhenDeliveredDateIsNull()
    {
        // Arrange
        var order = new Order("ORD-007", 100.00m);
        order.SetState(new DeliveredState());
        order.DeliveredDate = null;

        // Act
        order.RequestReturn();

        // Assert
        Assert.Equal("Delivered", order.Status);
    }
}

