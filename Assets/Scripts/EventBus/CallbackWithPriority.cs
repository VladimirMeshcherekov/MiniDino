namespace EventBus
{
    public class CallbackWithPriority
    {
        /// <summary>
        /// The higher the Priority, the earlier the event will be called
        /// </summary>
       // public readonly int Priority;
        public readonly object Callback;
        public readonly int Priority;

        public CallbackWithPriority(int priority, object callback)
        {
            Priority = priority;
            Callback = callback;
        }
    }
}
