using MessageHandlerPipeline;
using NUnit.Framework;

namespace NUnitLite.Tests
{
    public class FailingMessageHandler : IMessageHandler<TestStoppableMessage>
    {
        public void Handle(TestStoppableMessage message)
        {
            Assert.Fail("The message pipeline was not stopped correctly.");
        }
    }

    public class TestStoppableMessage : StoppableMessage
    {
    }
}