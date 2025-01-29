using System;

namespace PolytechPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int target_width, onesection_width, section_kolvo, delay;
            target_width = 15 + 15;
            onesection_width = 1;
            section_kolvo = 10;
            delay = 30;

            // settings
            Console.WriteLine("Чтобы изменить настройки игры введите Y");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                Settings(target_width, onesection_width, section_kolvo, delay);
            }

            int shotNumber = 1, TotalScore = 0, Score = 0;
            do
            {
                double halfTargetWidth = target_width / 2.0; // половина ширины мишени
                int circle_width = section_kolvo * onesection_width; // ширина мишени
                int MaxScore = section_kolvo; // максимальное кол-во очков и кол-во очков полученное за выстрел

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nВыстрел {shotNumber}");
                Console.ForegroundColor = ConsoleColor.White;

                shotNumber++;
                double x = -halfTargetWidth, y = -halfTargetWidth;

                x = FindX(x, halfTargetWidth, delay);
                //определение X
                y = FindY(y, halfTargetWidth, delay);
                //определение Y

                TotalResult(x, y, circle_width, MaxScore, TotalScore, Score);
                
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Y);
        }
        static void Settings(int target_width, int onesection_width, int section_kolvo, int delay)
        {
            Console.WriteLine("Введите ширину мишени (целое число от 1 до 50) [Стандартное значение: 30]");
            target_width = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите ширину одной секции (целое число от 1 до 10) [Стандартное значение: 1]");
            onesection_width = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите количество секций (целое число от 1 до 50) [Стандартное значение: 10");
            section_kolvo = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите необходимую задержку (целое число от 10 до 300) [Стандартное значение: 30");
            delay = Convert.ToInt16(Console.ReadLine());
            while (onesection_width * section_kolvo > target_width)
            {
                Console.WriteLine("Данные введены некорректно. Если хотите вернуться к стандартным значениям, нажмите Y, иначе нажмите любую другую клавишу");
                if (Console.ReadKey(true).Key == ConsoleKey.Y) break;
                Console.WriteLine("Введите ширину мишени (целое число от 1 до 50) [Стандартное значение: 30]");
                target_width = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите ширину одной секции (целое число от 1 до 10) [Стандартное значение: 1]");
                onesection_width = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите количество секций (целое число от 1 до 50) [Стандартное значение: 10");
                section_kolvo = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите необходимую задержку (целое число от 10 до 300) [Стандартное значение: 30");
                delay = Convert.ToInt16(Console.ReadLine());
            }
            return;
        }
        
        static double FindX(double x, double halfTargetWidth, int delay)
        {
            Console.WriteLine("Определение X... Нажмите клавишу");
            Random Random = new Random();
            while (!Console.KeyAvailable)
            {
                x += Random.NextDouble();
                if (x > halfTargetWidth) x = -halfTargetWidth;
                Thread.Sleep(delay);
                Console.Write($"{x}");
                Console.CursorLeft = 0;
            }
            Console.WriteLine($"X = {x}");
            Console.ReadKey();
            return x;
        }

        static double FindY(double y, double halfTargetWidth, int delay)
        {
            Console.WriteLine("Определение Y... Нажмите клавишу");
            Random Random = new Random();
            while (!Console.KeyAvailable)
            {
                y += Random.NextDouble();
                if (y > halfTargetWidth) y = -halfTargetWidth;
                Thread.Sleep(delay);
                Console.Write($"{y}");
                Console.CursorLeft = 0;
            }
            Console.WriteLine($"Y = {y}");
            Console.ReadKey();
            return y;
        }

        static void TotalResult(double x, double y, int circle_width, int MaxScore, int TotalScore, int Score)
        {
            if (Math.Sqrt(x*x + y*y) > circle_width)
                Score = 0;
            else
                Score = (MaxScore - (int)Math.Sqrt(x*x + y*y)); // от максимального количества отнимаем радиус-вектор попадания (округленный в меньшую сторону)

            TotalScore += Score;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nВыстрел: {Score} Общий счет: {TotalScore}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nЕсли хотите выйти, нажмите Y");

            /* функция принимает значения x, y, ширину мишени для проверки кол-ва полученных очков,
                максимальное кол-во очков, общее кол-во очков полученных за все выстрелы и кол-во очков,
                полученное за этот выстрел

                при условии, что радиус вектор точки попадания больше ширины мишени, мы получаем 0 очков

                далее для того, чтобы узнать кол-во полученных очков от максимального кол-ва очков отнимаем
                длину вектора точки попадания
            */
        }
    }
}