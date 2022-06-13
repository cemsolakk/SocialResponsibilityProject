using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRP.Foundation.DataAccess.EntityFramework
{
    class SingletonContext<TContext>
        where TContext : DbContext,new()
    {
        private static TContext _context;

        protected SingletonContext()
        {
        }

        public static TContext GetInstance()
        {
            if (_context == null)
            {
                _context = new TContext();
            }
            return _context;
        } 
    }
}
