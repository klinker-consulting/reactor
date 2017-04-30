namespace Reactor.Core.Actions
{
    public interface IAction
    {
    }

    public class EmptyAction : IAction
    {
        
    }

    public interface IAction<out TPayload> : IAction
    {
        TPayload Payload { get; }
    }

    public class Action<TPayload> : IAction<TPayload>
    {
        public TPayload Payload { get; }

        public Action(TPayload payload)
        {
            Payload = payload;
        }
    }
}
