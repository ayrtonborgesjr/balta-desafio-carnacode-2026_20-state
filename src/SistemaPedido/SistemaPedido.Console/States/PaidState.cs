using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class PaidState : IOrderState
{
    public string Name => "Paid";

    public void ProcessPayment(Order order)
    {
        System.Console.WriteLine("❌ Pedido já foi pago!");
    }

    public void Ship(Order order, string trackingCode)
    {
        System.Console.WriteLine("✅ Pedido enviado!");
        order.TrackingCode = trackingCode;
        order.ShippedDate = DateTime.Now;
        order.SetState(new ShippedState());
    }

    public void Deliver(Order order)
    {
        System.Console.WriteLine("❌ Pedido ainda não foi enviado!");
    }

    public void Cancel(Order order)
    {
        System.Console.WriteLine($"✅ Pedido cancelado. Reembolso: R$ {order.TotalAmount:N2}");
        order.SetState(new CancelledState());
    }

    public void RequestReturn(Order order)
    {
        System.Console.WriteLine("❌ Pedido ainda não foi entregue.");
    }
}