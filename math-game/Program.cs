// See https://aka.ms/new-console-template for more information

Console.WriteLine("Please choose an operation:");
Console.WriteLine("1- Addition\n2- Substraction\n3- Multiplication\n4- Division");
string? selectedOperation = Console.ReadLine();
string? calculation = null;
int? result = null;

while (selectedOperation != null)
{
  switch (selectedOperation)
  {
    case "1":
      calculation = createCalculation("+");
      break;
    case "2":
      calculation = createCalculation("-");
      break;
    case "3":
      calculation = createCalculation("*");
      break;
    case "4":
      calculation = createCalculation("/");
      break;
    default:
      Console.WriteLine("Incorrect, please select a valid option.");
      break;
  }
  selectedOperation = null;
}

Console.WriteLine($"Please resolve: {calculation}, and enter your answer.");

string? userAnswer = Console.ReadLine();

while (userAnswer != null)
{
  if (int.Parse(userAnswer) == result)
  {
    Console.WriteLine("Congratulations! Your answer is correct.");
  }
  else
  {
    Console.WriteLine($"Wrong! Result was: {result}.");
  }
  userAnswer = null;
}


string createCalculation(string operation)
{
  Random random = new Random();
  int number1 = random.Next(1, 100);
  int number2 = random.Next(1, 100);
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
    result = number1 / number2;
  }
  else
  {
    result = null;
  }
  return $"{number1} {operation} {number2}";
}
