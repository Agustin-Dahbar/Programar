using System;
using System.Runtime.Serialization;
using SondaIConstruye.Framework.Base.BaseDatos;
using SondaIConstruye.Framework.Base.Entidad;
//Referencias necesarias para que el código funcione

//Espacio donde residirá este código.
namespace SondaIConstruye.Framework.Entidad.Pli.NH
{
    [DataContract, Serializable] 
    //Estos atributos sugieren que la clase "Aclaratoria.cs" es serializable, lo que significa que sus instancias pueden convertirse en una secuencia de bytes para su almacenamiento o transmisión, profundización en el archivo markdown.
    public class Aclaratoria : DomainObject //DomainObject la clase de la que "Aclaratoria" hereda, que hereda a su vez de otra clase (AbstractEntity<long>), que herederá de una interfaz (IGenericEntity<TIdentity>) tendrá una propiedad y otra interfaz heredada: IEquatable<IGenericEntity<TIdentity>> 
    {

        public virtual Circular Circular { get; set; } //La aclaratoria tendra una circular.

        private string descripcion; //Variables que almacenarán la descripción
        private long numero;        //y el número de la aclaratoria.



        // Atributo que indicá que la propiedad se incluíra en la serialización de la instancia de clase 'Aclaratoria' cuando sea necesario.
        [DataMember] 
        public virtual string Descripcion 
        {
            get { return descripcion; } //Las propiedades en C# pueden tener metodos get y set asociados, controlan el acceso a la propiedad. Al agregar estos 
            set { descripcion = value; } // metodos se permite que las propiedades sean accesibles desde fuera de la clase para lectura y escritura.
        }

        [DataMember]
        public virtual long Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        //En C#, la palabra clave virtual se utiliza para indicar que un método o una propiedad puede ser sobrescrito en clases derivadas. Cuando se marca una propiedad como virtual, significa que las clases derivadas pueden anular la implementación de esa propiedad si lo desean.
        

        public Aclaratoria() 
        { }

        //Constructor de la clase. Creará los objetos al instanciarse la clase. (Debe tener el mismo nombre que la clase)
        public Aclaratoria(int id, string descripcion, long numero) 
        {
            base.Id = id; //Esta propiedad se heredá de AbstractEntity.cs (DomainObject hereda de ella, de ahí la conexión). (línea 15 de AbstractEntity.cs)
            this.descripcion = descripcion; //ambas variables de esta b  
            this.numero = numero;           //clase por eso el 'this.'
        }
    }
}
