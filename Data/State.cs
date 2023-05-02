using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.abstraction.interfaces;

namespace Data
{
    internal class State : IState
    {
        public State(int id, int pid, double pq)
        {
            this.StateId = id;
            this.ProductId = pid;
            this.ProductQuantity = pq;
        }

        public int StateId { get; }

        public int ProductId { get; }

        public double ProductQuantity { get; set; }
    }

}

