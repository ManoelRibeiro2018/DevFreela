using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core
{
    public class UserTests 
    {
        [Fact]
        public void TestIsExistUser()
        {
            var user = new User("fullName", "teste@gmail.com", DateTime.Now, "123456", "admin");

            Assert.NotNull(user.FullName);
            Assert.NotNull(user.Email);
            Assert.NotNull(user.Role);
        }
    }
}
