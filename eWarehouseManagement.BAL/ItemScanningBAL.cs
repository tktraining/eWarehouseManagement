using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWarehouseManagement.Domain;

namespace eWarehouseManagement.BAL
{    
    public class ItemScanningBAL
    {
        public static List<ItemModel> scanneditems =new List<ItemModel>();

        public bool SaveInMemoryItemScanning(ItemModel objItem)
        {
            //TODO: Save item  scanned into a temporary in-memory collection
            scanneditems.Add(objItem);
            return true;
        }

        public static IList<string> GetAvailableLocations(List<ItemModel> lstItems)
        {
            //TODO: Filter occupied locations from all location list
            return null;
        }
    }
}
