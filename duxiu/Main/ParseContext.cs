using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse.Main
{
    public class ParseContext
    {
        private List<String> urls = new List<string>(10);
        private int urlIndex = -1;
        // public BookParseResult CurrentResult { get; set; }
        private Dictionary<String, BookParseResult> results = new Dictionary<String, BookParseResult>();
        private Dictionary<String, AuxPageParseResult> auxPageParseResults = new Dictionary<string, AuxPageParseResult>();
        public Dictionary<String, AuxPageParseResult> AuxPageParseResults { get { return auxPageParseResults; } }
        public List<String> Urls
        {
            get { return urls; }
        }

        public void AddUrl(String url)
        {
            lock (this)
            {
                if (urls.Contains(url) == false)
                {
                    urls.Add(url);
                }
            }
        }

        public bool HasNext()
        {
            lock (this)
            {
                return urlIndex < urls.Count - 1;
            }
        }

        public String NextUrl()
        {
            lock (this)
            {
                if (urlIndex >= urls.Count)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                return urls[++urlIndex];
            }
        }

        public String CurrentUrl
        {
            get
            {
                lock (this)
                {
                    if (urlIndex >= urls.Count)
                    {
                        throw new System.ArgumentOutOfRangeException();
                    }
                    return urls[urlIndex];
                }
            }
        }
        public void Clear()
        {
            lock (this)
            {
                this.urlIndex = 0;
                this.urls.Clear();
                this.results.Clear();
                this.auxPageParseResults.Clear();
            }
        }

        public bool AddResult(String url, BookParseResult result)
        {
            lock (this)
            {
                if (results.ContainsKey(url))
                {
                    return false;
                }
                this.results.Add(url, result);
                return true;
            }
        }

        public BookParseResult GetResult(String url)
        {
            lock (this)
            {
                if (results.ContainsKey(url))
                {
                    return results[url];
                }
                return null;
            }
        }


        public void AddRange(IEnumerable<String> urlList)
        {
            lock (this)
            {
                this.urls.AddRange(urlList);
            }
        }

        public void Reset()
        {
            lock (this)
            {
                urlIndex = -1;
                foreach (var result in this.auxPageParseResults.Values)
                {
                    result.Finished = false;
                }

                foreach (var result in this.results.Values)
                {
                    result.Finished = false;
                }
            }
        }

        public AuxPageParseResult GetUnfinishedAuxPage()
        {
            lock (this)
            {
                foreach (var result in this.auxPageParseResults.Values)
                {
                    if (result.Finished == false)
                    {
                        return result;
                    }
                }
                return null;
            }
        }

        public bool AddAuxPage(AuxPageParseResult result)
        {
            lock (this)
            {
                if (this.auxPageParseResults.ContainsKey(result.BookName))
                {
                    return false;
                }
                this.auxPageParseResults[result.BookName] = result;
                return true;
            }
        }

        public AuxPageParseResult GetAuxPage(String bookName)
        {
            lock (this)
            {
                if (this.auxPageParseResults.ContainsKey(bookName))
                {
                    return this.auxPageParseResults[bookName];
                }
                return null;
            }
        }
    }
}
