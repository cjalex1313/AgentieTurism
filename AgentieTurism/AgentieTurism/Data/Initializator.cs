using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Data
{
    public static class Initializator
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
