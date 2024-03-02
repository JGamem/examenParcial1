byte option = 0;

do
{
    if (option < 1 || option > 4)
    {
        MostrarMenu();
    }

    if (byte.TryParse(Console.ReadLine(), out option))
    {
        switch (option)
        {
            case 1:
                Console.WriteLine();
                Ejercicio1();
                break;
            case 2:
                Ejercicio2();
                break;
            case 3:
                Ejercicio3();
                break;
            case 4:
                Ejercicio4();
                break;
            case 5:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saliendo del programa...");
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, ingrese una opción válida");
                Console.WriteLine();
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Por favor, ingrese un número válido");
        Console.WriteLine();
    }
} while (option != 5);


static void MostrarMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Escoge el ejercicio que deseas ejecutar");
    Console.WriteLine("1. Ejercicio I");
    Console.WriteLine("2. Ejercicio II");
    Console.WriteLine("3. Ejercicio III");
    Console.WriteLine("4. Ejercicio IV");
    Console.WriteLine("5. Salir\n");
    Console.WriteLine("Ingrese una opción");
}

static void Ejercicio1()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Ingresa un número entero positivo: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (num <= 0)
        {
            throw new FormatException("El número debe ser positivo");
        }

        Console.WriteLine($"Factorial de {num}: {Factorial(num)}");
        Console.WriteLine($"Raíz cuadrada de {num}: {Math.Round(Math.Sqrt(num),2)}");
    }
    catch (FormatException)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: Por favor, ingrese solo números enteros positivos");
    }
    catch (OverflowException)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: El número ingresado es demasiado grande");
    }

    Console.WriteLine();
    Console.WriteLine("Presiona cualquier tecla para continuar...");
    Console.ReadKey();
}

static int Factorial(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}

static void Ejercicio2()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Ingrese el primer número:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo número:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el operador (+, -, *, /):");
        char op = Convert.ToChar(Console.ReadLine());

        double resultado = 0;

        switch (op)
        {
            case '+':
                resultado = num1 + num2;
                break;
            case '-':
                resultado = num1 - num2;
                break;
            case '*':
                resultado = num1 * num2;
                break;
            case '/':
                if (num2 == 0)
                {
                    throw new DivideByZeroException("No se puede dividir por cero");
                }
                resultado = (double)num1 / num2;
                break;
            default:
                throw new FormatException("Operador inválido");
        }

        Console.WriteLine($"El resultado de la operación es: {resultado}");
    }
    catch (FormatException)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: Por favor, ingrese números enteros y un operador válido");
    }
    catch (OverflowException)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: Los números ingresados son demasiado grandes");
    }
    catch (DivideByZeroException e)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {e.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presiona cualquier tecla para continuar...");
    Console.ReadKey();
}

static void Ejercicio3()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Ingrese un número para ver su tabla de multiplicar:");
        int num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Ingrese solo números enteros.");
    }

    Console.WriteLine("Presione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void Ejercicio4()
{
    Random random = new Random();
    int numeroSecreto = random.Next(1, 101);
    int intentos = 0;
    int intentoUsuario;

    Console.Clear();
    Console.WriteLine("Adivina el numero secreto");
    Console.WriteLine("Estoy pensando en un numero entre 1 y 100. Adivina cuál es.");

    do
    {
        Console.Write("Introduce tu suposición: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out intentoUsuario))
        {
            Console.WriteLine("Por favor, ingresa un número válido.");
            continue;
        }

        intentos++;

        if (intentoUsuario < numeroSecreto)
        {
            Console.WriteLine("El número secreto es mayor. Proba otra vez");
        }
        else if (intentoUsuario > numeroSecreto)
        {
            Console.WriteLine("El número secreto es menor. Proba otra vez");
        }
        else
        {
            Console.WriteLine($"¡Felicidades! ¡Has adivinado el número secreto {numeroSecreto} en {intentos} intentos!");
            break;
        }
    } while (true);
}