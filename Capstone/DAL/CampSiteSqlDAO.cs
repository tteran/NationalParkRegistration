using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class CampSiteSqlDAO : ICampSiteDAO
    {
        private string connectionString;

        public CampSiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


    }
}
