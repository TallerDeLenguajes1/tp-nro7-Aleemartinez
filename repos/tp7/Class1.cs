using System;

namespace tp7
{
    class Nodo
    {
        public Personal datos;
        public Nodo sig;


        private Nodo inicio, final;

        public Nodo()
        {
            inicio = null;
            final = null;
        }
        public bool Vacia()
        {
            if (inicio == null)
                return true;
            else
                return false;
        }


        public void Insertar(Personal mipesonal)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.datos = mipesonal;
            nuevo.sig = null;
            if (Vacia())
            {
                inicio = nuevo;
                final = nuevo;
            }
            else
            {
                final.sig = nuevo;
                final = nuevo;
            }
        }
        public Personal Extraer(int id)
        {
            Nodo empleado = inicio;
            Nodo ultimo = final;
            if (final.datos.id >= id && empleado.datos.id <= id)
            {
                while (empleado.datos.id != id)
                {
                    empleado = empleado.sig;
                }
                return empleado.datos;
            }
            else
            {
                Console.WriteLine("\nID no encontrado verifique e ingrese nuevamente");
                id = int.Parse(Console.ReadLine());
                return Extraer(id);
                
            }
        }
        public void Imprimiruno(Personal empleado)
        {
            int edad, añosjubilacion;
            DateTime hoy = DateTime.Today;
                edad = hoy.Year - empleado.fechadenac.Year;
                Console.WriteLine("Nombre: " + empleado.nombre);
                Console.WriteLine("Apellido: " + empleado.apellido);
                Console.WriteLine("Estado Civil: " + empleado.estadocivil);
                Console.WriteLine("Cargo: " + empleado.cargo);
                Console.WriteLine("Edad: {0} años", edad);
                Console.WriteLine("Salario: " + empleado.salario(empleado));
                Console.Write("Años Para Jubilarse: ");
                if (empleado.genero == "Masculino")
                {
                    añosjubilacion = 65 - edad;
                }
                else
                {
                    añosjubilacion = 60 - edad;
                }
            Console.Write(añosjubilacion);
                Console.WriteLine("\n");

        }
        public void Imprimir()
        {
            Nodo reco = inicio;
            int edad, contador = 0, añosjubilacion;
            float salariototal = 0;
            DateTime hoy = DateTime.Today;
            while (reco != null)
            {

                edad = hoy.Year - reco.datos.fechadenac.Year;
                Console.WriteLine("ID: " + reco.datos.id);
                Console.WriteLine("Nombre: " + reco.datos.nombre);
                Console.WriteLine("Apellido: " + reco.datos.apellido);
                Console.WriteLine("Estado Civil: " + reco.datos.estadocivil);
                Console.WriteLine("Cargo: " + reco.datos.cargo);
                Console.WriteLine("Edad: {0} años", edad);
                Console.WriteLine("Salario: " + reco.datos.salario(reco.datos));
                Console.Write("Años Para Jubilarse: ");
                if (reco.datos.genero == "Masculino")
                {
                    añosjubilacion = 65 - edad;
                }
                else
                {
                    añosjubilacion = 60 - edad;
                }
                Console.Write(añosjubilacion);

                salariototal += reco.datos.salario(reco.datos);
                contador++;
                Console.WriteLine("\n");

                reco = reco.sig;
            }

            Console.WriteLine("\nSalario Total: " + salariototal + "; En un total de " + contador + " empleados");

        }



    }
}
