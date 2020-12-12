using Christmas.Usecase;

namespace Christmas.Command
{
    public class GetMessageCommand
    {
        public string From { get; set; }
        
        public string To { get; set; }
        
        public string Body { get; set; }
    }
}