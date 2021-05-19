using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Entity
{
    public class Network : IStoreable
    {
        public string Name { get; set; }
        public IComparable Id { get; set; }
    }
}
