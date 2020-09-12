using System.Collections.Generic;

namespace DAL.ViewModels
{
    public   class ItemVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<KeyValueVM> keyValueVMs { get; set; }
    }
}
