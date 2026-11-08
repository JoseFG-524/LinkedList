
namespace TallerListasLigadas
{
    // 1. NODE CLASS
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Anterior { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }
    }
    // 2. DOUBLY LINKED LIST CLASS
    public class ListaDoble<T> where T : IComparable<T>
    {
        public Nodo<T> Cabeza { get; private set; }
        public Nodo<T> Cola { get; private set; }
        public int Contador { get; private set; }

        public ListaDoble()
        {
            Cabeza = null;
            Cola = null;
            Contador = 0;
        }

        public bool EstaVacia()
        {
            return Cabeza == null;
        }

        // 3.1 Add: Insert in ascending order
        public void Adicionar(T valor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(valor);

            // Case 1: The list is empty
            if (EstaVacia())
            {
                Cabeza = nuevoNodo;
                Cola = nuevoNodo;
                Contador++;
                return;
            }

            // Case 2: The new value is less than or equal to the Head (insert at the beginning)
            if (valor.CompareTo(Cabeza.Dato) <= 0)
            {
                nuevoNodo.Siguiente = Cabeza;
                Cabeza.Anterior = nuevoNodo;
                Cabeza = nuevoNodo;
                Contador++;
                return;
            }

            // Case 3: The new value is greater than or equal to the tail (insert at the end)
            if (valor.CompareTo(Cola.Dato) >= 0)
            {
                nuevoNodo.Anterior = Cola;
                Cola.Siguiente = nuevoNodo;
                Cola = nuevoNodo;
                Contador++;
                return;
            }

            // Case 4: Insert in the middle of the list
            Nodo<T> actual = Cabeza;
            while (actual != null && actual.Dato.CompareTo(valor) < 0)
            {
                actual = actual.Siguiente;
            }

            nuevoNodo.Siguiente = actual;
            nuevoNodo.Anterior = actual.Anterior;
            actual.Anterior.Siguiente = nuevoNodo;
            actual.Anterior = nuevoNodo;

            Contador++;
        }

        // 2. Show forward
        public void MostrarHaciaAdelante()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T> actual = Cabeza;
            Console.Write("Lista (adelante): ");
            while (actual != null)
            {
                Console.Write(actual.Dato + (actual.Siguiente != null ? ", " : ""));
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }

        // 3. Show Previous
        public void MostrarHaciaAtrás()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T> actual = Cola;
            Console.Write("Lista (atrás): ");
            while (actual != null)
            {
                Console.Write(actual.Dato + (actual.Anterior != null ? ", " : ""));
                actual = actual.Anterior;
            }
            Console.WriteLine();
        }

        // 3.2 Sort in descending order (reverses the order)
        public void OrdenarDescendentemente()
        {
            if (EstaVacia() || Cabeza == Cola)
            {
                return;
            }

            Nodo<T> actual = Cabeza;
            Nodo<T> temp = null;

            while (actual != null)
            {
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;

                actual = actual.Anterior;
            }

            temp = Cabeza;
            Cabeza = Cola;
            Cola = temp;
        }

        // Supplementary Frequency Dictionary for Modes and Graphs
        private Dictionary<T, int> ObtenerFrecuencias()
        {
            Dictionary<T, int> frecuencias = new Dictionary<T, int>();
            Nodo<T> actual = Cabeza;

            while (actual != null)
            {
                if (frecuencias.ContainsKey(actual.Dato))
                {
                    frecuencias[actual.Dato]++;
                }
                else
                {
                    frecuencias[actual.Dato] = 1;
                }
                actual = actual.Siguiente;
            }

            return frecuencias;
        }

        // 3.3 Show the style(s)
        public void MostrarModas()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía, no hay modas.");
                return;
            }

            Dictionary<T, int> frecuencias = ObtenerFrecuencias();
            int maxFrecuencia = 0;

            foreach (var par in frecuencias)
            {
                if (par.Value > maxFrecuencia)
                {
                    maxFrecuencia = par.Value;
                }
            }

            List<T> modas = new List<T>();
            foreach (var par in frecuencias)
            {
                if (par.Value == maxFrecuencia)
                {
                    modas.Add(par.Key);
                }
            }

            if (modas.Count == 1)
            {
                Console.WriteLine($"La moda es {modas[0]}.");
            }
            else
            {
                Console.WriteLine($"Las modas son {string.Join(" y ", modas)}.");
            }
        }

        // 3.4 Show chart
        public void MostrarGrafico()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía, no hay gráfico que mostrar.");
                return;
            }

            Dictionary<T, int> frecuencias = ObtenerFrecuencias();

            Console.WriteLine("--- Gráfico de ocurrencias ---");
            foreach (var par in frecuencias)
            {
                string asteriscos = new string('*', par.Value);
                Console.WriteLine($"{par.Key} {asteriscos}");
            }
        }

        // 3.5 It exists
        public bool Existe(T valor)
        {
            Nodo<T> actual = Cabeza;
            while (actual != null)
            {
                if (actual.Dato.CompareTo(valor) == 0)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        // 3.6 Delete an occurrence
        public bool EliminarUnaOcurrencia(T valor)
        {
            Nodo<T> actual = Cabeza;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(valor) == 0)
                {
                    if (actual == Cabeza && actual == Cola)
                    {
                        Cabeza = null;
                        Cola = null;
                    }
                    else if (actual == Cabeza)
                    {
                        Cabeza = Cabeza.Siguiente;
                        Cabeza.Anterior = null;
                    }
                    else if (actual == Cola)
                    {
                        Cola = Cola.Anterior;
                        Cola.Siguiente = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }

                    Contador--;
                    return true;
                }
                actual = actual.Siguiente;
            }

            return false;
        }

        // 3.6 Delete all instances
        public int EliminarTodasLasOcurrencias(T valor)
        {
            int eliminados = 0;
            Nodo<T> actual = Cabeza;

            while (actual != null)
            {
                Nodo<T> siguienteNodo = actual.Siguiente;

                if (actual.Dato.CompareTo(valor) == 0)
                {
                    if (actual == Cabeza && actual == Cola)
                    {
                        Cabeza = null;
                        Cola = null;
                    }
                    else if (actual == Cabeza)
                    {
                        Cabeza = Cabeza.Siguiente;
                        Cabeza.Anterior = null;
                    }
                    else if (actual == Cola)
                    {
                        Cola = Cola.Anterior;
                        Cola.Siguiente = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }

                    Contador--;
                    eliminados++;
                }

                actual = siguienteNodo;
            }

            return eliminados;
        }
    }
}   