using System.Collections.Generic;

namespace MessageHandlerPipeline
{
    public class MessageHandlerPipeline<T>
    {
        private readonly List<IMessageHandler<T>> _handlers = new List<IMessageHandler<T>>();

        public MessageHandlerPipeline<T> Register(IMessageHandler<T> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public void HandleMessage(T message)
        {
            _handlers.ForEach(h => h.Handle(message));
        }

    }
}