using MessageHandlerPipeline.PipelineAspects;

namespace MessageHandlerPipeline
{
    public static class PipelineBuilder
    {
        public static IMessageHandlerPipeline<T> BuildBasicPipeline<T>()
        {
            return new MessageHandlerPipeline<T>();
        }

        public static IMessageHandlerPipeline<T> BuildTRansactionPipeline<T>()
        {
            return new TransactionPipelineDecorator<T>(BuildBasicPipeline<T>());
        }
    }
}