using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet.Models
{
    public enum OrderStatus
    {

        NEW, 
        PROCESSING, 
        REGISTRED, 
        SHIPPING, 
        DELIVRED, 
        CANCELED
    }
}