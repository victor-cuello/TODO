using Core.Model;
using Core.UseCases;
using NUnit.Framework;

namespace Core.Tests.UseCases
{
    internal static class CreateTaskFacts
    {
       [TestFixture]
        internal sealed class savetaskconstructor
        {
            [Test]
            public void TitleEmpty()
            {
                Task NewTask = new Task { Title = "",
                        UserName = "",
                        InitialDate = System.DateTime.Now,
                        EndDate = System.DateTime.Now,
                        Message =""};

                Assert.That(() => CreateTask.Save(NewTask), Throws.ArgumentException.With.Message.Contains("Title cannot be empty"));
            }
        }       
    }   
}
