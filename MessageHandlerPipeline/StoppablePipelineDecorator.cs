namespace MessageHandlerPipeline
{
    public class StoppablePipelineDecorator<T> : MessageHandlerPipeline<T> where T : IStoppableMessage
    {
        public override void HandleMessage(T message)
        {
            _handlers.ForEach(h => { if (!message.MessageHandlingStopped) h.Handle(message); });
        }
    }
}