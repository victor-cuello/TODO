using Core.Model;
using NUnit.Framework;

namespace Core.Tests.Model
{
    internal static class TaskFacts
    {
        [TestFixture]
        internal sealed class EqualsMessage
        {
            [TestCase("COMPRAR AGUA", "comprar agua")]
            [TestCase("  Comprar Agua  ", "comprar Agua")]
            public void ShouldBeEquals(string tareaA, string tareaB)
            {
                Task TareaA = new Task { Title = tareaA };
                Task TareaB = new Task { Title = tareaB };

                bool actual = TareaA.Equals(TareaB);

                Assert.That(actual, Is.True);
            }

            
            [TestCase("Comprar Agua")]
            public void TitleLengthShouldNotExceedMaximunLimit(string tareaA)
            {
                Task TareaA = new Task { Title = tareaA };

                bool actual = TareaA.GetLength(TareaA);

                Assert.That(actual, Is.True);
            }

            [TestCase("laklskjakjspkasj;lasjkkajskajsasjasj'asjasjaklsjasjaj'asjkasjkasja")]
            public void TitleLengthExceedMaximunLimit(string tareaA)
            {
                Task TareaA = new Task { Title = tareaA };

                Assert.That(() => TareaA.GetLength(TareaA), Throws.ArgumentException.With.Message.Contains("Title Too Long"));
            }

            [TestCase("")]
            public void TitleIsEmpty(string tareaA)
            {
                Task TareaA = new Task { Title = tareaA };

                Assert.That(() => TareaA.GetLength(TareaA), Throws.ArgumentException.With.Message.Contains("Title Too Long"));
            }
        }
    }
}
