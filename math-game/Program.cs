﻿// See https://aka.ms/new-console-template for more information


string? option = "";
string? calculation = null;
int? result = null;
List<string> history = [];

Console.WriteLine("Please choose an option:");
Console.WriteLine("1) Choose a calculation to solve \n2) View history \n3) Exit");
option = Console.ReadLine();

while (option != null)
{
    if (option == "1")
    {
        selectOption();
        checkAnswer();
    }
    else if (option == "2")
    {
        showHistory();
        Console.WriteLine("5) Menu.");
        option = Console.ReadLine();
    }
    else if (option == "5")
    {
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1) Choose a calculation to solve \n2) View history \n3) Exit");
        option = Console.ReadLine();
    }
    else
    {
        return;
    }
}

void selectOption()
{
    Console.WriteLine("Please select a calculation:");
    Console.WriteLine(
        "1) Addition\n2) Substraction\n3) Multiplication\n4) Division\n Press any other key to go back."
    );
    string? selectedOperation = Console.ReadLine();

    var operations = new Dictionary<int, string>
    {
        { 1, "+" },
        { 2, "-" },
        { 3, "*" },
        { 4, "/" },
    };

    bool op = int.TryParse(selectedOperation, out int selectedOptionOperation);
    if (op && selectedOptionOperation >= 1 && selectedOptionOperation <= 4)
    {
        calculation = createCalculation(operations[selectedOptionOperation]);
    }
    else
    {
        option = "5";
    }
}

void checkAnswer()
{
    if (option != "1")
        return;

    Console.WriteLine($"Please resolve: {calculation}, and enter your answer.");

    string? userAnswer = Console.ReadLine();
    while (userAnswer != null)
    {
        bool stringIsInt = int.TryParse(userAnswer, out int userAnswerOperation);
        if (stringIsInt && userAnswerOperation == result)
        {
            Console.WriteLine($"Congratulations! Your answer {userAnswer} is correct.");
        }
        else
        {
            Console.WriteLine($"Wrong! Result was: {result}.");
        }
        history.Add($"{calculation} = {userAnswer}");
        calculation = null;
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

void showHistory()
{
    if (history.Count > 0)
    {
        foreach (var item in history)
        {
            Console.WriteLine($"{item}\n");
        }
    }
    else
    {
        Console.WriteLine("History is empty");
    }
    ;
}
