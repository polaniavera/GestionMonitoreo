SELECT r.IdRegistro
      ,r.IdUsuario
      ,r.IdItem
      ,r.Latitud
      ,r.Longitud
      ,r.TanqueConductor
      ,r.TanquePasajero
      ,r.Kilometraje
      ,r.Velocidad
      ,r.BotonPanico
      ,r.Fecha
      ,r.Hora
FROM registro r
JOIN (
		SELECT idUsuario, idItem, MAX(CONVERT(DATETIME, CONVERT(CHAR(8), fecha, 112) + ' ' + CONVERT(CHAR(8), hora, 108))) tiempo
		FROM registro
		WHERE (idUsuario = 1)
		GROUP by idUsuario, idItem
	) aux
ON CONVERT(DATETIME, CONVERT(CHAR(8), r.fecha, 112) + ' ' + CONVERT(CHAR(8), r.hora, 108)) = aux.tiempo