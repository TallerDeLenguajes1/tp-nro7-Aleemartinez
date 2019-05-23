using System;
using System.Collections.Generic;
using System.Text;

namespace tp7
{
    public struct Personal
    {
        public string nombre;
        public string apellido;
        public DateTime fechadenac;
        public string estadocivil;
        public string genero;
        public DateTime fechaing;
        public float basico;
        public string cargo;
        public int id;

        public enum Estc
        {
            Soltero, Casado
        }
        public enum Gen
        {
            Masculino, Femenino
        }
        public enum Cargo
        {
            Auxiliar, Administracion, Ingeniero, Especialista, Investigador
        }
        public enum Nombres
        {
            Santino, Alejandro, Bautista, Raul, Tiziano, Tatiana, Nancy, Brisa, Ema, Luz
        }
        public enum Apellidos
        {
            Perez, Martinez, Sanchez, Sosa, Valdez, Rojas, Alderetes, Carrizo, Fernandez, Roriguez
        }


        public Personal llenar(int id)
        {
            int dia, mes, año, añoing;
            string nombre, apellido, genero, estado, cargo;
            Random numrdm = new Random();
            Personal estructura = new Personal();
            apellido = Convert.ToString((Apellidos)numrdm.Next(10));
            estado = Convert.ToString((Estc)numrdm.Next(2));
            cargo = Convert.ToString((Cargo)numrdm.Next(5));
            genero = Convert.ToString((Gen)numrdm.Next(2));
            if (genero == "Masculino")
            {
                nombre = Convert.ToString((Nombres)numrdm.Next(5));
            }
            else
            {
                nombre = Convert.ToString((Nombres)numrdm.Next(5, 10));
            }
            if (genero == "Masculino")
            {
                año = numrdm.Next(1955, 1994);
            }
            else
            {
                año = numrdm.Next(1960, 1994);
                estado = estado.Replace("ro", "ra");
                estado = estado.Replace("do", "da");
                cargo = cargo.Replace("ro", "ra");
            }
            mes = numrdm.Next(1, 13);
            if (mes == 2)
            {
                dia = numrdm.Next(1, 29);
            }
            else if (año % 4 == 0 && año % 100 != 0 && año % 400 == 0 && mes == 2)
            {
                dia = numrdm.Next(1, 30);
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                dia = numrdm.Next(1, 31);
            }
            else
            {
                dia = numrdm.Next(1, 32);
            }

            añoing = numrdm.Next(1975, 2019);
            estructura.nombre = nombre;
            estructura.apellido = apellido;
            estructura.cargo = cargo;
            estructura.fechadenac = new DateTime(año, mes, dia);
            estructura.estadocivil = estado;
            estructura.genero = genero;

            estructura.fechaing = new DateTime(año, mes, dia);
            estructura.basico = 15000;
            estructura.id = id;

            return estructura;
        }

        public float salario(Personal usuario)
        {
            float salario;
            float adicion;
            int antiguedad, hijos = 0;

            DateTime hoy = DateTime.Today;
            antiguedad = hoy.Year - usuario.fechaing.Year;
            if (usuario.estadocivil == "Casado")
            {
                Random a = new Random();
                hijos = a.Next(5);
            }



            adicion = adicional(usuario.basico, antiguedad, usuario.cargo, hijos);
            salario = usuario.basico + adicion;
            return salario;
        }

        public float adicional(float basico, int antiguedad, string cargo, int canthijos)
        {
            float adicion;

            if (antiguedad > 20)
            {
                adicion = basico * 0.25F;
            }
            else
            {
                adicion = (basico * 0.2F) * antiguedad;
            }
            if (cargo == "Ingeniero" || cargo == "Especialista")
            {
                adicion = adicion * 1.5F;
            }
            if (canthijos > 2)
            {
                adicion = adicion + 5000;
            }


            return adicion;
        }
    }
}
