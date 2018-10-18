using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;

using System.Data;
using Newtonsoft.Json;

/// <summary>
/// Indeed job search API
/// </summary>
namespace Indeed_API
{
    /// <summary>
    /// Indeed search engine
    /// </summary>
    public class IndeedSearch
    {
        private string _apilink;
        private string _apikey;
        private string _keyword;
        private string _city;
        private string _country;
        private string _radius;
        private int _start;
        private int _pagesize;
        private int _pageno;
        private string _sort;
        private string _ip;
        private string _useragent;
        private NameValueCollection _searchparams;

        /// <summary>
        /// API key
        /// </summary>
        public string Apikey
        {
            get { return _apikey; }
            set { _apikey = value; }
        }

        /// <summary>
        /// Search Key Word
        /// </summary>
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        /// <summary>
        /// City ex. akron, oh
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// country ex. us
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// radius in miles ex. 25
        /// </summary>
        public string Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// page size
        /// </summary>
        public int Pagesize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        /// <summary>
        /// page numebr
        /// </summary>
        public int Pageno
        {
            get { return _pageno; }
            set {
                _pageno = value;
                _start = (value*_pagesize) -_pagesize ; 
            }
        }

        /// <summary>
        /// user IP address default is 1.2.3.4
        /// </summary>
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        /// <summary>
        /// user agent ex. Mozilla/%2F4.0(Firefox)
        /// </summary>
        public string Useragent
        {
            get { return _useragent; }
            set { _useragent = value; }
        }

        /// <summary>
        /// sort key
        /// </summary>
        public string Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        /// <summary>
        /// api link ex. http://api.indeed.com/ads/apisearch
        /// </summary>
        /// <param name="apiLink"></param>
        public IndeedSearch(string apiLink)
        {
            _apilink = apiLink;
            _searchparams=new NameValueCollection();

        }

        /// <summary>
        /// Add parameters
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParam(string key,string value)
        {
            _searchparams.Add(key, value);
        }

        /// <summary>
        /// Build parameters
        /// </summary>
        /// <param name="start"></param>
        private void BuildParams(int start)
        {
            AddParam("publisher", _apikey);
            AddParam("q", _keyword);
            AddParam("l", _city);
            AddParam("sort", _sort);
            AddParam("radius", _radius);
            AddParam("st", "");
            AddParam("jt", "");
            AddParam("start", start.ToString());
            AddParam("limit", _pagesize.ToString());
            AddParam("fromage", "7");
            AddParam("format", "json");
            AddParam("filter", "");
            AddParam("latlong", "1");
            AddParam("co", _country);
            AddParam("chnl", "");
            AddParam("userip", _ip);
            AddParam("useragent", _useragent);
            AddParam("v", "2");
        }

        /// <summary>
        /// Search jobs
        /// </summary>
        /// <returns></returns>
        public IndeedResults Search()
        {
            IndeedResults jObj = doSearch(_start);

            while (jObj.results.Count < int.Parse(jObj.totalresults)
                   && jObj.results.Count < 1000)
            {
                _start += 25;
                jObj.results.AddRange(doSearch(_start).results);
            }

            return jObj;
        }

        /// <summary>
        /// Job search: helper method
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private IndeedResults doSearch(int start)
        {
            WebClient webclient;
            _searchparams.Clear();
            BuildParams(start);
            string url = Url.BuildURL(_searchparams, _apilink);
            string json = string.Empty;
            using (webclient = new WebClient())
            {
                webclient.Encoding = System.Text.Encoding.UTF8;
                json = webclient.DownloadString(url);
            }
            IndeedResults jObj = JsonConvert.DeserializeObject<IndeedResults>(json);

            return jObj;
        }
        public JobModel GetJob(string jobkey)
        {
            WebClient webclient;
            string url = _apilink + "?publisher=" + _apikey + "&jobkeys=" + jobkey + "&v=2&format=json";
            string json = string.Empty;
            using (webclient = new WebClient())
            {
                webclient.Encoding = System.Text.Encoding.UTF8;
                json = webclient.DownloadString(url);
            }
            IndeedResults jObj = JsonConvert.DeserializeObject<IndeedResults>(json);
            return new JobModel()
            {
                JobTitle = jObj.results[0].JobTitle,
                Company = jObj.results[0].Company,
                Description = jObj.results[0].Description,
                Date =jObj.results[0].Date,
                Url = jObj.results[0].Url,
                Location = jObj.results[0].Location,
                Latitude = jObj.results[0].Latitude,
                Longitude = jObj.results[0].Longitude,
                Salary = jObj.results[0].Salary,

            };

        }



    }
}
