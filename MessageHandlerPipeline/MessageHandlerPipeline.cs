using System.Collections.Generic;

namespace MessageHandlerPipeline
{
    public class MessageHandlerPipeline<T> : IMessageHandlerPipeline<T>
    {
        protected readonly List<IMessageHandler<T>> _handlers = new List<IMessageHandler<T>>();

        public virtual IMessageHandlerPipeline<T> Register(IMessageHandler<T> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public virtual void HandleMessage(T message)
        {
            _handlers.ForEach(h => h.Handle(message));
        }

    }
}