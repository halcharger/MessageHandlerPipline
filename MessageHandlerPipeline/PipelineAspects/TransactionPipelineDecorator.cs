using System.Transactions;

namespace MessageHandlerPipeline.PipelineAspects
{
    public class TransactionPipelineDecorator<T> : IMessageHandlerPipeline<T>
    {
        private readonly IMessageHandlerPipeline<T> _handler;

        public TransactionPipelineDecorator(IMessageHandlerPipeline<T> handler)
        {
            _handler = handler;
        }

        public IMessageHandlerPipeline<T> Register(IMessageHandler<T> handler)
        {
            _handler.Register(handler);
            return this;
        }

        public void HandleMessage(T message)
        {
            using (var scope = new TransactionScope())
            {
                _handler.HandleMessage(message);
                scope.Complete();
            }
        }
    }
}