using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class CampGroundSqlDAO : ICampGroundDAO
    {
        private string connectionString;

        public CampGroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


    }
}
