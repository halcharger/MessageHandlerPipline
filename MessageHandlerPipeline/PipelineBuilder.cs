using MessageHandlerPipeline.PipelineAspects;

namespace MessageHandlerPipeline
{
    public static class PipelineBuilder
    {
        public static IMessageHandlerPipeline<T> BuildBasicPipeline<T>()
        {
            return new MessageHandlerPipeline<T>();
        }

        public static IMessageHandlerPipeline<T> BuildTransactionPipeline<T>()
        {
            return new TransactionPipelineDecorator<T>(BuildBasicPipeline<T>());
        }

        public static IMessageHandlerPipeline<T> BuildStoppablePipeline<T>() where T : IStoppableMessage
        {
            return new StoppableMessagePipeline<T>();
        }
    }
}