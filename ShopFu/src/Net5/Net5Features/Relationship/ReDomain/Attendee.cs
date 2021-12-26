namespace Net5Features.Relationship.ReDomain;

public class Attendee
{
    public int AttendeeId { get; set; }
    public string Name { get; set; }

    public OptionalTrack Optional { get; set; } //#B
    public RequiredTrack Required { get; set; } //#C
}

public enum TrackNames { NetCore = 0, EfCore = 1, AspNetCore = 3 }

public class OptionalTrack
{
    public int OptionalTrackId { get; set; }

    public TrackNames Track { get; set; }

    public Attendee Attend { get; set; }
}

public class RequiredTrack
{
    public int RequiredTrackId { get; set; }

    public TrackNames Track { get; set; }

    public Attendee Attend { get; set; }
}