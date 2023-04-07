using System;
using System.Collections.Generic;

namespace Persistance.Models;

public partial class Route
{
    public string? Origin { get; set; }

    public string? Destinations { get; set; }

    public int RouteId { get; set; }
}
