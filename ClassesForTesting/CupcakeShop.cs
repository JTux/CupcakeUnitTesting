using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public class CupcakeShop
    {
        public CupcakeShop(string location)
        {
            Location = location;
        }

        public string Location { get; set; }
        public List<Cupcake> Inventory { get; } = new List<Cupcake>();
        public double Cash { get; private set; }
        public int TotalSold { get; private set; }

        // Adds the given Cupcake to the Inventory property
        public void AddToInventory(Cupcake cupcake)
        {
            Inventory.Add(cupcake);
        }

        // Initializes and adds a desired amount of specific cupcake types to the inventory List
        public void BakeBatch(string batter, string icing, double pricePerCupcake, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var freshCupcake = new Cupcake(batter, icing, pricePerCupcake);
                AddToInventory(freshCupcake);
            }
        }

        // Returns a string that gets a general status of the shop's history
        public string GetShopStatus()
        {
            return $"The shop currently has ${Cash} in the till, {Inventory.Count} cupcakes in the inventory, and has sold {TotalSold} cupcakes!";
        }

        // Sells a single cupcake, first on the list
        public string SellCupcake()
        {
            if (Inventory.Count > 0)
            {
                // Grabs first cupcake from the list and removes it. Save it as a variable so we can store the cost
                var firstCupcake = Inventory.First();
                Inventory.Remove(firstCupcake);

                // Adds the cost of the cupcake we "sold" and adds it to our cash
                Cash += firstCupcake.Cost;
                // Mark we sold a cupcake
                TotalSold++;

                // Give some output
                return $"You sold a {firstCupcake.Batter} with {firstCupcake.Icing} icing for {firstCupcake.Cost}.";
            }
            else
            {
                return "No cupcakes in inventory.";
            }
        }

        // Gets all cupcakes with a given cupcake type
        public List<Cupcake> GetCupcakesByType(string batter, string icing)
        {
            var cupcakesOfType = new List<Cupcake>();
            foreach (var cupcake in Inventory)
            {
                if (cupcake.Batter == batter && cupcake.Icing == icing)
                {
                    cupcakesOfType.Add(cupcake);
                }
            }

            return cupcakesOfType;

            // using a Linq method instead
            // .Where will return an IEnumerable from the Inventory where the conditions on the right evaluate as true
            var cupcakes = Inventory.Where(cupcake => cupcake.Batter == batter && cupcake.Icing == icing);
            // Because it's an IEnumerable, we have to call the .ToList() since we are returning a List<Cupcake>
            return cupcakes.ToList();
        }

        // Sell a specific amount of a given cupcake type
        public string SellCupcakesByType(string batter, string icing, int numberOfCupcakes)
        {
            // Get all the cupcakes we need
            var cupcakesOfType = GetCupcakesByType(batter, icing);

            // Check to see that we have enough cupcakes
            if (cupcakesOfType.Count >= numberOfCupcakes)
            {
                // Once found, we need to remove the target count of the found Cupcakes from the Inventory
                for (int i = 0; i < numberOfCupcakes; i++)
                {
                    // Grab the first cupcake
                    var cupcake = cupcakesOfType[i];
                    // Add the Cost to our total Cash
                    Cash += cupcake.Cost;
                    // Mark we sold a cupcake
                    TotalSold++;
                    // Remove from Inventory
                    Inventory.Remove(cupcake);
                }

                return $"You sold {numberOfCupcakes} {batter} with {icing} on top cupcakes.";
            }
            else
            {
                return $"Not enough {batter} cupcakes with {icing} on top in the inventory.";
            }
        }
    }
}
