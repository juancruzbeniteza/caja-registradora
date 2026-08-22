const string NOMBRE_COMERCIO = "KIOSCO EL RECREO";

Console.WriteLine($"=== {NOMBRE_COMERCIO} ===");
Console.Write("Nombre del cajero: ");
string cajero = Console.ReadLine();

Console.WriteLine($"Bienvenida/o, {cajero}. Caja abierta.");

decimal totalVenta = 0m;
int cantidadProductos = 0;
string opcion;

do
{
    Console.WriteLine("Que desea hacer ?");
    Console.WriteLine("1-Cargar un producto");
    Console.WriteLine("2-Cerrar la venta");
    Console.Write("Opcion:");
    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Ingrese el nombre del producto:");
            string producto = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del prducto:");
            decimal precio = decimal.Parse(Console.ReadLine());
            
            totalVenta += precio;
            cantidadProductos++;

            Console.WriteLine(
                $"Producto cargado: {producto} - Precio: ${precio:F2} | Total acumulado: ${{totalVenta:F2}}\\n");
            break;
        case "2":
            Console.WriteLine("\\n--- Resumen de la Venta ---");
            Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Total a pagar: {totalVenta:F2}");
            break;
        default:
            Console.WriteLine("Opcion no valida. Ingrese 1 o 2");
            break;
    }
    
}while (opcion != "2");



