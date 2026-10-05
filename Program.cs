using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Título()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Sistema de Gestión de notas");
            Console.WriteLine("********************");
        }
        static public void Registrar_Estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo");
            if (contador >= 100)
            {
                Console.WriteLine("Alcanzó la capacidad máxima");
                return;
            }
            Console.WriteLine("Ingresar nombre del estudiante:");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota[0-20]:");
                nota = double.Parse(Console.ReadLine());
                {
                    break;
                }
                Console.WriteLine("Error, volver a ingresar la nota [0-20]");
            }

            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Registro con éxito.............!!!");
        }
        static public void buscar_estudiante()
        {
            Console.WriteLine("*************BUSCAR ESTUDIANTE*******");
            if (contador==0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("Ingresar nombre a buscar:");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++) 
            {
                if (nombres[i].ToLower() == nom_buscar) 
                {
                    Console.WriteLine("Estudiante encontrado:");
                    Console.WriteLine(nombres[i] + "tiene" + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado.......");
        }
        static public void Modificar_nota()
        {
            Console.WriteLine("********MODIFICAR NOTA*********");
            if (contador==0)
            {
                Console.WriteLine("No hay estudiante registrado");
                return;
            }
            Console.WriteLine("Ingresar nombre del estudiante:");
            string nom_buscar = Console.ReadLine().ToLower();
            for(int i=0;i<contador;i++)
            {
                if (nombres[i].ToLower() == nom_buscar) 
                {
                    Console.WriteLine(nombres[i] + "tiene" + notas[i]);
                    double nueva_nota;
                    while(true)
                    {
                        Console.WriteLine("Ingresar la nueva nota");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if(nueva_nota>=0 && nueva_nota<=20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada correctamente");
                            return;
                        }
                        Console.WriteLine("Nota fuera de rango[0-20]");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado......");
        }
        static public void Mostrar()
        {
            Console.WriteLine("*********LISTADO ORIGINAL*******");
            if (contador==0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("\tNOMBRE \t\tNOTAS");
            for (int i = 0; i < contador; i++)
           
            {
                Console.WriteLine("\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }
        static public void Burbuja()
        {
            Console.WriteLine("***************ORDENAMIENTO ASCENDENTE (BURBUJA)**********");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;

                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
            Mostrar();
        }

        static public void Seleccion_DESC()
        {
            Console.WriteLine("***************ORDENAMIENTO DESCENDENTE (SELECCIÓN)**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
 
            for (int i = 0; i < contador - 1; i++)
            {
                int maximo = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[maximo])
                    {
                        maximo = j;
                    }
                }
                if (maximo != i)
                {
                    double temp_nota = notas[i];
                    notas[i] = notas[maximo];
                    notas[maximo] = temp_nota;
 
                    string temp_nombre = nombres[i];
                    nombres[i] = nombres[maximo];
                    nombres[maximo] = temp_nombre;
                }
            }
            Mostrar();
        }
        static public void nota_max_prom()
        {
            {
                Console.WriteLine("*******NOTA MÁXIMA Y PROMEDIO*******");
                if (contador == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                    return;
                }

                double notaMaxima = notas[0];
                int idxMax = 0;
                double suma = 0;

                for (int i = 0; i < contador; i++)
                {
                    suma += notas[i];
                    if (notas[i] > notaMaxima)
                    {
                        notaMaxima = notas[i];
                        idxMax = i;
                    }
                }
                double promedio = suma / contador;
                Console.WriteLine("Nota máxima: " + notaMaxima + " (Estudiante: " + nombres[idxMax] + ")");
                Console.WriteLine("Promedio general: " + promedio.ToString("F2"));
            }
        }
        static void Main(string[] args)

        {
            Título();

            int opc = 0;
            while (opc != 8)
            {

                Console.WriteLine("*****************************");
                Console.WriteLine(" MENU PRINCIPAL ");
                Console.WriteLine("*****************************");
                Console.WriteLine("[1] Registrar Estudiante");
                Console.WriteLine("[2] Buscar Estudiante");
                Console.WriteLine("[3] Modificar Nota");
                Console.WriteLine("[4] Mostrar lista sin ordenar");
                Console.WriteLine("[5] Ordenar con burbuja");
                Console.WriteLine("[6] Ordenar con selección (descendente)");
                Console.WriteLine("[7] Nota máxima y promedio");
                Console.WriteLine("[8] Salir");
                Console.WriteLine("Ingresar Opcion: ");
                bool esValido = int.TryParse(Console.ReadLine(), out opc);
                if (!esValido)
                {
                    Console.WriteLine("Por favor ingresá un número válido.");
                    continue; 
                }
                switch (opc)
                {
                    case 1:
                        Registrar_Estudiante();

                        break;

                    case 2:

                        buscar_estudiante();

                        break;

                    case 3:

                        Modificar_nota();

                        break;

                    case 4:

                        Mostrar();

                        break;

                    case 5:

                        Burbuja();

                        break;

                    case 6:
                        Seleccion_DESC();
                        break;
                    case 7:
                        nota_max_prom();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el Sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
