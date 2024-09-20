// See https://aka.ms/new-console-template for more information


Console.WriteLine("Please choose an operation:");
Console.WriteLine("1) Addition\n2) Substraction\n3) Multiplication\n4) Division");
string? calculation = null;
int? result = null;

void selectOption()
{
    string? selectedOperation = Console.ReadLine();
    while (selectedOperation != null)
    {
        switch (selectedOperation)
        {
            case "1":
                calculation = createCalculation("+");
                selectedOperation = null;
                break;
            case "2":
                calculation = createCalculation("-");
                selectedOperation = null;
                break;
            case "3":
                calculation = createCalculation("*");
                selectedOperation = null;
                break;
            case "4":
                calculation = createCalculation("/");
                selectedOperation = null;
                break;
            default:
                Console.WriteLine("Incorrect, please select a valid option.");
                break;
        }
    }
}

void checkAnswer()
{
    Console.WriteLine($"Please resolve: {calculation}, and enter your answer.");

    string? userAnswer = Console.ReadLine();
    while (userAnswer != null)
    {
        if (int.Parse(userAnswer) == result)
        {
            Console.WriteLine($"Congratulations! Your answer {userAnswer} is correct.");
        }
        else
        {
            Console.WriteLine($"Wrong! Result was: {result}.");
        }
        userAnswer = null;
    }
}

int[] generateRandomNumbers()
{
    Random random = new();
    int number1 = random.Next(1, 100);
    int number2 = random.Next(1, 100);
    return [number1, number2];
}

string createCalculation(string operation)
{
    int[] numbers = generateRandomNumbers();
    if (operation == "/")
    {
        double result = numbers[0] % numbers[1];
        while (result != 0)
        {
            numbers = generateRandomNumbers();
            result = numbers[0] % numbers[1];
        }
    }
    createSolution(numbers[0], numbers[1], operation);
    return $"{numbers[0]} {operation} {numbers[1]}";
}

void createSolution(int number1, int number2, string operation)
{
    if (operation == "+")
    {
        result = number1 + number2;
    }
    else if (operation == "-")
    {
        result = number1 - number2;
    }
    else if (operation == "*")
    {
        result = number1 * number2;
    }
    else if (operation == "/")
        result = number1 / number2;
    else
    {
        result = null;
    }
}

selectOption();
checkAnswer();
