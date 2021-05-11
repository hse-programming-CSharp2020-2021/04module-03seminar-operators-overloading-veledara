using System;

/*
Источник: https://metanit.com/

Дан класс Clock, который хранит количество часов.
В программе мы можем из целого (int) числа минут получить целое число часов (Clock) и, наоборот,
из целого числа часов (Clock) - целое количество минут (int) (возможна потеря точности).
Добавьте в класс Clock оператор для неявного преобразования от типа целого числа минут
к типу Clock - числу часов, и оператор явного преобразования от типа Clock к типу
int-овому числу минут.
Обработайте ситуации, когда число часов отрицательно (в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - целое число минут и целое число часов.
650
10
Программа должна вывести на экран число часов Clock и целое число минут (int)
с использованием перегруженных операторов:
10
600

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task03
{
    class Clock
    {
        public int Hours { get; set; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            int minute = int.Parse(Console.ReadLine());
            try
            {
                Clock clock = new Clock { Hours = int.Parse(Console.ReadLine()) };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }

            Console.WriteLine((Clock)minute);
            Console.WriteLine((int)clock);
        }
    }
}
