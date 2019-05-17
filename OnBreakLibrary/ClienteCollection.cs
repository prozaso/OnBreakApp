using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
   public class ClienteCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        public IEnumerable<Object> ReadAll()
        {
            return (from c in this.bd.Cliente
                    select c).ToList();
        }
    }
}
