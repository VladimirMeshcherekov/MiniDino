namespace EventBus.Signals
{
    public class AddScoreToPlayerSignal
    {
        public readonly int ScoreValue;

        public AddScoreToPlayerSignal(int scoreValue)
        {
            ScoreValue = scoreValue;
        }
    }
}