using Core.Boundaries;
using Core.Model;
using Core.UseCases;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests.UseCases
{
    internal static class LoadLandingPageDataFacts
    {   
        [TestFixture]
        internal sealed class ConstructorMessage
        {
            [Test]
            public void WithNullTaskRepoShouldThrowException() {
                ITaskRepository taskRepo = null;
                ISystemInfoRepository sysInfoRepo = null;

                Assert.That(()=> new LoadLandingPageData(taskRepo, sysInfoRepo),
                    Throws.ArgumentNullException.With.Message.Contains("taskRepo"));
            }

            [Test]
            public void WithNullSysInfoRepoShouldThrowException()
            {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                ISystemInfoRepository sysInfoRepo = null;

                Assert.That(() => new LoadLandingPageData(taskRepo, sysInfoRepo),
                    Throws.ArgumentNullException
                          .With
                          .Message
                          .Contains("sysInfoRepo"));
            }

            [Test]
            public void WithAllDepdenciesNotNullShouldNotFail()
            {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                ISystemInfoRepository sysInfoRepo = Substitute.For<ISystemInfoRepository>();

                Assert.That(() => new LoadLandingPageData(taskRepo, sysInfoRepo),
                    Throws.Nothing);
            }
        }

        [TestFixture]
        internal sealed class GetDataMessage {
            [Test]
            public void WithOneUserAndNoTasks() {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                    taskRepo.GetTotalCount().Returns(0);
                    taskRepo.GetTasksFor(Arg.Any<User>())
                            .Returns(new HashSet<Core.Model.Task>());

                ISystemInfoRepository sysInfoRepo = Substitute.For<ISystemInfoRepository>();
                    sysInfoRepo.GetActiveUsers().Returns(1);

                LoadLandingPageData useCase = new LoadLandingPageData(taskRepo, sysInfoRepo);
                User theUser = new User{ Username = "lsolano" };

                LandingPageData data = useCase.GetData(theUser);

                Assert.That(data.ActiveUsers, Is.EqualTo(1));
                Assert.That(data.TotalTasks, Is.EqualTo(0));
                Assert.That(data.UserTasks, Has.Count.EqualTo(0));
            }
        }
    }
}
