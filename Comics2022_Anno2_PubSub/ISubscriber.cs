namespace Comics2022_Anno2_PubSub
{
    public interface ISubscriber
    {
        void OnPublish(MessageType messageType, IMessage message);
    }
}