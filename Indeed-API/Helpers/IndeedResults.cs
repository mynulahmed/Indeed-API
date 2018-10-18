using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indeed_API
{
    public class IndeedResults
    {
       
        public string totalresults { get; set; }

        public List<JobModel> results { get; set; }
        
    }
}
