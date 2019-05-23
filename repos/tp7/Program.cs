using System;

namespace tp7
{
    class Program
    {

        static void Main(string[] args)
        {
            int cant;
            Nodo usuario = new Nodo();
            Personal gente = new Personal();
            Console.WriteLine("¿Cuantos empleados desea cargar?");
            cant = int.Parse(Console.ReadLine());
            for (int i = 1; i <= cant; i++)
            {
                gente = gente.llenar(id: i);
                usuario.Insertar(gente);
            }
            usuario.Imprimir();
            Console.WriteLine("\nElija usuario en especifico para mostrar");
            cant = int.Parse(Console.ReadLine());
            usuario.Imprimiruno(usuario.Extraer(cant));
        }
    }
}
