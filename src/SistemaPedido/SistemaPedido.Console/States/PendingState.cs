using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class PendingState : IOrderState
{
    public string Name => "Pending";

    public void ProcessPayment(Order order)
    {
        System.Console.WriteLine($"\n[{order.OrderId}] Processando pagamento...");
        System.Console.WriteLine($"✅ Pagamento confirmado! Total: R$ {order.TotalAmount:N2}");
        order.SetState(new PaidState());
    }

    public void Ship(Order order, string trackingCode)
    {
        System.Console.WriteLine("❌ Pedido ainda não foi pago!");
    }

    public void Deliver(Order order)
    {
        System.Console.WriteLine("❌ Pedido ainda não foi enviado!");
    }

    public void Cancel(Order order)
    {
        System.Console.WriteLine("✅ Pedido cancelado. Nenhuma cobrança realizada.");
        order.SetState(new CancelledState());
    }

    public void RequestReturn(Order order)
    {
        System.Console.WriteLine("❌ Pedido ainda não foi entregue.");
    }
}