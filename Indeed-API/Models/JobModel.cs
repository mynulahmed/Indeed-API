using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indeed_API
{
    public class JobModel
    {
        /// <summary>
        /// Job Title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Job Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Post date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Job Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Employer
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Employer Website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        public string Salary { get; set; }

        /// <summary>
        /// Job Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Job Location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Latitude of Job Location
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude of Job Location
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// API
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Job Key
        /// </summary>
        public string JobKey { get; set; }

    }
}
