using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indeed_API
{
    public class SearchResultModel
    {
        /// <summary>
        /// Total number of jobs hit by search
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Job list
        /// </summary>
        public List<JobModel> Jobs { get; set; }

        /// <summary>
        /// List of JobModel
        /// </summary>
        public SearchResultModel()
        {
            Jobs = new List<JobModel>();
        }

        /// <summary>
        /// Job search key words ex. software developer
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Location ex. akron, oh
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Radius in miles ex. 25
        /// </summary>
        public string Radius { get; set; }
    }
}
