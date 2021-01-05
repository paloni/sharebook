using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;

namespace ShareBook.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("internetbooks")]
    public class InternetBooksController : ControllerBase
    {
        private readonly IEnumerable<IInternetBookService> internetBookServices;

        public InternetBooksController(IEnumerable<IInternetBookService> internetBookServices)
        {
            this.internetBookServices = internetBookServices;
        }
        [HttpGet]
        public async Task<IEnumerable<BookDetails>> Find([FromQuery] InternetBookSearchParams searchParams)
        {
            var result = new List<BookDetails>();
            foreach (var service in internetBookServices)
            {
                var books = await service.SearchAsync(searchParams);
                result.AddRange(books);
            }
            return result;
        }
    }
}