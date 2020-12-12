using Christmas.Usecase;
using NUnit.Framework;

namespace Christmas.Test.Usecase
{
    public class GetMessageUsecaseTest
    {
        [Test]
        public void ItSaysHi()
        {
            var usecase = new GetMessageUsecase();
            var actual = usecase.Execute();

            Assert.That(actual, Is.EqualTo("Hello world!"));
        }
    }
}