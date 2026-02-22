using SistemaPedido.Console.Context;

var order = new Order("ORD-001", 250m);

order.ProcessPayment();
order.Ship("BR123456789");
order.Deliver();
order.RequestReturn();

Console.WriteLine("\n=== Novo Pedido ===");

var order2 = new Order("ORD-002", 150m);

order2.Ship("BR000000000");  // inválido
order2.ProcessPayment();
order2.Cancel();