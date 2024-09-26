using System;
using System.Collections.Generic;

namespace SP4
{
    public class ListaEnlazada
    {
        public Nodo Primero { get; set; } // Referencia al primer nodo de la lista
        public Nodo Ultimo { get; set; } // Referencia al último nodo de la lista

        public ListaEnlazada()
        {
            // Inicializamos la lista vacía con ambos apuntadores en null
            Primero = null;
            Ultimo = null;
        }

       
        
        
        // Método para verificar si la lista está vacía
        public bool EstaVacia()
        {
            return Primero == null && Ultimo == null;
        }



        // Método para insertar un nodo en la lista de manera ordenada
        public void Insertar(Nodo nuevo)
        {
            if (EstaVacia()) // Si la lista está vacía, creamos el nodo
            {
                Primero = nuevo;
                Ultimo = nuevo;
            }
            else
            {
                // Caso 1: El nuevo nodo tiene que ir al principio
                if (nuevo.Fecha < Primero.Fecha)
                {
                    nuevo.Siguiente = Primero; // El nuevo apunta al actual primero
                    Primero = nuevo; // El nuevo nodo se convierte en el primero
                }
                // Caso 2: El nuevo nodo tiene que ir al final
                else if (nuevo.Fecha > Ultimo.Fecha)
                {
                    Ultimo.Siguiente = nuevo; // El último apunta al nuevo nodo
                    Ultimo = nuevo; // El nuevo nodo se convierte en el último
                }
                // Caso 3: El nuevo nodo va en el medio
                else
                {
                    Nodo anterior = null;
                    Nodo auxiliar = Primero;

                    // Recorremos hasta encontrar la posición correcta
                    while (auxiliar != null && nuevo.Fecha > auxiliar.Fecha)
                    {
                        anterior = auxiliar; // Guardamos el nodo anterior
                        auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo
                    }

                    anterior.Siguiente = nuevo; // Enlazamos el nodo anterior al nuevo
                    nuevo.Siguiente = auxiliar; // El nuevo nodo apunta al auxiliar
                }
            }
        }




        // Método para listar todos los nodos
        public List<Nodo> Listar()
        {
            List<Nodo> movimientos = new List<Nodo>(); // Creamos una lista vacía
            Nodo auxiliar = Primero; // Comenzamos desde el primer nodo

            // Recorremos la lista hasta el final
            while (auxiliar != null)
            {
                movimientos.Add(auxiliar); // Añadimos el nodo a la lista
                auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo
            }

            return movimientos; // Devolvemos la lista con todos los nodos
        }

       
        
        
        
        
        
        // Método para buscar un nodo por su fecha , puede ser por otro campo .
        public Nodo Buscar(DateTime fecha)
        {
            Nodo actual = Primero; // Comenzamos desde el primer nodo

            // Recorremos la lista buscando la fecha
            while (actual != null)
            {
                if (actual.Fecha == fecha) // Si encontramos el nodo con esa fecha u otro campo la estructura es la misma. 
                {
                    return actual; // Lo devolvemos
                }
                actual = actual.Siguiente; // Avanzamos al siguiente nodo
            }

            return null; // Si no lo encontramos, devolvemos null
        }

        
        
        // Método para eliminar un nodo por su fecha
        public bool Eliminar(DateTime fecha)
        {
            if (Primero == null)
            {
                Console.WriteLine("La lista está vacía.");
                return false; // Si la lista está vacía, no hacemos nada
            }

            // Caso 1: El nodo a eliminar es el primero
            if (Primero.Fecha == fecha)
            {
                Primero = Primero.Siguiente; // El primer nodo ahora es el siguiente

                // Si la lista se vacía, actualizamos también Ultimo
                if (Primero == null)
                {
                    Ultimo = null;
                }
                return true;
            }

            // Caso 2: El nodo a eliminar está en otra posición
            Nodo actual = Primero;
            Nodo anterior = null;

            // Recorremos buscando el nodo a eliminar
            while (actual != null && actual.Fecha != fecha)
            {
                anterior = actual;
                actual = actual.Siguiente;
            }

            // Si encontramos el nodo
            if (actual != null)
            {
                anterior.Siguiente = actual.Siguiente; // Saltamos el nodo a eliminar

                // Si el nodo eliminado era el último, actualizamos Ultimo
                if (actual == Ultimo)
                {
                    Ultimo = anterior;
                }
                return true;
            }

            Console.WriteLine("El nodo con la fecha especificada no se encontró.");
            return false;
        }




        //------------------------------------------------------------------------

        // Método que devuelva el número de nodos en la lista.

        public int ContarElementos()
        {
            int contador = 0;
            Nodo auxiliar = Primero;

            while (auxiliar != null)
            {
                contador++;
                auxiliar = auxiliar.Siguiente;
            }

            return contador;
        }

        // Método para vaciar la lista.

        public void VaciarLista()
        {
            Primero = null;
            Ultimo = null;
        }

        //Obtener el ultimo nodo
        public Nodo ObtenerUltimo()
        {
            return Ultimo;
        }

        //Actualizar nodo a partir de otro procedimiento.
        public bool Actualizar(DateTime fecha, int nuevaCuenta, float nuevoImporte)
        {
            Nodo nodoAActualizar = Buscar(fecha);

            if (nodoAActualizar != null)
            {
                nodoAActualizar.Cuenta = nuevaCuenta;
                nodoAActualizar.Importe = nuevoImporte;
                return true;
            }

            return false;
        }

        //Invertir lista de nodos
        public void InvertirLista()
        {
            Nodo anterior = null;
            Nodo actual = Primero;
            Nodo siguiente = null;
            Ultimo = Primero;

            while (actual != null)
            {
                siguiente = actual.Siguiente;
                actual.Siguiente = anterior;
                anterior = actual;
                actual = siguiente;
            }

            Primero = anterior;
        }

        //Eliminar el ultimo
        public bool EliminarUltimo()
        {
            if (Primero == null) // Lista vacía
            {
                return false;
            }

            if (Primero == Ultimo) // Solo hay un nodo
            {
                Primero = null;
                Ultimo = null;
                return true;
            }

            Nodo actual = Primero;
            while (actual.Siguiente != Ultimo) // Recorremos hasta el penúltimo nodo
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = null; // Eliminamos la referencia al último nodo
            Ultimo = actual; // Actualizamos el último nodo
            return true;
        }

        // Método para insertar un nodo en la lista de manera ordenada SEGUN Importe del mas chico al mas grande.
        public void InsertarPorImporte(Nodo nuevo)
        {
            if (EstaVacia()) // Si la lista está vacía, creamos el nodo
            {
                Primero = nuevo;
                Ultimo = nuevo;
            }
            else
            {
                // Caso 1: El nuevo nodo tiene que ir al principio
                if (nuevo.Importe < Primero.Importe)
                {
                    nuevo.Siguiente = Primero; // El nuevo apunta al actual primero
                    Primero = nuevo; // El nuevo nodo se convierte en el primero
                }
                // Caso 2: El nuevo nodo tiene que ir al final
                else if (nuevo.Importe > Ultimo.Importe)
                {
                    Ultimo.Siguiente = nuevo; // El último apunta al nuevo nodo
                    Ultimo = nuevo; // El nuevo nodo se convierte en el último
                }
                // Caso 3: El nuevo nodo va en el medio
                else
                {
                    Nodo anterior = null;
                    Nodo auxiliar = Primero;

                    // Recorremos hasta encontrar la posición correcta
                    while (auxiliar != null && nuevo.Importe > auxiliar.Importe)
                    {
                        anterior = auxiliar; // Guardamos el nodo anterior
                        auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo
                    }

                    anterior.Siguiente = nuevo; // Enlazamos el nodo anterior al nuevo
                    nuevo.Siguiente = auxiliar; // El nuevo nodo apunta al auxiliar
                }
            }
        }

    }
}
