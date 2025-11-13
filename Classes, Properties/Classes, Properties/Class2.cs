using System;

namespace Classes__Properties
{
    public partial class Freezer
    {
        private string model;
        private double volume;
        private int temperature;

        private struct Size
        {
            public int height;
            public int width;
            public Size(int height, int width)
            {
                this.height = height;
                this.width = width;
            }
        }

        private Size freezerSize;
        private string energyClass;

        public static string developer;
        public static int garantyYears;

        static Freezer()
        {
            developer = "Samsung";
            garantyYears = 5;
        }

        public override string ToString()
        {
            return $"Модель: {model}, Об'єм: {volume}L, Температура: {temperature}°C, " +
                   $"Розмір: {freezerSize.height}x{freezerSize.width}см, " +
                   $"Енергоефективність: {energyClass}, Фірма: {developer}, " +
                   $"Гарантія: {garantyYears} років";
        }
    }
}
