using SistemaPedido.Console.States;

namespace SistemaPedido.Console.Context;

public class Order
{
    public string OrderId { get; }
    public decimal TotalAmount { get; }
    public string? TrackingCode { get; set; }
    public DateTime? ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }

    private IOrderState _state;

    public string Status => _state.Name;

    public Order(string orderId, decimal totalAmount)
    {
        OrderId = orderId;
        TotalAmount = totalAmount;
        _state = new PendingState(); // Estado inicial
    }

    public void SetState(IOrderState state)
    {
        _state = state;
        System.Console.WriteLine($"   🔄 Status alterado para: {_state.Name}");
    }

    public void ProcessPayment() => _state.ProcessPayment(this);
    public void Ship(string trackingCode) => _state.Ship(this, trackingCode);
    public void Deliver() => _state.Deliver(this);
    public void Cancel() => _state.Cancel(this);
    public void RequestReturn() => _state.RequestReturn(this);
}