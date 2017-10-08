using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaDispenser fountain = new SodaDispenser();
            fountain.Colas.AvailableFlavors.Add(new OriginalCola(220));
            fountain.Colas.AvailableFlavors.Add(new CherryCola(230));

            fountain.LemonLime.Calories = 180;

            fountain.RootBeer.AvailableFlavors.Add(new OriginalRootBeer(225));
            fountain.RootBeer.AvailableFlavors.Add(new VanillaRootBeer(225));

            fountain.DisplayCalories();

            Console.ReadKey();
        }
    }

   public abstract class SoftDrink
    {
        public int Calories { get; set; }

        public SoftDrink(int calories)
        {
            Calories = calories;
        }
    }

    public class OriginalCola :SoftDrink
    {
        public OriginalCola(int calories) : base(calories) { }
    }

    public class CherryCola:SoftDrink
    {
        public CherryCola(int calories) : base(calories) { }
    }
    public class OriginalRootBeer :SoftDrink
    {
        public OriginalRootBeer(int calories) : base(calories) { }
    }

    public class VanillaRootBeer :SoftDrink
    {
        public VanillaRootBeer(int calories) : base(calories) { }
    }

    public class LemonLime :SoftDrink
    {
        public LemonLime(int calories) : base(calories) { }
    }

    public class Colas
    {
        public List<SoftDrink> AvailableFlavors { get; set; }

        public Colas()
        {
            AvailableFlavors = new List<SoftDrink>();
        }
    }
    public class RootBeer
    {
        public List<SoftDrink> AvailableFlavors { get; set; }

        public RootBeer()
        {
            AvailableFlavors = new List<SoftDrink>();
        }
    }

    public class SodaDispenser
    {
        public Colas Colas { get; set; }
        public LemonLime LemonLime { get; set; }
        public RootBeer RootBeer { get; set; }

        public SodaDispenser()
        {
            Colas = new Colas();
            LemonLime = new LemonLime(190);
            RootBeer = new RootBeer();
        }

        public void DisplayCalories()
        {
            var sodas = new Dictionary<string, int>();
            foreach(var cola in Colas.AvailableFlavors)
            {
                sodas.Add(cola.GetType().Name,cola.Calories);
            }
            sodas.Add(LemonLime.GetType().Name, LemonLime.Calories);
            foreach(var rootbeer in RootBeer.AvailableFlavors)
            {
                sodas.Add(rootbeer.GetType().Name, rootbeer.Calories);
            }
            Console.WriteLine("Calories:");
            foreach(var soda in sodas)
            {
                Console.WriteLine(soda.Key + ": " + soda.Value.ToString() + " calories.");
            }

        }
    }
}
