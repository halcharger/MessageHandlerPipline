using System.Linq;
using FluentAssertions;
using MessageHandlerPipeline;
using NUnit.Framework;

namespace NUnitLite.Tests
{
    [TestFixture]
    public class StoppableMessagePipelineTests
    {
        [Test]
        public void StoppableMessagePipelineCorrectlyStopsMessageHandling()
        {
            var pipeline = PipelineBuilder.BuildStoppablePipeline<TestStoppableMessage>();

            pipeline.Register(new MessageHandlerThatStopsMessageHandling()).Register(new FailingMessageHandler());

            var msg = new TestStoppableMessage();

            pipeline.HandleMessage(msg);

            msg.Errors.Count.Should().Be(1);
            msg.Errors.First().Should().Be(MessageHandlerThatStopsMessageHandling.MessageStoppedReason);
        }
    }
}