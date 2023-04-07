using System;
using System.Collections.Generic;

namespace Persistance.Models;

public partial class Ticket
{
    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateTime? Departure { get; set; }

    public DateTime? Arrival { get; set; }

    public int? BookedBy { get; set; }

    public string? TravlerName { get; set; }

    public int TicketId { get; set; }
}
