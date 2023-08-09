using Player;

namespace EventBus.Signals
{
    public class ChangePlayerStateSignal
    {
        public readonly PlayerState State;

        public ChangePlayerStateSignal(PlayerState state)
        {
            State = state;
        }
    }
}