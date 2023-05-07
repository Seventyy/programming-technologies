using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Item
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public double quantity { get; set; }


        public Item(int id, string name, double quantity)
        {
            if (id < 0 || quantity < 0 || string.IsNullOrEmpty(name))
                throw new ArgumentNullException("value");

            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }

        public (int, string, double) GetItemProperties()
        {
            return (this.id, this.name, this.quantity);
        }

        public void setQuantity(double quantity)
        {
            if (quantity >= 0)
                this.quantity = quantity;
        }
    }
}