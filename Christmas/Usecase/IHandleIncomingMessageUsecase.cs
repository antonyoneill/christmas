using Christmas.Command;

namespace Christmas.Usecase
{
    public interface IHandleIncomingMessageUsecase
    {
        public void Execute(HandleIncomingMessageCommand command);
    }
}