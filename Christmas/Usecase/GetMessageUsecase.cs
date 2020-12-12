using Christmas.Command;

namespace Christmas.Usecase
{
    public class GetMessageUsecase
    {
        public string Execute(GetMessageCommand command)
        {
            return $"Hello {command.IncomingMessage.From}!";
        }
    }
}