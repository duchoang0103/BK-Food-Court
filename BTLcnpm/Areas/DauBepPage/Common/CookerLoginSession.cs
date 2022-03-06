using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLcnpm.Areas.DauBepPage.Common
{
   
    [Serializable]
    public class CookerLoginSession
    {
        public long VendorID { set; get; }
        public string UserName { set; get; }
    }
}