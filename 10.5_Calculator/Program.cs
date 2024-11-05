namespace _10._5_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ilogger logger = new Logger();
            IAddition adder = new Adder();


            while (true)
            {
                try
                {
                    Console.WriteLine("введите первое число");
                    int Number1 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("введите второе число");
                    int Number2 = Convert.ToInt32(Console.ReadLine());

                    int result = adder.Add(Number1, Number2);
                    Console.WriteLine($"сумма слогаемых чисел равна : {result}");

                    

                    break;

                }
                catch (FormatException)
                {
                    logger.Error("Ошибка: Введено некорректное значение. Пожалуйста, введите целое число.");
                }
                catch (OverflowException)
                {
                    logger.Error("Ошибка: Введенное число слишком велико или слишком мало.");
                }
            }
            logger.Event("программа завершена");
            Console.ReadKey();
        }


        public interface IAddition //интерфейс по добавлению слогаемых чисел
        { 
            int Add(int a, int b);
        }


        public class Adder : IAddition // создаем класс унаследованный от интерфейса, суммирующий числа
        {
            public int Add(int a, int b) { return a + b; }
        }

        public interface Ilogger
        {
            void Event(string message);
            void Error(string message);
        }

        public class Logger : Ilogger
        {
            void Ilogger.Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();//сброс цвета 
            }

            void Ilogger.Event(string message)
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine(message);
                Console.ResetColor();//сброс цвета
            }
        }
    }
}
