using pr12_trpo2.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr12_trpo2.Service
{
    public class BaseDbService
    {
        private BaseDbService()
        {
            context = new AppDbContext();   
        }

        private static BaseDbService? instance;
        public static BaseDbService Instance 
        {
            get
            {
                if (instance == null)
                    instance = new BaseDbService();
                return instance;
            }
        }

        private AppDbContext context;
        public AppDbContext Context => context;

    }
}
