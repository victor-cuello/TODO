using Core.Model;
using NUnit.Framework;

namespace Core.Tests.Model
{
    internal static class UserFacts
    {
        [TestFixture]
        internal sealed class EqualsMessage
        {
            [TestCase("LSOLANO", "lsolano")]
            [TestCase("  lsolano", "lsolano")]
            public void ShouldBeEquals(string usernameA, string usernameB) {
                User userA = new User{ Username = usernameA };
                User userB = new User { Username = usernameB };

                bool actual = userA.Equals(userB);

                Assert.That(actual, Is.True);
            }

            [TestCase("lsolano", "l.solano")]
            [TestCase("l solanom", "lsolano m")]
            public void ShouldNotBeEquals(string usernameA, string usernameB)
            {
                User userA = new User { Username = usernameA };
                User userB = new User { Username = usernameB };

                bool actual = userA.Equals(userB);

                Assert.That(actual, Is.False);
            }

            [TestCase("Hola mundo")]
            [TestCase(1)]
            [TestCase(null)]
            public void ShouldNotBeEqualsWithOtherTypes(object other) {
                User user = new User { Username = "lsolano" };

                bool actual = user.Equals(other);

                Assert.That(actual, Is.False);
            }

            [Test]
            public void ShouldNotBeEqualsToSelf()
            {
                User user = new User { Username = "lsolano" };

                bool actual = user.Equals(user);

                Assert.That(actual, Is.True);
            }
        }
    }
}
