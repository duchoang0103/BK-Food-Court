using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.EF
{
    [Serializable]
    public class DoanhThuMonAnModel
    {
        public string TenMonAn { set; get; }
        public decimal TongTien { set; get; }
    }
}