using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityManagementSystemEngine
{
    public class WorkOrderInformation
    {
        public string id { get; set; }
        public string orderBy { get; set; }
        public string workDetails { get; set; }
        public string assignTo { get; set; }
        public DateTime orderdate { get; set; }
        public string roomNo { get; set; }
        
    }
}
