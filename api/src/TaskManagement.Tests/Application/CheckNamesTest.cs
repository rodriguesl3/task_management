using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Repository;
using TaskManagement.ExternalService.Services;
using Xunit;

namespace TaskManagement.Tests.Application
{
    public class CheckNamesTest
    {
        [Fact]
        public void GetInstanceOK()
        {
            var moqRepo = new Mock<IExternalTasksRepository>();
            var instance = new CheckNameService(moqRepo.Object);

            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData("print my CV")]
        [InlineData("")]
        [InlineData("this is a name test")]
        public void IsUniqueName_True(string name)
        {
            var moqRepo = new Mock<IExternalTasksRepository>();
            moqRepo.Setup(x => x.IsUniqueName(name)).Returns(Task.FromResult(true));


            var instance = new CheckNameService(moqRepo.Object);

            var result = instance.IsUniqueName(name).GetAwaiter().GetResult();

            Assert.NotNull(instance);
            Assert.True(result);
        }
    }
}
