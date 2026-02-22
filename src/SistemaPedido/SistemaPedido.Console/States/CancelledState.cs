using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class CancelledState : IOrderState
{
    public string Name => "Cancelled";

    public void ProcessPayment(Order order) =>
        System.Console.WriteLine("❌ Pedido cancelado.");

    public void Ship(Order order, string trackingCode) =>
        System.Console.WriteLine("❌ Pedido cancelado.");

    public void Deliver(Order order) =>
        System.Console.WriteLine("❌ Pedido cancelado.");

    public void Cancel(Order order) =>
        System.Console.WriteLine("❌ Pedido já está cancelado.");

    public void RequestReturn(Order order) =>
        System.Console.WriteLine("❌ Pedido cancelado não pode ser devolvido.");
}