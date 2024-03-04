using System;
using System.Collections.Generic;

namespace Viajes.Server.Models;

public partial class Viaje
{
    public int IdViaje { get; set; }

    public string Destino { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Clima { get; set; } = null!;

    public int CodigoCiudad { get; set; }

    public int CodigoVehiculo { get; set; }

    public virtual Ciudade CodigoCiudadNavigation { get; set; } = null!;

    public virtual Vehiculo CodigoVehiculoNavigation { get; set; } = null!;
}
