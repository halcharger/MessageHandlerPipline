namespace MessageHandlerPipeline
{
    public interface IMessageHandler<T>
    {
        void Handle(T message);
    }
}