using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuKySo.BL.Model
{
    public class RequestCompanyModel
    {
        public string Url { get; set; }

        /// <summary>
        /// Bắt đầu tìm từ vị trí thứ mấy
        /// </summary>
        public int? FromIndex { get; set; }

        /// <summary>
        /// Dừng tìm ở vị trí thứ mấy
        /// </summary>
        public int? ToIndex { get; set; }
    }
}
