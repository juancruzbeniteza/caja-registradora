const string NOMBRE_COMERCIO = "KIOSCO EL RECREO";

const decimal DESCUENTO_ALTO = 0.10m;
const decimal DESCUENTO_MEDIO = 0.05m;
const decimal DESCUENTO_NULO = 0.00m;

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
            decimal porcentajeAplicado;
            if (totalVenta > 50000m)
            {
                porcentajeAplicado = DESCUENTO_ALTO;
            }
            else if (totalVenta > 20000m)
            {
                porcentajeAplicado = DESCUENTO_MEDIO;
            }
            else
            {
                porcentajeAplicado = DESCUENTO_NULO;
            }
            
            decimal montoDescuento = totalVenta * porcentajeAplicado;
            decimal totalFinal = totalVenta - montoDescuento;
            
            Console.WriteLine("\n--- Resumen de la Venta ---");
            Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: ${totalVenta:F2}");
            Console.WriteLine($"Descuento aplicado ({porcentajeAplicado * 100}%): -${montoDescuento:F2}");
            Console.WriteLine($"Total final a pagar: ${totalFinal:F2}");
            break;
        default:
            Console.WriteLine("Opcion no valida. Ingrese 1 o 2");
            break;
    }
    
}while (opcion != "2");



