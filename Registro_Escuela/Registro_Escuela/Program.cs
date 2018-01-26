﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu men_U = new Menu();
        }
    }

    class Menu
    {
        Registro_Estudiante Registro = new Registro_Estudiante();
        int Seleccion = 0;

        public Menu()
        {
            do
            {
                Console.Title = "Registro de la escuela";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1- Registrar Estudiante.\r\n2- Modificar informacion de estudiante.\r\n3- Consulta informacion de estudiante.\r\n4- Registrar Calificaciones de estudiantes.\r\n5- Consultar Calificaciones de estudiante.\r\n0- Para Salir.");
                do
                {
                    if(Seleccion != 1 && Seleccion != 2 && Seleccion != 3 && Seleccion != 4 && Seleccion != 5 && Seleccion != 0)
                    {
                        Console.Write("Opcion no valida, vuelva a introducir otra opcion: ");
                    }

                    Seleccion = int.Parse(Console.ReadLine());

                } while (Seleccion != 1 && Seleccion != 2 && Seleccion != 3 && Seleccion != 4 && Seleccion != 5 && Seleccion != 0);

                switch (Seleccion)
                {
                    case 1:
                        Registro.Registrar_Estudiante();
                        break;
                    case 2:
                        Registro.Editar_Estudiante();
                        break;
                    case 3:
                        Registro.Consultar_Estudiante();
                        break;
                    case 4:
                        Registro.Registrar_Calificaciones();
                        break;
                    case 5:
                        Registro.Consultar_Notas();
                        break;
                }

            } while (Seleccion != 0);
        }
    }

    class Registro_Estudiante
    {
        List<Estudiante> Lista_Estudiante = new List<Estudiante>();
        Estudiante _estudiante = null;

        List<Materias> Lista_Materias = new List<Materias>();
        Materias materias_ = null;

        public void Registrar_Estudiante()
        {
            _estudiante = new Estudiante();
            materias_ = new Materias();

            string Respuesta = "SI";
            do
            {
                Console.Title = "Registro De Nuevo Estudiante";
                Console.Clear();
                Console.Write("Nombre estudiante: ");
                _estudiante.Nombre = Console.ReadLine().ToUpper();
                Console.Write("Apellido del estudiante: ");
                _estudiante.Apellido = Console.ReadLine().ToUpper();
                Console.Write("Edad del estudiante: ");
                _estudiante.Edad = Console.ReadLine().ToUpper();
                _estudiante.Matricula = _estudiante.Nombre[0].ToString() + _estudiante.Apellido[0].ToString()+ _estudiante.Edad;
                Console.WriteLine("Matricula del estudiante: {0}", _estudiante.Matricula);

                materias_.Matricula += _estudiante.Matricula;
                materias_.Español = "0";
                materias_.Matematicas = "0";
                materias_.Fisica = "0";
                materias_.Quimica = "0";
                materias_.Promedio = "0";

                Console.Write("Grado que va cursando el estudiante: ");
                _estudiante.Grado = Console.ReadLine().ToUpper();
                _estudiante.Estado = "N/D";
                Console.Clear();

                Lista_Estudiante.Add(_estudiante);
                Lista_Materias.Add(materias_);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Estudiante Registrado Satisfactoriamente.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ReadKey();
                Console.WriteLine("Desea Registrar otro estudiante? SI/NO");
                Respuesta = Console.ReadLine().ToUpper();

                while(Respuesta !="SI" && Respuesta != "NO")
                {
                    Console.WriteLine("Solo puede responder: SI o NO");
                    Respuesta = Console.ReadLine().ToUpper();
                }

                Console.Clear();
            } while (Respuesta != "NO");
        }
        public void Editar_Estudiante()
        {
            Console.Clear();
            Console.Title = "Modificar Informacion De Estudiante";

            string nombre = string.Empty;

            Console.Write("\n");
            if(Lista_Estudiante.Count > 0)
            {
                Console.Write("Digite el nombre del estudiante: ");
                nombre = Console.ReadLine().ToUpper();

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
                    if (Lista_Estudiante[x].Nombre == nombre)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Datos del estudiante que se van a modificar.");
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                        Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                        Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                        Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);

                        if (Convert.ToDouble(Lista_Materias[x].Promedio) >= 70)
                        {
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        }
                        else
                            if (Convert.ToDouble(Lista_Materias[x].Promedio) <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");

                        Console.WriteLine("Ingrese datos actualizados.");
                        Console.Write("Nombre estudiante: ");
                        Lista_Estudiante[x].Nombre = Console.ReadLine().ToUpper();
                        Console.Write("Apellido del estudiante: ");
                        Lista_Estudiante[x].Apellido = Console.ReadLine().ToUpper();
                        Console.Write("Edad del estudiante: ");
                        Lista_Estudiante[x].Edad = Console.ReadLine().ToUpper();
                        Console.Write("Matricula del estudiante: ");
                        Lista_Estudiante[x].Matricula = Console.ReadLine().ToUpper();
                        Console.Write("Grado que va cursando el estudiante: ");
                        Lista_Estudiante[x].Grado = Console.ReadLine().ToUpper();

                        Lista_Materias[x].Matricula += Lista_Estudiante[x].Matricula;
                        Lista_Materias[x].Español = "0";
                        Lista_Materias[x].Matematicas = "0"; 
                        Lista_Materias[x].Fisica = "0";
                        Lista_Materias[x].Quimica = "0";
                        Lista_Materias[x].Promedio = "0";

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Datos modificados satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Consultar_Estudiante()
        {
            Console.Clear();
            Console.Title = "Busqueda De Estudiante Registrado";

            string nombre = string.Empty;

            Console.Write("\n");

            if (Lista_Estudiante.Count > 0)
            {
                Console.Write("Nombre del estudiante: ");
                nombre = Console.ReadLine().ToUpper();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
                    ex++;
                    if (Lista_Estudiante[x].Nombre != nombre && ex == Lista_Estudiante.Count && encontrado != true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se encontro ningun estudiante registrado con ese nombre.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                    }

                    if (Lista_Estudiante[x].Nombre == nombre)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                        Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                        Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                        Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);

                        if (Convert.ToDouble(Lista_Materias[x].Promedio) >= 70)
                        {
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        }
                        else
                            if (Convert.ToDouble(Lista_Materias[x].Promedio) <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                        Console.ReadKey();
                        encontrado = true;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Registrar_Calificaciones()
        {
            Console.Clear();
            Console.Title = "Registro De Calificaciones";

            string matricula_ = string.Empty;
            Console.Write("\n");

            if (Lista_Materias.Count > 0)
            {
                Console.WriteLine("Digite la matricula del estudiante:");
                matricula_ = Console.ReadLine().ToUpper();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    ex++;
                    if (Lista_Materias[x].Matricula == matricula_)
                    {
                        if(Lista_Materias[x].Matricula != matricula_ && ex == Lista_Materias.Count && encontrado != true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("MATRICULA NO ENCONTRADA: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.ReadKey();
                        }

                        Console.Clear();
                        Console.WriteLine("Matricula del Estudiante: {0}", Lista_Materias[x].Matricula);
                        Console.Write("Digite la calificacion de Español: ");

                        do
                        {
                            if(Convert.ToDouble(Lista_Materias[x].Español) >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Calificacion no valida, la calificacion no puede ser mayor a 100: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }

                            Lista_Materias[x].Español = Console.ReadLine();
                        }while (Convert.ToDouble(Lista_Materias[x].Español) >= 101);
                        
                        Console.Write("Digite la calificacion de Matematicas: ");

                        do
                        {
                            if (Convert.ToDouble(Lista_Materias[x].Matematicas) >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Calificacion no valida, la calificacion no puede ser mayor a 100: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }

                            Lista_Materias[x].Matematicas = Console.ReadLine();
                        } while (Convert.ToDouble(Lista_Materias[x].Matematicas) >= 101);

                        Console.Write("Digite la calificacion de Fisica: ");

                        do
                        {
                            if (Convert.ToDouble(Lista_Materias[x].Fisica) >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Calificacion no valida, la calificacion no puede ser mayor a 100: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }

                            Lista_Materias[x].Fisica = Console.ReadLine();
                        } while (Convert.ToDouble(Lista_Materias[x].Fisica) >= 101);
                        
                        Console.Write("Digite la calificacion de Quimica: ");

                        do
                        {
                            if (Convert.ToDouble(Lista_Materias[x].Quimica) >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Calificacion no valida, la calificacion no puede ser mayor a 100: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }

                            Lista_Materias[x].Quimica = Console.ReadLine();
                        } while (Convert.ToDouble(Lista_Materias[x].Quimica) >= 101);

                        Lista_Materias[x].Promedio = Convert.ToString(materias_.Promediar(Convert.ToDouble(Lista_Materias[x].Español), Convert.ToDouble(Lista_Materias[x].Matematicas), Convert.ToDouble(Lista_Materias[x].Fisica), Convert.ToDouble(Lista_Materias[x].Quimica)));

                        if (Convert.ToDouble(Lista_Materias[x].Promedio) >= 70)
                        {
                            Lista_Estudiante[x].Estado = "APROBADO";
                        }
                        else
                            if (Convert.ToDouble(Lista_Materias[x].Promedio) <= 69)
                        {
                            Lista_Estudiante[x].Estado = "REPROBADO";
                        }

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calificaciones Registradas Satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Consultar_Notas()
        {
            Console.Clear();
            Console.Title = "Consulta de Notas";

            string matricula = string.Empty;

            Console.Write("\n");

            if (Lista_Materias.Count > 0)
            {
                Console.Write("Digite la matricula: ");
                matricula = Console.ReadLine().ToUpper();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    ex++;
                    if (Lista_Materias[x].Matricula != matricula && ex == Lista_Materias.Count && encontrado != true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se encontro ningun estudiante registrado con ese nombre.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                    }

                    if (Lista_Materias[x].Matricula == matricula)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Calificaciones.");
                        Console.WriteLine("Matricula del Estudiante : {0}", Lista_Materias[x].Matricula);
                        Console.WriteLine("Nombre Completo          : {0} {1}", Lista_Estudiante[x].Nombre, Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Nota Español             : {0}", Lista_Materias[x].Español);
                        Console.WriteLine("Nota de Matematicas      : {0}", Lista_Materias[x].Matematicas);
                        Console.WriteLine("Nota de Fisica           : {0}", Lista_Materias[x].Fisica);
                        Console.WriteLine("Nota de Quimica          : {0}", Lista_Materias[x].Quimica);
                        Console.WriteLine("Promedio                 : {0}", Lista_Materias[x].Promedio);

                        if (Convert.ToDouble(Lista_Materias[x].Promedio) >= 70 )
                        {
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        }
                        else
                            if( Convert.ToDouble(Lista_Materias[x].Promedio) <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                        encontrado = true;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
    }

    class Estudiante
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Edad { set; get; }
        public string Matricula { set; get; }
        public string Grado { set; get; }
        public string Estado { set; get; }
    }

    class Materias
    {
        public string Matricula { set; get; }
        public string Español { set; get; }
        public string Matematicas { set; get; }
        public string Fisica { set; get; }
        public string Quimica { set; get; }
        public string Promedio { set; get; }

        public double Promediar(double Español, double Matematicas, double Fisica, double Quimica)
        {
            double _promedio = (Español + Matematicas + Fisica + Quimica) / 4;

            return _promedio;
        }
    }
}