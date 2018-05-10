using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TKHTTT.Models
{
    public class ThongTinSach
    {
        private string maSach;
        private string maTL;
        private string tenSach;
        private float? giaBia;
        private string hinhAnh;
        private string maTG;
        private string tenTG;
        private string tenTL;

        public string MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public string MaTL
        {
            get
            {
                return maTL;
            }

            set
            {
                maTL = value;
            }
        }

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public float? GiaBia
        {
            get
            {
                return giaBia;
            }

            set
            {
                giaBia = value;
            }
        }

        public string HinhAnh
        {
            get
            {
                return hinhAnh;
            }

            set
            {
                hinhAnh = value;
            }
        }

        public string MaTG
        {
            get
            {
                return maTG;
            }

            set
            {
                maTG = value;
            }
        }

        public string TenTG
        {
            get
            {
                return tenTG;
            }

            set
            {
                tenTG = value;
            }
        }

        public string TenTL
        {
            get
            {
                return tenTL;
            }

            set
            {
                tenTL = value;
            }
        }
    }
}