namespace ridewithme.Service.Interfaces
{
    public interface IEmailService
    {
        public void SendingMessage(string message, int senderId, int recieverId);
        public void SendingObject<T>(T obj);
    }
}