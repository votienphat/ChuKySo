using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuKySo.BL.Enums
{
    public enum SiteId
    {
        [Description("Bố Cáo Doanh Nghiệp")]
        BoCaoDoanhNghiep = 1,

        [Description("Danh Bạ Doanh Nghiệp")]
        DanhBaDoanhNghiep = 2,

        [Description("Dữ Liệu Công Ty")]
        DuLieuCongTy = 3,
    }
}
