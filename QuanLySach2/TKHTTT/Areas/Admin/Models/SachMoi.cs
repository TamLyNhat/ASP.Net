using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TKHTTT.Areas.Admin.Models
{
    public class SachMoi
    {
        private int so;
        private string chu;

        public string Chu
        {
            get
            {
                return chu;
            }

            set
            {
                chu = value;
            }
        }

        public int So
        {
            get
            {
                return so;
            }

            set
            {
                so = value;
            }
        }
    }
}