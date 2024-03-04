using System;
using System.Collections.Generic;

namespace Viajes.Server.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string Matricula { get; set; } = null!;

    public string TipoVehiculo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string DetalleVehiculo { get; set; } = null!;

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
