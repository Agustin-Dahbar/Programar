// En la misma sección "Entidades" (carpeta) pero en otro proyecto "SondalConstruye.Framework.Enums".
// Los enumerados estarán dentro de clases. Y devolverán una opción entre las tantas disponibles haya entre , .
//Los siguientes enumerados los vimos referenciados en Circular.cs (crea las circulares) clase en Entidades-> Entidad.NH -> Pliego -> NH 
//Para que los enumerados de otro proyecto (biblioteca de clases) se puedan llamar se requiere la referencia al comienzo del archivo.
using SondaIConstruye.Framework.Enums;

//Los enumerados se encuentran en Entidades -> SondalConstruye.Framework.Enums -> Tipos.cs/Estados.cs
//Tipos.cs:
public enum TipoCircular
{
    Con_consulta = 1,
    Sin_consulta = 2
    //2 posibilidades para el return.
}

public enum TipoConceptoCircular
{
    Aclaratoria = 1,
    Ampliatoria = 2,
    Modificatoria = 3

    //3 posibilidades para el return.
}


//Estados.cs
public enum EstadoCircular
    {
    Ingresada = 0,
    Pendiente_De_Autorizar = 1,
    Eliminada = 2,
    Rechazada = 3,
    Aceptada = 4,
    Guardada = 5,
    Autorizada = 6
    }
        


//Código del Circular.cs donde llamamos a los enumerados del proyecto SondalConstruye.Framework.Enums mediante la creación de 3 propiedades que almacenarán solo uno de los tantos valores que ofrezcan los enumerados .
private EnuTipos.TipoCircular tipoCircular; 
private EnuEstados.EstadoCircular estadoCircular; 
private EnuTipos.TipoConceptoCircular tipoConcepto;

