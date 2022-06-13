using SCRP.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRP.BLL
{
    public class ContextInit
    {
        public static void InitializeDB()
        {
            DatabaseContext context = new DatabaseContext();
            context.Database.CreateIfNotExists();
        }

    }
}
