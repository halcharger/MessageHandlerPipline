using System.Collections.Generic;

namespace MessageHandlerPipeline
{
    public class StoppableMessage : IStoppableMessage
    {
        public void StopMessageHandling(string reason)
        {
            MessageHandlingStopped = true;

            if (Errors == null) Errors = new List<string>();

            Errors.Add(reason);
        }

        public bool MessageHandlingStopped { get; private set; }
        public List<string> Errors { get; private set; }
    }
}