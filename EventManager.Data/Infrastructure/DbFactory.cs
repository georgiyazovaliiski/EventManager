using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        EventEntities dbContext;

        public EventEntities Init()
        {
            return dbContext ?? (dbContext = new EventEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
