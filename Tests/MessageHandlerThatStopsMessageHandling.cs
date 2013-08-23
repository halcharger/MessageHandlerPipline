using MessageHandlerPipeline;

namespace NUnitLite.Tests
{
    public class MessageHandlerThatStopsMessageHandling : IMessageHandler<TestStoppableMessage>
    {
        public const string MessageStoppedReason = "This is a test to stop message handling";

        public void Handle(TestStoppableMessage message)
        {
            message.StopMessageHandling(MessageStoppedReason);
        }
    }
}