using Data.EF.Interfaces;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class ClienteRepository : BaseRepostiry<Cliente>, ICliente
    {
        public Cliente LastId()
        {
            using (Context ctx = new Context())
            {
                var list = ctx.Cliente.ToList();

                if (list != null && list.Count > 0)
                    return list.Last();
            }
            return null;
        }
    }
}
