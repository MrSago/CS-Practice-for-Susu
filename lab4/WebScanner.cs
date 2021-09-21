
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace lab4
{
    class WebScanner : IDisposable
    {
        private readonly WebClient _webClient = new();
        private readonly HashSet<Uri> _procLinks = new();
        private readonly HashSet<string> _ignoreFiles = new()
            { ".pdf", ".xml", ".doc", ".docx" };
        private string _domain;
        private int _pageCount;
        private int _maxLevel;

        public delegate void EFound(Uri uri, IEnumerable<string> list); 
        public event EFound EmailsFound;

        private void OnEmailsFound(Uri page, ref HashSet<string> emails)
        {
            EmailsFound?.Invoke(page, emails);
        }

        private void Process(Uri page)
        {
            if (_pageCount <= 0 || _procLinks.Contains(page))
            {
                return;
            }
            _procLinks.Add(page);

            string html = _webClient.DownloadString(page);

            HashSet<string> emails = new();
            foreach (Match email in Regex.Matches(html, @"([-\w]+\[dot\])*[-\w]+\[at\][-\w]+(\[dot\][-\w]+)+").Cast<Match>())
            {
                string e = email.Value.Replace("[at]", "@").Replace("[dot]", ".");
                emails.Add(e);
            }
            if (emails.Count > 0)
            {
                --_pageCount;
                OnEmailsFound(page, ref emails);
            }

            var hrefs =
                (
                    from href in Regex.Matches(html, @"href=""https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)""").Cast<Match>()
                    let url = href.Value.Replace("href=", "").Trim('"')
                    let loc = url.StartsWith("/")
                    select new
                    {
                        Ref = new Uri(loc ? $"{_domain}{url}" : url),
                        IsLocal = loc || url.StartsWith(_domain)
                    }
                ).ToList();

            Uri[] locals = 
                (
                    from href in hrefs
                    where href.IsLocal
                    select href.Ref
                ).ToArray();

            foreach (Uri href in locals)
            {
                string fileEx = Path.GetExtension(href.LocalPath).ToLower();
                int level = href.AbsolutePath.Count(f => f == '/') - 1;
                if (!_ignoreFiles.Contains(fileEx) && level <= _maxLevel)
                {
                    Process(href);
                }
            }
        }

        public void Scan(Uri startPage, int pageCount, int maxLevel = int.MaxValue)
        {
            _domain = $"{startPage.Scheme}://{startPage.Host}";
            _pageCount = pageCount;
            _maxLevel = maxLevel;
            _procLinks.Clear();
            Process(startPage);
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}

