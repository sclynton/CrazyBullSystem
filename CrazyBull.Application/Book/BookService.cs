using CrazyBull.Core;
using System;
using System.Threading.Tasks;

namespace CrazyBull.Application
{
    public class BookService : IAppService
    {
        private IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> InsertBook(InsertBookInputDto bookDto)
        {
            return await _bookRepository.InsertAsync(new Book());
        }
    }
}
