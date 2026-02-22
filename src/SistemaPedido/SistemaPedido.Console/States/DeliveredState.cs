using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class DeliveredState : IOrderState
{
    public string Name => "Delivered";

    public void ProcessPayment(Order order)
    {
        System.Console.WriteLine("❌ Pedido já finalizado.");
    }

    public void Ship(Order order, string trackingCode)
    {
        System.Console.WriteLine("❌ Pedido já entregue.");
    }

    public void Deliver(Order order)
    {
        System.Console.WriteLine("❌ Pedido já foi entregue.");
    }

    public void Cancel(Order order)
    {
        System.Console.WriteLine("❌ Pedido já entregue. Solicite devolução.");
    }

    public void RequestReturn(Order order)
    {
        if (!order.DeliveredDate.HasValue)
        {
            System.Console.WriteLine("❌ Data de entrega não registrada.");
            return;
        }

        var days = (DateTime.Now - order.DeliveredDate.Value).Days;

        if (days <= 7)
        {
            System.Console.WriteLine("✅ Devolução aprovada!");
            order.SetState(new ReturnedState());
        }
        else
        {
            System.Console.WriteLine("❌ Prazo de devolução expirado.");
        }
    }
}