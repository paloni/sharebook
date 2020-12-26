using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;
using ShareBook.Domain.Services;

namespace ShareBook.WebApi.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService _bookService, ILogger<BooksController> _logger)
        {
            this._bookService = _bookService;
            this._logger = _logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDetails>> GetBooksByUser(string userId)
        {
            return await _bookService.GetBooksByUserAsync(userId);
        }
    }
}