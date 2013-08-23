using System.Collections.Generic;

namespace MessageHandlerPipeline
{
    public interface IStoppableMessage
    {
        void StopMessageHandling(string reason);
        bool MessageHandlingStopped { get; }
        List<string> Errors { get; }
    }
}