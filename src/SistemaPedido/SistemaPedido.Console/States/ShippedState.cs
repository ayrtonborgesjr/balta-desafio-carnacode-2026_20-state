using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class ShippedState : IOrderState
{
    public string Name => "Shipped";

    public void ProcessPayment(Order order)
    {
        System.Console.WriteLine("❌ Pedido já foi pago e enviado.");
    }

    public void Ship(Order order, string trackingCode)
    {
        System.Console.WriteLine("❌ Pedido já foi enviado!");
    }

    public void Deliver(Order order)
    {
        System.Console.WriteLine("✅ Pedido entregue!");
        order.DeliveredDate = DateTime.Now;
        order.SetState(new DeliveredState());
    }

    public void Cancel(Order order)
    {
        System.Console.WriteLine("❌ Pedido já enviado. Use devolução.");
    }

    public void RequestReturn(Order order)
    {
        System.Console.WriteLine("❌ Aguarde a entrega para solicitar devolução.");
    }
}