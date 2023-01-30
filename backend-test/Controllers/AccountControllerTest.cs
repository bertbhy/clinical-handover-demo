using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Resources;
using webapi.Controllers;
using webapi.Models;
using webapi.Services;
using Xunit;

namespace testapi.Controllers
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountService> _accountService;
        private readonly MockActiveDirectory _mockAD;
        public AccountControllerTest()
        {
            _accountService = new Mock<IAccountService>();
            _mockAD = new MockActiveDirectory();
        }

        [Fact]
        public async Task Login()
        {
            var user = _mockAD.persons[1];
            _accountService.Setup(s => s.Authenticate(user.sAMAccountName, user.password))
            .Returns(true);
            _accountService.Setup(s => s.FindOne(user.sAMAccountName))
            .Returns(user);
            _accountService.Setup(s => s.GenerateJwtToken(user.sAMAccountName))
            .Returns(Guid.NewGuid().ToString());
            var controller = new AccountController(_accountService.Object);
            var response = await controller.Login(new LoginRequest(){ Username = user.sAMAccountName, Password = user.password});
           
            Assert.IsType<OkObjectResult>(response.Result); 
            var value = (LoginResponse)((OkObjectResult)response.Result).Value;
            Assert.NotNull(value.token);
            Assert.True(user.sAMAccountName == value.person.sAMAccountName);
        }

        [Fact]
        public async Task Logout()
        {
            var controller = new AccountController(_accountService.Object);
            var response = await controller.Logout();
            Assert.IsType<NoContentResult>(response); 
        }
    }
}