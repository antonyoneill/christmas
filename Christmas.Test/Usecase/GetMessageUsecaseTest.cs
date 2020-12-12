using AutoFixture;
using Christmas.Command;
using Christmas.Usecase;
using NUnit.Framework;

namespace Christmas.Test.Usecase
{
    public class GetMessageUsecaseTest
    {
        [Test]
        public void ItSaysHiToTheSender()
        {
            var command = new Fixture().Build<GetMessageCommand>().With(x => x.From, "Albie").Create();
            var usecase = new GetMessageUsecase();
            var actual = usecase.Execute(command);

            Assert.That(actual, Is.EqualTo($"Hello Albie!"));
        }
    }
}