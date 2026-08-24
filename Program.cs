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
            Console.WriteLine("Ingrese el nombre del producto:");
            string producto = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del prducto:");
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
            decimal totalconDescuentoMonto = totalVenta - porcentajeDescuentoMonto;

            string opcionPago = "";
            bool pagoValido = false;
            decimal ajustePago = 0m;
            string detalleAjustePago = "Sin cambios";

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
                        ajustePago = -(totalconDescuentoMonto * DESCUENTO_EFECTIVO);
                        detalleAjustePago = $"Deswuento efectivo ({DESCUENTO_EFECTIVO * 100:0}%): -${Math.Abs(ajustePago):F2}";
                        pagoValido = true;
                        break;
                    case "2":
                        ajustePago = 0m;
                        detalleAjustePago = "Debito: $0.00";
                        pagoValido = true;
                        break;
                    case "3":
                        ajustePago = totalconDescuentoMonto * RECARGO_CREDITO;
                        detalleAjustePago = $"Recargo crédito ({RECARGO_CREDITO * 100:0}%): +${ajustePago:F2}";
                        pagoValido = true;
                        break;
                    default:
                        Console.WriteLine("Opcion de pago invlaida. Intrente de nuevo");
                        break;
                }
            }
            decimal totalFinal = totalconDescuentoMonto + ajustePago;
            
            Console.WriteLine("\n--- Resumen de la Venta ---");
            Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: ${totalVenta:F2}");
            Console.WriteLine($"Descuento por total ({porcentajeAplicado * 100:0}%): -${porcentajeDescuentoMonto:F2}");
            Console.WriteLine($"Total intermedio: ${totalconDescuentoMonto:F2}");
            Console.WriteLine($"Ajuste por medio de pago: {detalleAjustePago}");
            Console.WriteLine($"Total final a pagar: ${totalFinal:F2}");
            break;
        default:
            Console.WriteLine("Opcion no valida. Ingrese 1 o 2");
            break;
    }
    
}while (opcion != "2");



