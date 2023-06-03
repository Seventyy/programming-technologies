using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    public interface IProcuctModel
    {
        int ProductId { get; }
        string Name { get; set; }
        double Price { get; set; }
        double State { get; set; }

        void Add();
        void Edit(string n, double p, double s);
        void Delete();
    }
}
