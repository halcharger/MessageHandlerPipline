using System.Collections.Generic;
using FluentAssertions;
using MessageHandlerPipeline;
using NUnit.Framework;

namespace NUnitLite.Tests
{
    [TestFixture]
    public class BasicMessagePipelineTests
    {
        [Test]
        public void MessageShouldBeHandledCorrectlyByEachHandlerSequentially()
        {
            var msg = new BasicMessage();
            var pipeline = PipelineBuilder.BuildBasicPipeline<BasicMessage>();

            pipeline.Register(new FirstMessageHandler())
                    .Register(new SecondMessageHandler())
                    .Register(new ThirdMessageHandler());

            pipeline.HandleMessage(msg);

            msg.FirstHandlerDone.Should().BeTrue();
            msg.SecondHandlerDone.Should().BeTrue();
            msg.ThirdHandlerDone.Should().BeTrue();

            msg.HandledBy.Count.Should().Be(3);
            msg.HandledBy[0].Should().Be("First");
            msg.HandledBy[1].Should().Be("Second");
            msg.HandledBy[2].Should().Be("Third");
        }
    }

    public class BasicMessage
    {
        public BasicMessage()
        {
            HandledBy = new List<string>();
        }
        public bool FirstHandlerDone { get; set; }
        public bool SecondHandlerDone { get; set; }
        public bool ThirdHandlerDone { get; set; }

        public List<string> HandledBy { get; set; } 
    }

    public class FirstMessageHandler : IMessageHandler<BasicMessage>
    {
        public void Handle(BasicMessage message)
        {
            message.FirstHandlerDone = true;
            message.HandledBy.Add("First");
        }
    }

    public class SecondMessageHandler : IMessageHandler<BasicMessage>
    {
        public void Handle(BasicMessage message)
        {
            message.SecondHandlerDone = true;
            message.HandledBy.Add("Second");
        }
    }

    public class ThirdMessageHandler : IMessageHandler<BasicMessage>
    {
        public void Handle(BasicMessage message)
        {
            message.ThirdHandlerDone = true;
            message.HandledBy.Add("Third");
        }
    }
}