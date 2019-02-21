using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ICampGroundDAO
    {
        /// <summary>
        /// Views campgrounds.
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        IList<CampGround> ViewCampground(int parkId);        


    }
}
