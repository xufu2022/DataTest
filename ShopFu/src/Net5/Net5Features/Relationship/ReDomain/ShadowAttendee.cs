namespace Net5Features.Relationship.ReDomain;

public class ShadowAttendee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TicketOption1 TicketOption1 { get; set; }
    public TicketOption2 TicketOption2 { get; set; }

    public ICollection<ShadowAttendeeNote> Notes { get; set; }
}

public class ShadowAttendeeNote
{
    public int Id { get; set; }

    public string Note { get; set; }
}

public class TicketOption1
{
    public int TicketOption1Id { get; set; }

    public ShadowAttendee Attendee { get; set; }
}

public class TicketOption2
{
    public int TicketOption2Id { get; set; }

    public ShadowAttendee Attendee { get; set; }
}