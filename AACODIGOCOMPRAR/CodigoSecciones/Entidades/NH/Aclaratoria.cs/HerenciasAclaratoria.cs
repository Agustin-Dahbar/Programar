
namespace SondaIConstruye.Framework.Entidad.Pli.NH
{
    [DataContract, Serializable]
    public class Aclaratoria : DomainObject
    
}
                                                                    //DomainObject.cs FILE
                                                                     
// DomainObject la clase de la que "Aclaratoria" hereda, que hereda a su vez de otra clase que es pública y abstracta.
//Tocamos f12 para ver el archivo de DomainObject: 
namespace SondaIConstruye.Framework.Base.Entidad
{
    [Serializable]
    public class DomainObject : AbstractEntity<long>
    {
        
    }
}

//<long> es el argumento del AbstractEntity, tomará el valor del parametro tipo genérico 'TIdentity' de la clase 'AbstractEntity' (que veremos a continuación al presionar f12 en el). 





                                                                            // AbstractEntity.cs CLASE
//De aqui se hereda la propiedad Id que crea el constructor en Aclaratoria.cs la que es precedida de "base."
namespace SondaIConstruye.Framework.Base.Entidad
{
    [Serializable]
    public abstract class AbstractEntity<TIdentity> : IGenericEntity<TIdentity>
    {
        private int? requestedHashCode;

        #region IGenericEntity<TIdentity> Members

        public virtual TIdentity Id { get; set; }
        
    }
}
//  
//Analisis de línea
public abstract class AbstractEntity<TIdentity> : IGenericEntity<TIdentity>

<TIdentity> 
    // Este parámetro permite que la clase AbstractEntity sea parametrizada por un tipo concreto que representará la identidad de la entidad (objeto).
: IGenericEntity<TIdentity>
    //Agregar la interfaz IGenericEntity<TIdentity> proporciona una forma de definir un contrato común que todas las clases derivadas de AbstractEntity deben seguir. Esto es útil si deseas tener ciertas expectativas sobre cómo deben comportarse todas las entidades en tu sistema, independientemente del tipo específico de identidad que utilicen.




                                                                        //IGenericEntity.cs
//La interfaz de la que hereda AbstractEntity<TIdentity> devuelve una propiedad ID tipada como uno de los tantos valores posibles para <TIdentity>.
public interface IGenericEntity<TIdentity> : IEquatable<IGenericEntity<TIdentity>>
{
    TIdentity Id { get; } //Se declara la propiedad Id, será de lectura, ya que se le da un GET. Se espera que se haga un select sobre ella.
}





//Además hereda un "public interface" de IEquatable. Este interface puede determinar si dos objetos del mismo tipo son iguales.
public interface IEquatable<T>
{
    [__DynamicallyInvokable]
    bool Equals(T other);
}
// Resumen:
//   Indica si el objeto actual es igual que otro objeto del mismo tipo.

// Parámetros:
//  other:
//     Objeto que se va a comparar con este objeto.

// Devuelve:
//     true si el objeto actual es igual al parámetro other; en caso contrario, false.


// La ruta de herencia final es: 
Aclaratoria -> DomainObject -> AbstractEntity<long> -> IGenericEntity<TIdentity> -> IEquatable<IGenericEntity<TIdentity>>
