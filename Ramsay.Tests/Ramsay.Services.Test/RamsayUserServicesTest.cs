using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Models.Interfaces.Repositories;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;
using Xunit;

namespace Ramsay.Services.Test
{
    public class RamsayUserServicesTest
    {
        [Fact]
        public void GetAllUsersCount()
        {
            var userRepository = new Mock<IRepository<IdentityUser>>();
            userRepository.Setup(r => r.All()).Returns(new List<IdentityUser>
            {
                new IdentityUser()

            }.AsQueryable());

            var services = new RamsayUsers(userRepository.Object);
            Assert.Equal(1, services.getCount());
            userRepository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void GetCountShouldReturnsCorrectNumber()
        {
            var receiptRepository = new Mock<IRepository<Receipt>>();
            receiptRepository.Setup(r => r.All()).Returns(new List<Receipt>
            {
                new Receipt()
               
            }.AsQueryable());
            var service = new RamsayReceiptCountServices(receiptRepository.Object);
            Assert.Equal(1, service.getCount());
            receiptRepository.Verify(x => x.All(), Times.Once);
        }
    }
}
