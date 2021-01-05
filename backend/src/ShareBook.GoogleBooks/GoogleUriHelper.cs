using System;
using ShareBook.Domain.Models;

namespace ShareBook.GoogleBooks
{
    public class GoogleUriHelper
    {
        private readonly InternetBookSearchParams _searchParams;
        private readonly string _apiKey;

        public GoogleUriHelper(InternetBookSearchParams searchParams, string apiKey)
        {
            this._apiKey = apiKey;
            this._searchParams = searchParams;
        }

        public string GetUri()
        {
            var uri = $"?q={_searchParams.Subject}";
            if (!String.IsNullOrEmpty(_searchParams.Isbn))
            {
                uri += $"+isbn:{_searchParams.Isbn}";
            }
            if (!String.IsNullOrEmpty(_searchParams.Title))
            {
                uri += $"+intitle:{_searchParams.Title}";
            }
            if (!String.IsNullOrEmpty(_searchParams.Author))
            {
                uri += $"+inauthor:{_searchParams.Author}";
            }
            if (!String.IsNullOrEmpty(_searchParams.Publisher))
            {
                uri += $"+inpublisher:{_searchParams.Publisher}";
            }

            return $"{uri}&key={_apiKey}";
        }
    }
}