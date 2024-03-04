export interface Viajes {
  idViaje: number,
  destino: string,
  fecha: Date,
  clima: string,
  CodigoVehiculo: Vehiculo
}

export interface Ciudad {
  IdCiudad: number,
  Nombre: string,
  Pais: string
}

export interface Vehiculo {
  idVehiculo: number,
  matricula: string,
  tipoVehiculo: string,
  marca: string,
  detalleVehiculo: string
}


