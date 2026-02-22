using SistemaPedido.Console.Context;

namespace SistemaPedido.Console.States;

public class ReturnedState : IOrderState
{
    public string Name => "Returned";

    public void ProcessPayment(Order order) =>
        System.Console.WriteLine("❌ Pedido já devolvido.");

    public void Ship(Order order, string trackingCode) =>
        System.Console.WriteLine("❌ Pedido já devolvido.");

    public void Deliver(Order order) =>
        System.Console.WriteLine("❌ Pedido já devolvido.");

    public void Cancel(Order order) =>
        System.Console.WriteLine("❌ Pedido já devolvido.");

    public void RequestReturn(Order order) =>
        System.Console.WriteLine("❌ Devolução já processada.");
}