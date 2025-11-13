using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes__Properties
{
    public partial class Freezer{       
        public Freezer(string model)
            : this(model, 200, -20, 170, 60, "A+") {}
        public Freezer(string model, double volume)
            : this(model, volume, -18, 180, 70, "A++") {}

        public Freezer(string model, int temperature) : this(model, 150, temperature, 160, 55, "B") { }
        public Freezer(double volume, int height, int width) : this("Стандартний", volume, -18, height, width, "A") {}

        public Freezer(string model, double volume, int temperature, int height, int width, string energyClass)
        {
            this.model = model;
            this.volume = volume;
            this.temperature = temperature;
            this.freezerSize = new Size(height, width);
            this.energyClass = energyClass;
        }
    }
}
