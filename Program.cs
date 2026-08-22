const string NOMBRE_COMERCIO = "KIOSCO EL RECREO";

Console.WriteLine($"=== {NOMBRE_COMERCIO} ===");
Console.Write("Nombre del cajero: ");
string cajero = Console.ReadLine();

Console.WriteLine($"Bienvenida/o, {cajero}. Caja abierta.");

Console.WriteLine("Ingrese el nombre del producto:");
string producto = Console.ReadLine();

Console.WriteLine("Ingrese el precio del prducto:");
decimal precio = decimal.Parse(Console.ReadLine());

Console.WriteLine($"Producto cargado: {producto} - Precio: ${precio:F2}");