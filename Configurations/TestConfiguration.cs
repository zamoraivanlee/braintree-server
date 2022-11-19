namespace BraintreeServer.Configurations;

public class TestConfiguration
{
    public TestAmount[] Amounts { get; set; } = new TestAmount[] { };
    public TestCard[] Cards { get; set; } = new TestCard[] { };
}

public class TestAmount
{
    public float RangeFloor { get; set; }
    public float? RangeCeiling { get; set; }
    public bool Authorized { get; set; }
}

public class TestCard
{
    public string Type { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
}
