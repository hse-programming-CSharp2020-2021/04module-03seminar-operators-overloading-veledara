using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        num = numerator;
        den = denominator;
    }

    public static int GetNODRecurs(int val1, int val2)
    {
        if (val2 == 0)
            return val1;
        else
            return GetNODRecurs(val2, val1 % val2);
    }
    public static Fraction Parse(string input)
    {
        string[] mas = input.Split('/');
        if (mas.Length > 1)
        {
            return new Fraction(Convert.ToInt32(mas[0]), Convert.ToInt32(mas[1]));
        }
        else
        {
            return new Fraction(Convert.ToInt32(mas[0]), 1);
        }
    }
    public static Fraction operator +(Fraction c1, Fraction c2)
    {
        int nod = GetNODRecurs(c1.den, c2.den);
        int nok = (c1.den * c2.den) / nod;
        int newnum = c1.num * (nok / c1.den) + c2.num * (nok / c2.den);
        int newden = nok;
        int newnod = GetNODRecurs(newnum, newden);
        if (newnum == 0)
        {
            return new Fraction(newnum, 1);
        }
        return new Fraction(newnum / newnod, newden / newnod);
    }
    public static Fraction operator -(Fraction c1, Fraction c2)
    {
        int nod = GetNODRecurs(c1.den, c2.den);
        int nok = (c1.den * c2.den) / nod;
        int newnum = c1.num * (nok / c1.den) - c2.num * (nok / c2.den);
        int newden = nok;
        int newnod = GetNODRecurs(newnum, newden);
        if (newnum == 0)
        {
            return new Fraction(newnum, 1);
        }
        return new Fraction(newnum / newnod, newden / newnod);
    }
    public static Fraction operator *(Fraction c1, Fraction c2)
    {
        int newnum = c1.num * c2.num;
        int newden = c1.den * c2.den;
        int nod = GetNODRecurs(newnum, newden);
        if (newnum == 0)
        {
            return new Fraction(newnum, 1);
        }
        return new Fraction(newnum / nod, newden / nod);
    }
    public static Fraction operator /(Fraction c1, Fraction c2)
    {
        if (c2.num==0 || c2.den == 0)
        {
            throw new DivideByZeroException();
        }
        int newnum = c1.num * c2.den;
        int newden = c1.den * c2.num;
        int nod = GetNODRecurs(newnum, newden);
        if (newnum == 0)
        {
            return new Fraction(newnum, 1);
        }
        return new Fraction(newnum / nod, newden / nod);
    }
    public override string ToString()
    {
        if (den == 1)
            return num.ToString();
        if (den < 0)
        {
            return "-" + num + "/" + (-den);
        }
        return num + "/" + den;
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            Fraction a = Fraction.Parse(Console.ReadLine());
            Fraction b = Fraction.Parse(Console.ReadLine());
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
