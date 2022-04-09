using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTicket.Core.Services;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;
using Moq;
using NUnit.Framework;

namespace CinemaTicket.Test
{
    [TestFixture]
    public class CategoryServiceTest
    {
        
        private Mock<IUnitOfWork> _repoMock;
        private CategoryService _categoryService;
        

        [SetUp]
        public void Setup()
        {
           
            _repoMock = new Mock<IUnitOfWork>();
            _categoryService = new CategoryService(
                _repoMock.Object);

        }


        [TestCase]
        public void GetAllCategories_InvokeMethod_CheckIfRepoIsCalled()
        {
            _categoryService.GetAllCategories();
            
        }
    }
}
