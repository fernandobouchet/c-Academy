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
      Console.WriteLine($"Congratulations! Your answer ${userAnswer} is correct.");
    }
    else
    {
      Console.WriteLine($"Wrong! Result was: {result}.");
    }
    userAnswer = null;
  }
}


string createCalculation(string operation)
{
  Random random = new Random();
  int number1 = random.Next(1, 100);
  int number2 = random.Next(1, 100);
  createSolution(number1, number2, operation);
  return $"{number1} {operation} {number2}";
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
  {
    if (number1 < number2)
    {
      result = number2 / number1;

    }
    else
    {
      result = number1 / number2;

    }
  }
  else
  {
    result = null;
  }
}

selectOption();
checkAnswer();