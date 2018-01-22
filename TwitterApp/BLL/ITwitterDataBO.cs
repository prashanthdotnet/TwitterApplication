using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterApp.Models;

namespace TwitterApp.BLL
{
    public interface ITwitterDataBO
    {
        /// <summary>
        /// Get Twitter data
        /// </summary>
        /// <returns></returns>
        string GetTwitterData();
    }
}