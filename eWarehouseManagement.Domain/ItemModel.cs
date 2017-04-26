using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWarehouseManagement.Domain
{
    public class ItemModel
    {
        public int SNo { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime ScannedDate { get; set; }
    }
}
