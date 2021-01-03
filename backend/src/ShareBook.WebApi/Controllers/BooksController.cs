using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;
using ShareBook.Domain.Services;

namespace ShareBook.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        private readonly IInternetBookService _internetBookService;

        public BooksController(IBookService _bookService, IInternetBookService _internetBookService, ILogger<BooksController> _logger)
        {
            this._internetBookService = _internetBookService ?? throw new System.ArgumentNullException(nameof(_internetBookService));
            this._bookService = _bookService ?? throw new System.ArgumentNullException(nameof(_bookService));
            this._logger = _logger ?? throw new System.ArgumentNullException(nameof(_logger));
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<BookDetails>> GetBooksByUser(string userId)
        {
            return await _bookService.GetBooksByUserAsync(userId);
        }
        [HttpGet("isbn")]
        public async Task<IEnumerable<BookDetails>> Search(string isbn)
        {
            return await _internetBookService.SearchAsync(new InternetBookSearchParams() { Isbn = isbn });
        }
    }
}