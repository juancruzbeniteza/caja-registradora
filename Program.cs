const string NOMBRE_COMERCIO = "KIOSCO EL RECREO";

const decimal DESCUENTO_ALTO = 0.10m;
const decimal DESCUENTO_MEDIO = 0.05m;
const decimal DESCUENTO_NULO = 0.00m;
const decimal DESCUENTO_EFECTIVO = 0.10m;
const decimal RECARGO_CREDITO = 0.15m;

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
            Console.WriteLine("Ingresar el nombre del producto:");
            string producto = Console.ReadLine();

            Console.WriteLine("Ingresar el precio del prducto:");
            decimal precio = decimal.Parse(Console.ReadLine());
            
            totalVenta += precio;
            cantidadProductos++;
                Console.WriteLine($"Producto cargado: {producto} - Precio: ${precio:F2} | Total acumulado: ${totalVenta:F2}\n");
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
            
            decimal porcentajeDescuentoMonto = totalVenta * porcentajeAplicado;
            decimal subtotalconDescuentoMonto = totalVenta - porcentajeDescuentoMonto;

            string opcionPago = "";
            bool pagoValido = false;
            decimal descuentoPago = 0m;
            decimal recargoPago = 0m;

            while (!pagoValido)
            {
                Console.WriteLine("\nMedio de pago:");
                Console.WriteLine("1-Efectivo (10% descuento adicional)");
                Console.WriteLine("2-Débito (Sin cambios)");
                Console.WriteLine("3-Crédito (15% recargo)");
                Console.Write("Opción: ");
                opcionPago = Console.ReadLine();
                switch (opcionPago)
                {
                    case "1":
                        descuentoPago = subtotalconDescuentoMonto * DESCUENTO_EFECTIVO;
                        pagoValido = true;
                        break;
                    case "2":
                        pagoValido = true;
                        break;
                    case "3":
                        recargoPago = subtotalconDescuentoMonto * RECARGO_CREDITO;
                        pagoValido = true;
                        break;
                    default:
                        Console.WriteLine("Opcion de pago invlaida. Intrente de nuevo");
                        break;
                }
            }

            decimal descuentoTotal = porcentajeDescuentoMonto + descuentoPago;
            decimal totalFinal = totalVenta - descuentoTotal + recargoPago;

            void ImprimirSeparador()
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine(); 
            }
            Console.WriteLine();
            ImprimirSeparador();
            Console.WriteLine($"       {NOMBRE_COMERCIO}");
            ImprimirSeparador();
            Console.WriteLine($"Cajero: {cajero}");
            Console.WriteLine($"Productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: {totalVenta:F2}");
            Console.WriteLine($"Descuento: {descuentoTotal:F2}");
            Console.WriteLine($"Recargo: {recargoPago:F2}");
            ImprimirSeparador();
            Console.WriteLine($"TOTAL: {totalFinal:F2}");
            ImprimirSeparador();
            break;
        default:
            Console.WriteLine("Opcion invalida. Ingrese otra");
            break;
    }
}while (opcion != "2");



