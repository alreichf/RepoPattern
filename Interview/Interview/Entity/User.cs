using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Entity
{
    public class User : IStoreable
    {
        public IComparable Id { get; set; }
        public string UserName { get; set; }
    }
}
