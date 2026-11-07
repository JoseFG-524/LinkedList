
using TallerListasLigadas;

internal class Program
{
    static void Main(string[] args)
    {
        // Se crea una lista genérica
        ListaDoble<string> lista = new ListaDoble<string>();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("    TALLER 5 - LISTAS LIGADAS    ");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atrás");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.WriteLine("---------------------------------");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el elemento a adicionar: ");
                    string nuevoElemento = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoElemento))
                    {
                        lista.Adicionar(nuevoElemento);
                        Console.WriteLine($"Elemento '{nuevoElemento}' adicionado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El elemento no puede estar vacío.");
                    }
                    break;

                case "2":
                    lista.MostrarHaciaAdelante();
                    break;

                case "3":
                    lista.MostrarHaciaAtrás();
                    break;

                case "4":
                    lista.OrdenarDescendentemente();
                    Console.WriteLine("La lista se ha ordenado descendentemente.");
                    break;

                case "5":
                    lista.MostrarModas();
                    break;

                case "6":
                    lista.MostrarGrafico();
                    break;

                case "7":
                    Console.Write("Ingrese el elemento a buscar: ");
                    string elementoBuscar = Console.ReadLine();
                    if (lista.Existe(elementoBuscar))
                    {
                        Console.WriteLine($"El elemento '{elementoBuscar}' SÍ existe en la lista.");
                    }
                    else
                    {
                        Console.WriteLine($"No existe el '{elementoBuscar}'.");
                    }
                    break;

                case "8":
                    Console.Write("Ingrese el elemento a eliminar (una ocurrencia): ");
                    string elementoEliminarUno = Console.ReadLine();
                    if (lista.EliminarUnaOcurrencia(elementoEliminarUno))
                    {
                        Console.WriteLine($"Se eliminó una ocurrencia de '{elementoEliminarUno}'.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el elemento '{elementoEliminarUno}'.");
                    }
                    break;

                case "9":
                    Console.Write("Ingrese el elemento a eliminar (todas las ocurrencias): ");
                    string elementoEliminarTodos = Console.ReadLine();
                    int eliminados = lista.EliminarTodasLasOcurrencias(elementoEliminarTodos);
                    if (eliminados > 0)
                    {
                        Console.WriteLine($"Se eliminaron {eliminados} ocurrencia(s) de '{elementoEliminarTodos}'.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el elemento '{elementoEliminarTodos}'.");
                    }
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}