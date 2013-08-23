namespace MessageHandlerPipeline
{
    public interface IMessageHandlerPipeline<T>
    {
        IMessageHandlerPipeline<T> Register(IMessageHandler<T> handler);
        void HandleMessage(T message);
    }
}