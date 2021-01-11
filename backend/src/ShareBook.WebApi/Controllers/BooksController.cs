using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IUserService _userService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, IUserService userService,
                             ILogger<BooksController> logger)
        {
            this._bookService = bookService ?? throw new System.ArgumentNullException(nameof(_bookService));
            this._userService = userService ?? throw new System.ArgumentNullException(nameof(userService));
            this._logger = logger ?? throw new System.ArgumentNullException(nameof(_logger));
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<BookDetails>> GetBooksByUser(string userId)
        {
            return await _bookService.GetBooksByUserAsync(userId);
        }

        [HttpPost]
        public async Task Add(BookDetails book)
        {
            book.OwnerId = await _userService.GetUserIdByName(this.User.Identity.Name);
            await _bookService.AddBookAsync(book);
        }

        private string GetUserId()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.First(c => c.Type == "jti").Value;
        }
    }
}