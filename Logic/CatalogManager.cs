using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CatalogManager
    {
        Catalog catalog;
        public CatalogManager(Catalog catalog)
        {
            this.catalog = catalog; 
        }

        public bool HandleEvent(Event e)
        {
            if (e is null) return false;

            if (e.state == Event.states.active)
            {
                foreach (Item item in catalog.GetAll())
                {
                    if (item.id == e.item.id)
                    {
                        if (item.quantity < e.item.quantity)
                            return false;
                        item.quantity -= e.item.quantity;
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
    }
}
