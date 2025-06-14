public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Each lap = 50 meters => convert to kilometers => convert to miles
        return (_laps * 50) / 1000.0 * 0.62;
    }

    public override double GetSpeed() => GetDistance() / LengthInMinutes * 60;

    public override double GetPace() => LengthInMinutes / GetDistance();
}
