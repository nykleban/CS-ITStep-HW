using System;
using System.Text;
namespace Operator_overloading
{
    public class Square
    {
        public int A { get; set; }
        public Square(int a)
        {
            A = a;
        }
        public override string ToString()
        {
            return @$"(Кв: {A})";
        }
        // ++ --      + - * /
        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }
        public static Square operator --(Square s)
        {
            s.A--;
            return s;
        }
        public static Square operator +(Square s1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число повинно бути додатнім");
            return new Square(s1.A + number);
        }
        public static Square operator -(Square s1, int number)
        {
            if (number < 0 || s1.A - number <= 0)
                throw new ArgumentException("Число або результат повинно бути додатнім");
            return new Square(s1.A - number);
        }
        public static Square operator *(Square s1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число повинно бути додатнім");
            return new Square(s1.A * number);
        }
        public static Square operator /(Square s1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число або результат повинно бути додатнім");
            if (number == 0)
                throw new ArgumentException("Не можна ділити на 0");
            return new Square(s1.A / number);
        }
        //< > <= >= == != Equals GetHashCode.
        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }
        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }
        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }
        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }
        public static bool operator ==(Square s1, Square s2)
        {
            return s1.A == s2.A;
        }
        public static bool operator !=(Square s1, Square s2)
        {
            return s1.A != s2.A;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Square s)
            {
                return this.A == s.A;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return A.GetHashCode();
        }
        //оператори true і false
        public static bool operator true(Square s)
        {
            return s.A != 0;
        }
        public static bool operator false(Square s)
        {
            return s.A == 0;
        }
        //неявне приведення (implicit) квадрату до прямокутника
        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, s.A);
        }
        //неявне приведення квадрату до типу int
        public static implicit operator int(Square s) { 
        
            return s.A;
        }

    }
    public class Rectangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return @$"(Пр: {A}, {B})";
        }
        //++ --          + - * /
        public static Rectangle operator ++(Rectangle r)
        {
            r.A++;
            r.B++;
            return r;
        }
        public static Rectangle operator --(Rectangle r)
        {
            r.A--;
            r.B--;
            return r;
        }
        public static Rectangle operator +(Rectangle r1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число повинно бути додатнім");
            return new Rectangle(r1.A + number, r1.B + number);
        }
        public static Rectangle operator -(Rectangle r1, int number)
        {
            if (number < 0 || r1.A - number <= 0 || r1.B - number <= 0)
                throw new ArgumentException("Число або результат повинно бути додатнім");
            return new Rectangle(r1.A - number, r1.B - number);
        }
        public static Rectangle operator *(Rectangle r1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число повинно бути додатнім");
            return new Rectangle(r1.A * number, r1.B * number);
        }
        public static Rectangle operator /(Rectangle r1, int number)
        {
            if (number < 0)
                throw new ArgumentException("Число або результат повинно бути додатнім");
            if (number == 0)
                throw new ArgumentException("Не можна ділити на 0");
            return new Rectangle(r1.A / number, r1.B / number);
        }
        //< > <= >= == != Equals GetHashCode.
        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) > (r2.A + r2.B);
        }
        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) < (r2.A + r2.B);
        }
        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) >= (r2.A + r2.B);
        }
        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) <= (r2.A + r2.B);
        }
        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) == (r2.A + r2.B);
        }
        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return (r1.A + r1.B) != (r2.A + r2.B);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Rectangle r)
            {
                return this.A + this.B == r.A + r.B;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (A + B).GetHashCode();
        }

        //оператори true і false
        public static bool operator true(Rectangle r)
        {
            return r.A != 0 && r.B != 0;
        }
        public static bool operator false(Rectangle r)
        {
            return r.A == 0 || r.B == 0;
        }

        //явне приведення(explicit) прямокутника до квадрату
        public static explicit operator Square(Rectangle r) { 
        return new Square((r.A + r.B) );
        }
        //явне приведення прямокутника до типу int
        public static implicit operator int(Rectangle s) { 
        return (s.A + s.B);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // цей код допоміг написати ChatGPT, для зручності перевірки роботи операторів

           
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("Формат: (ФІГУРА: ЧИСЛО), де ФІГУРА - Кв(квадрат) або Пр(Прямокутник) і ЧИСЛО(значення сторони)");
                Console.WriteLine("=== КВАДРАТ ===");

                Square s = new Square(5);
                Square s2 = new Square(7);

                Console.WriteLine($"Початковий квадрат s: {s}");
                Console.WriteLine($"Порівняльний квадрат s2: {s2}");

                Console.WriteLine("\n-- Інкремент ++ --");
                Console.WriteLine($"s++ : Було {s}, Стало {s++}");
                Console.WriteLine($"s-- : Було {s}, Стало {s--}");

                Console.WriteLine("\n-- Арифметика + - * / --");
                Console.WriteLine($"{s} + 3 = {s + 3}");
                Console.WriteLine($"{s} - 2 = {s - 2}");
                Console.WriteLine($"{s} * 2 = {s * 2}");
                Console.WriteLine($"{s} / 2 = {s / 2}");

                Console.WriteLine("\n-- Порівняння --");
                Console.WriteLine($"{s} > {s2} = {s > s2}");
                Console.WriteLine($"{s} < {s2} = {s < s2}");
                Console.WriteLine($"{s} >= {s2} = {s >= s2}");
                Console.WriteLine($"{s} <= {s2} = {s <= s2}");
                Console.WriteLine($"{s} == {s2} = {s == s2}");
                Console.WriteLine($"{s} != {s2} = {s != s2}");

                Console.WriteLine("\n-- true / false --");
                Console.WriteLine($"if ({s}) → {(s ? "істина" : "хиба")}");
                Square zero = new Square(0);
                Console.WriteLine($"if ({zero}) → {(zero ? "істина" : "хиба")}");

                Console.WriteLine("\n=== ПРЯМОКУТНИК ===");
                Rectangle r = new Rectangle(4, 8);
                Rectangle r2 = new Rectangle(10, 2);

                Console.WriteLine($"Початковий r: {r}");
                Console.WriteLine($"Порівняльний r2: {r2}");

                Console.WriteLine("\n-- ++ і -- --");
                Console.WriteLine($"r++ : Було {r}, Стало {r++}");
                Console.WriteLine($"r-- : Було {r}, Стало {r--}");

                Console.WriteLine("\n-- Арифметика --");
                Console.WriteLine($"{r} + 2 = {r + 2}");
                Console.WriteLine($"{r} - 1 = {r - 1}");
                Console.WriteLine($"{r} * 2 = {r * 2}");
                Console.WriteLine($"{r} / 2 = {r / 2}");

                Console.WriteLine("\n-- Порівняння --");
                Console.WriteLine($"{r} > {r2} = {r > r2}");
                Console.WriteLine($"{r} < {r2} = {r < r2}");
                Console.WriteLine($"{r} >= {r2} = {r >= r2}");
                Console.WriteLine($"{r} <= {r2} = {r <= r2}");
                Console.WriteLine($"{r} == {r2} = {r == r2}");
                Console.WriteLine($"{r} != {r2} = {r != r2}");

            Console.WriteLine("\n-- true / false оператори --");
            if (r)
                Console.WriteLine("r істинний");
            else
                Console.WriteLine("r хибний");

            Rectangle badR = new Rectangle(0, 5);
            if (badR)
                Console.WriteLine("badR істинний");
            else
                Console.WriteLine("badR хибний");

            Console.WriteLine("\n=== ПЕРЕТВОРЕННЯ ТИПІВ ===");

    Console.WriteLine("\n-- Square → Rectangle (implicit) --");
    Rectangle rr = s;
    Console.WriteLine($"{s} → Rectangle = {rr}");

    Console.WriteLine("\n-- Rectangle → Square (explicit) --");
    Square ss = (Square)r;
    Console.WriteLine($"{r} → Square = {ss}");

    Console.WriteLine("\n-- Square → int --");
    int si = s;
    Console.WriteLine($"{s} → int = {si}");

    Console.WriteLine("\n-- Rectangle → int --");
    int ri = r;
    Console.WriteLine($"{r} → int = {ri}");

    Console.WriteLine("\n=== КІНЕЦЬ ===");


           
        }
    }
}
