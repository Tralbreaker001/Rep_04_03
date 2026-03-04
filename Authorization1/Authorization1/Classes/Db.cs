using Authorization1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization1.Classes
{
    internal class Db
    {
        public static DEM_users_Entities Context { get; set; } = new DEM_users_Entities();
    }
}
