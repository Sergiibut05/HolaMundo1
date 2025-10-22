using System;
using System.Globalization;

namespace HolaMundo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Menu de ejercicios ===");
                Console.WriteLine("1) Suma y media de un array");
                Console.WriteLine("2) Contar espacios en una cadena");
                Console.WriteLine("3) Factorial (recursivo)");
                Console.WriteLine("4) Comprobar numero primo");
                Console.WriteLine("5) Potencia (iterativa y recursiva, sin Math)");
                Console.WriteLine("6) Login con 3 intentos");
                Console.WriteLine("7) Multiplo entre dos numeros");
                Console.WriteLine("8) Suma de digitos de un numero");
                Console.WriteLine("9) Posicion del menor en un array");
                Console.WriteLine("10) Simulacion de Banco y Clientes");
                Console.WriteLine("0) Salir");
                int opcion = ReadInt("Selecciona ejercicio: ");

                if (opcion == 0)
                {
                    Console.WriteLine("Adios!");
                    break;
                }

                Console.WriteLine();
                switch (opcion)
                {
                    case 1:
                        EjecutarEjercicio1();
                        break;
                    case 2:
                        EjecutarEjercicio2();
                        break;
                    case 3:
                        EjecutarEjercicio3();
                        break;
                    case 4:
                        EjecutarEjercicio4();
                        break;
                    case 5:
                        EjecutarEjercicio5();
                        break;
                    case 6:
                        EjecutarEjercicio6();
                        break;
                    case 7:
                        EjecutarEjercicio7();
                        break;
                    case 8:
                        EjecutarEjercicio8();
                        break;
                    case 9:
                        EjecutarEjercicio9();
                        break;
                    case 10:
                        EjecutarEjercicio10();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Introduce un numero entero valido.");
            }
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                // Intento con cultura actual y luego invariante
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out double v) ||
                    double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out v))
                {
                    return v;
                }
                Console.WriteLine("Introduce un numero (usa coma o punto para decimales).");
            }
        }

        private static string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        // Ejercicio 1
        private static void EjecutarEjercicio1()
        {
            int tam = ReadInt("Tamaño del array: ");
            if (tam <= 0)
            {
                Console.WriteLine("El tamaño debe ser positivo.");
                return;
            }
            int[] numeros = new int[tam];
            long suma = 0;
            for (int i = 0; i < tam; i++)
            {
                numeros[i] = ReadInt($"Valor [{i}]: ");
                suma = suma + numeros[i];
            }
            double media = (double)suma / tam;
            Console.WriteLine($"Suma: {suma}");
            Console.WriteLine($"Media: {media}");
        }

        // Ejercicio 2
        private static void EjecutarEjercicio2()
        {
            string texto = ReadText("Introduce una cadena: ");
            int contador = 0;
            foreach (char c in texto)
            {
                if (c == ' ')
                {
                    contador++;
                }
            }
            Console.WriteLine($"Numero de espacios: {contador}");
            contador = 0;
        }

        // Ejercicio 3
        private static void EjecutarEjercicio3()
        {
            int n = ReadInt("Numero para factorial: ");
            if (n < 0)
            {
                Console.WriteLine("El factorial no esta definido para negativos.");
                return;
            }
            long resultado = FactorialRecursivo(n);
            Console.WriteLine($"{n}! = {resultado}");
        }

        private static long FactorialRecursivo(long n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * FactorialRecursivo(n - 1);
        }

        // Ejercicio 4
        private static void EjecutarEjercicio4()
        {
            int n = ReadInt("Numero: ");
            bool primo = EsPrimo(n);
            Console.WriteLine(primo ? "Es primo" : "No es primo");
        }

        private static bool EsPrimo(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; (long)i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Ejercicio 5
        private static void EjecutarEjercicio5()
        {
            double baseNum = ReadDouble("Base: ");
            int exponente = ReadInt("Exponente (entero): ");
            double it = PotenciaIterativa(baseNum, exponente);
            double rec = PotenciaRecursiva(baseNum, exponente);
            Console.WriteLine($"Iterativa: {it}");
            Console.WriteLine($"Recursiva: {rec}");
        }

        private static double PotenciaIterativa(double baseNum, int exponente)
        {
            if (exponente == 0)
            {
                return 1.0;
            }
            bool negativo = exponente < 0;
            int exp = negativo ? -exponente : exponente;
            double resultado = 1.0;
            for (int i = 0; i < exp; i++)
            {
                resultado *= baseNum;
            }
            return negativo ? 1.0 / resultado : resultado;
        }

        private static double PotenciaRecursiva(double baseNum, int exponente)
        {
            if (exponente == 0)
            {
                return 1.0;
            }
            if (exponente > 0)
            {
                return baseNum * PotenciaRecursiva(baseNum, exponente - 1);
            }
            return 1.0 / PotenciaRecursiva(baseNum, -exponente);
        }

        // Ejercicio 6
        private static void EjecutarEjercicio6()
        {
            int intentos = 3;
            bool ok = false;
            while (intentos > 0 && !ok)
            {
                string usuario = ReadText("Usuario: ");
                string contrasena = ReadText("Contrasena: ");
                ok = LoginValido(usuario, contrasena);
                if (!ok)
                {
                    intentos--;
                    Console.WriteLine($"Credenciales incorrectas. Intentos restantes: {intentos}");
                }
            }
            Console.WriteLine(ok ? "Acceso concedido" : "Acceso denegado");
        }

        private static bool LoginValido(string usuario, string contrasena)
        {
            return usuario == "usuario2DAM" && contrasena == "pass2DAM";
        }

        // Ejercicio 7
        private static void EjecutarEjercicio7()
        {
            int a = ReadInt("Primer numero: ");
            int b = ReadInt("Segundo numero: ");

            bool aMultiploDeB = EsMultiplo(a, b);
            bool bMultiploDeA = EsMultiplo(b, a);

            if (aMultiploDeB)
            {
                Console.WriteLine($"{a} es multiplo de {b}");
            }
            if (bMultiploDeA)
            {
                Console.WriteLine($"{b} es multiplo de {a}");
            }
            if (!aMultiploDeB && !bMultiploDeA)
            {
                Console.WriteLine("Ninguno es multiplo del otro");
            }
        }

        private static bool EsMultiplo(int primero, int segundo)
        {
            if (segundo == 0)
            {
                return false;
            }
            return primero % segundo == 0;
        }

        // Ejercicio 8
        private static void EjecutarEjercicio8()
        {
            int n = ReadInt("Numero: ");
            int suma = SumaDigitos(n);
            Console.WriteLine($"Suma de digitos: {suma}");
        }

        private static int SumaDigitos(int n)
        {
            int x = n < 0 ? -n : n;
            int suma = 0;
            if (x == 0)
            {
                return 0;
            }
            while (x > 0)
            {
                suma += x % 10;
                x /= 10;
            }
            return suma;
        }

        // Ejercicio 9
        private static void EjecutarEjercicio9()
        {
            int[] datos = new int[] { 5, 3, 8, -2, 7, 0 };
            int pos = PosicionNumeroMenor(datos);
            if (pos >= 0)
            {
                Console.WriteLine($"Posicion del menor: {pos} (valor {datos[pos]})");
            }
            else
            {
                Console.WriteLine("Array vacio");
            }
        }

        private static int PosicionNumeroMenor(int[] array)
        {
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        // Ejercicio 10
        private static void EjecutarEjercicio10()
        {
            Banco banco = new Banco();
            banco.Operar();
            banco.ObtenerEstado();
        }
    }

    // Clases del ejercicio 10
    internal class Cliente
    {
        private readonly string nombre;
        private double cantidadTotal;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
            this.cantidadTotal = 0.0;
        }

        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                cantidadTotal += cantidad;
            }
        }

        public bool Sacar(double cantidad)
        {
            if (cantidad <= 0 || cantidad > cantidadTotal)
            {
                return false;
            }
            cantidadTotal -= cantidad;
            return true;
        }

        public double GetCantidadTotal()
        {
            return cantidadTotal;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Cliente {nombre}: {cantidadTotal}");
        }
    }

    internal class Banco
    {
        private  Cliente cliente1;
        private  Cliente cliente2;
        private  Cliente cliente3;

        public Banco()
        {
            cliente1 = new Cliente("Ana");
            cliente2 = new Cliente("Luis");
            cliente3 = new Cliente("Marta");
        }

        public void Operar()
        {
            cliente1.Ingresar(150.0);
            cliente2.Ingresar(275.5);
            cliente3.Ingresar(80.0);
        }

        public void ObtenerEstado()
        {
            double total = cliente1.GetCantidadTotal() + cliente2.GetCantidadTotal() + cliente3.GetCantidadTotal();
            Console.WriteLine($"Total ingresado en el banco: {total}");
            cliente1.MostrarInformacion();
            cliente2.MostrarInformacion();
            cliente3.MostrarInformacion();
        }
    }
}
