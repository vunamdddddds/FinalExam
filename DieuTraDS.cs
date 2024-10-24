using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtracuoiki
{
    internal class DieuTraDS
    {

       public string macd { set; get; }
           public string tencd { set; get; }
            public string cccd { set; get; }
            public string gioitinh { set; get; }
            public string ngaysinh { set; get; }

        public DieuTraDS(string macd,string tencd,string cccd,string gioitinh,string ngaysinh)
        {
            this.macd = macd;
            this.tencd = tencd;
                this.cccd = cccd;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
        }
    }
}
