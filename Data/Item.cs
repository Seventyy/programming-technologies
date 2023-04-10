namespace Data
{
    public class Item
    {
        private int id { get; set; }

        private string name { get; set; }

        private double quantity { get; set; }

        public (int,string,double) GetItemProperties()
        {
            return (this.id,this.name,this.quantity);  
        }

        public void SetItemProperties(int id, string name, double quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }
    }
}