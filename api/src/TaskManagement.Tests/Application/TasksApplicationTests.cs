using Flurl.Http.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.Implmentation;
using TaskManagement.Domain.Repository;
using Xunit;

namespace TaskManagement.Tests.Application
{
    public class TasksApplicationTests
    {

        [Fact]
        public void GetInstance_OK()
        {
            var moqRepo = new Mock<ITaskRepository>();
            var instance = new TasksApplication(moqRepo.Object);

            Assert.NotNull(instance);
        }

        [Fact]
        public void GetById_OK()
        {
            var moqId = new Random().Next();
            var dummyObject = new Domain.Entities.Task
            {
                Id = moqId,
                Name = "Test Name",
                Status = Domain.Aggregation.TaskStatus.Open,
                TimeStamp = DateTime.Now
            };

            var moqRepo = new Mock<ITaskRepository>();
            moqRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(dummyObject);

            var instance = new TasksApplication(moqRepo.Object);
            var result = instance.GetTaskById(moqId).GetAwaiter().GetResult();

            Assert.NotNull(instance);
            Assert.NotNull(result);
            Assert.Equal(dummyObject.Name, result.Name);
            Assert.Equal(dummyObject.Status, result.Status);
        }

        [Fact]
        public void GetById_NotOK()
        {
            var moqId = new Random().Next();
            var dummyObject = new Domain.Entities.Task
            {
                Id = moqId,
                Name = "Test Name",
                Status = Domain.Aggregation.TaskStatus.Open,
                TimeStamp = DateTime.Now
            };

            var moqRepo = new Mock<ITaskRepository>();
            moqRepo.Setup(x => x.GetByID(moqId)).Returns(dummyObject);

            var instance = new TasksApplication(moqRepo.Object);
            var result = instance.GetTaskById(0).GetAwaiter().GetResult();

            Assert.NotNull(instance);
            Assert.Null(result);

        }

        [Fact]
        public void UpateTask()
        {
            var expectResponse = new KeyValuePair<bool, string>(true, "");
            var moqId = new Random().Next();
            var moqName = "Test Name";
            var dummyObject = new Domain.Entities.Task
            {
                Id = moqId,
                Name = moqName,
                Status = Domain.Aggregation.TaskStatus.Open,
                TimeStamp = DateTime.Now
            };

            var moqRepo = new Mock<ITaskRepository>();
            moqRepo.Setup(x => x.Update(dummyObject)).Returns(1);

            using (var http = new HttpTest())
            {
                http.RespondWithJson(new { isUnique = true }, 200);

                var instance = new TasksApplication(moqRepo.Object);
                var result = instance.UpdateTask(dummyObject).GetAwaiter().GetResult();

                Assert.NotNull(instance);
                Assert.True(result.Key);
                http.ShouldHaveCalled($"http://taskmanagement.externalservice/api/check/{moqName}").Times(1);
            }
        }
    }
}
