
using Delegates;


Calculator calculator = new Calculator();
Console.WriteLine("Введитe выражение");
string expression=Console.ReadLine();
char sign = ' ';
foreach (char item in expression)
{
    if(item=='+'|| item == '-' || item == '*' || item == '/')
    {
        sign = item;
        break;
    }
}
try
{
    string[] numbers=expression.Split(sign);
    CalcDelegate del = null;
    switch(sign)
    {
        case '+':
            del=new CalcDelegate(calculator.Add);
            break;
        case '-':
            del = new CalcDelegate(calculator.Sub);
            break;
        case '*':
            del = calculator.Mult;
            break;
        case '/':
            del = calculator.Div;
            break;
        default:
            throw new InvalidOperationException();
    }
    Console.WriteLine($"Result:{del(double.Parse(numbers[0]),double.Parse(numbers[1]))}");
    int hour=DateTime.Now.Hour;
    Message mes;
    if (hour >= 6&&hour<9) mes = GoodMorning;
    else if (hour >= 9 && hour < 18) mes = GoodAfternoon;
    else if (hour >= 18 && hour < 22) mes = GoodEvening;
    else mes = GoodNight;
    mes();
    Message mes1 = GoodMorning;
    Message mes2 = GoodAfternoon;
    Message mes3 = mes1 + mes2;
    mes3();
    CalcDelegate del1 = calculator.Add;
    del1 += calculator.Sub;
    del1-= calculator.Sub;
    Console.WriteLine(del1(5,4));
    DoOperation(5, 4, calculator.Add);
    DoOperation(5, 4, calculator.Sub);
    DoOperation(5, 4, calculator.Mult);
    DoOperation(5, 4, calculator.Div);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

void DoOperation(double x,double y, CalcDelegate calc)
{
    Console.WriteLine(calc(x,y));
}

void GoodMorning()
{
    Console.WriteLine("Доброе утро");
}
void GoodAfternoon()
{
    Console.WriteLine("Добрый день");
}
void GoodEvening()
{
    Console.WriteLine("Добрый вечер");
}
void GoodNight()
{
    Console.WriteLine("Доброй ночи");
}

