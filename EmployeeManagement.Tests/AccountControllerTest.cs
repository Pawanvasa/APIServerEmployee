using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Api.Helper.Hashing;
using EmployeeManagement.Api.Helper.JWT;
using EmployeeManagement.Entities.Models.EntityModels;
using EmployeeManagment.Services.Account;
using EmployeeManagment.Services.EmailSending;
using EmployeeManagment.Services.SmsSending;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagement.Tests
{
    public class AccountControllerTests
    {
        private Mock<IAccountService> _accountServiceMock;
        private Mock<IJwtTokenGenrator> _tokenGenratorMock;
        private Mock<IHashingHelper> _hashMock;
        private Mock<IEmailSender> _emailSenderMock;
        private Mock<ISmsSender> _smsSenderMock;
        private AccountController _accountController;

        [SetUp]
        public void Setup()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _tokenGenratorMock = new Mock<IJwtTokenGenrator>();
            _hashMock = new Mock<IHashingHelper>();
            _emailSenderMock = new Mock<IEmailSender>();
            _smsSenderMock = new Mock<ISmsSender>();
            _accountController = new AccountController(
                _hashMock.Object,
                _tokenGenratorMock.Object,
                _accountServiceMock.Object,
                _emailSenderMock.Object,
                _smsSenderMock.Object
            );
        }

        [Test]
        public void Login_ReturnsBadRequest_WhenUserIsNotFound()
        {
            // Arrange
            var entity = new LoginModel();
            _accountServiceMock.Setup(x => x.GetUser(entity)).Returns((User)null!);

            // Act
            var result = _accountController.Login(entity);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }
    }
}