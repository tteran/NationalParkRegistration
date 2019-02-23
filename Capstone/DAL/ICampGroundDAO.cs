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
        IList<CampGround> ViewCampgrounds(int parkId);

        /// <summary>
        /// Views a campground.
        /// </summary>
        /// <param name="campGroundId"></param>
        /// <returns></returns>
        CampGround ViewCampground(int campGroundId);
    }
}
