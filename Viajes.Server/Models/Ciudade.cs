using System;
using System.Collections.Generic;

namespace Viajes.Server.Models;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
