namespace MessageHandlerPipeline
{
    public interface IMessageHandlerPiepline<T>
    {
        MessageHandlerPipeline<T> Register(IMessageHandler<T> handler);
        void HandleMessage(T message);
    }
}