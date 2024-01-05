using Autofac;
using BookStore.Domain.Dto_s;
using BookStore.Domain.Entities.Authors;
using BookStore.Domain.Features.AuthorService;
using BookStore.Domain.Features.BooksService;
using BookStore.Domain.Features.CategoryServices;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.Areas.Admin.Models
{
    public class InsertBookModel
    {
        private IBookManagementService _bookManagementService;
        private IAuthorManagementService _authorManagementService;
        private ICategoryManagementService _categoryManagementService;
        
        public CreateUpdateBookDto Book { get; set; }
        public InsertBookModel() { }
        public InsertBookModel(IBookManagementService bookManagementService, IAuthorManagementService authorManagementService,
            ICategoryManagementService categoryManagementService) 
        {
            _bookManagementService = bookManagementService;
            _authorManagementService = authorManagementService;
            _categoryManagementService = categoryManagementService;
        }

        internal async Task InsertBookAsync()
        {
            await _bookManagementService.InsertBookAsync(Book);
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _bookManagementService = scope.Resolve<IBookManagementService>();
            _authorManagementService = scope.Resolve<IAuthorManagementService>();
            _categoryManagementService = scope.Resolve<ICategoryManagementService>();
        }

        internal async Task<ICollection<Author>> GetAuthorsAsync()
        {
           return await _authorManagementService.GetAuthorsAsync();
        }
        
        internal async Task<ICollection<(Guid a, string name)>> GetCategoryAsync()
        {
           return await _categoryManagementService.GetCategoriesAsync();
        }
    }
}
