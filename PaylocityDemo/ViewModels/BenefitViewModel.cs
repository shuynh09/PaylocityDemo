using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityDemo.ViewModels
{
    public class BenefitViewModel
    {
        public List<BenefitItem> Items { get; set; }

        public class BenefitItem
        {
            public string Header { get; set; }
            public string Caption { get; set; }
            public string Amount { get; set; }
        }
    }
}
