//Referencias para que el proyecto funcione.
using SondaIConstruye.Framework.Base.Entidad;
using SondaIConstruye.Framework.Entidad.Base.NH;
using SondaIConstruye.Framework.Entidad.Evaluacion.NH;
using SondaIConstruye.Framework.Entidad.NH.Expediente;
using SondaIConstruye.Framework.Entidad.NH.RIUPP;
using SondaIConstruye.Framework.Entidad.NH.SG;
using SondaIConstruye.Framework.Entidad.NH.Subasta;
using SondaIConstruye.Framework.Entidad.NH.TareasProcesos;
using SondaIConstruye.Framework.Entidad.Parametros.NH;
using SondaIConstruye.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace SondaIConstruye.Framework.Entidad.Pli.NH //Espacio donde se deben encontrar códigos que interactúen entre sí.
{
    [DataContract, Serializable] // Estos atributos [DataContract] y [Serializable] son atributos de metadatos que proporcionan información adicional sobre cómo debe serializarse y tratarse la clase.
    public class Circular : DomainObject, IConcurrentAware, IProcesable
    {
        private static int NUMERO_INICIAL_CIRCULAR = 1;
        private long concurrentVersion;
        private Pliego pliego;
        private EnuTipos.TipoCircular tipoCircular; //Objeto que determina el tipo de circular, se encuentra en el proyecto "Sondal..Enums" de esta sección. 
        private EnuEstados.EstadoCircular estadoCircular; // Lo mismo pero en otra clase que el caso anterior.
        private EnuTipos.TipoConceptoCircular tipoConcepto; //Misma clase que el primer caso pero diferente Enumerado con diferentes opciones.
        private string motivo;
        private string motivoEliminacion;
        private DateTime fechaCreacion;
        private DateTime fechaPublicacion;
        private EvaluadoresConsiderados evaluadoresConsiderados;

        public virtual IList<Evaluador> Evaluadores { get; set; } //Listas de evaludores e índices asociados a la Circular.
        public virtual IList<CircularIndice> Indices { get; set; }
        public virtual DatosPublicacionBORA DatosPublicacionBORA { get; set; } //Datos de la publicación. Objeto de otra clase.

        public virtual void AddIndice(CircularIndice indice)
        {
            if (Indices == null)
                Indices = new List<CircularIndice>();
            indice.Circular = this;
            Indices.Add(indice);
        }
        [DataMember] //Estos atributos [DataMember] son específicos del serializador de WCF y se utilizan para indicar que estas propiedades deben ser incluidas durante la serialización de la clase. Las propiedades que no lo tengan, no se incluíran en la serialización.
        public virtual long ConcurrentVersion
        {
            get { return this.concurrentVersion; }
            set { this.concurrentVersion = value; }
        }
        [DataMember]
        public virtual Pliego Pliego
        {
            get { return pliego; }
            set { pliego = value; }
        }

        [DataMember]
        public virtual string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        private PliegoCondicion condicionPliego;

        public virtual PliegoCondicion CondicionPliego
        {
            get { return condicionPliego; }
            set
            {
                condicionPliego = value;
                if (condicionPliego != null)
                    condicionPliego.Circular = this;
            }
        }


        [DataMember]
        public virtual string MotivoEliminacion
        {
            get { return motivoEliminacion; }
            set { motivoEliminacion = value; }
        }


        [DataMember]
        public virtual DateTime FechaPublicacion
        {
            get { return fechaPublicacion; }
            set { fechaPublicacion = value; }
        }

        [DataMember]
        public virtual EvaluadoresConsiderados EvaluadoresConsiderados
        {
            get { return evaluadoresConsiderados; }
            set { this.evaluadoresConsiderados = value; }
        }

        public virtual IList<MedioDifusion> MediosDifusion { get; set; }

        public virtual void AddMedioDifusion(MedioDifusion medio)
        {
            if (this.MediosDifusion == null)
                this.MediosDifusion = new List<MedioDifusion>();

            medio.Circular = this;
            this.MediosDifusion.Add(medio);
        }

        [DataMember]
        public virtual IList<Aclaratoria> Aclaratorias { get; set; }

        public virtual void AddAclaratoria(Aclaratoria aclaratoria)
        {
            if (Aclaratorias == null)
                Aclaratorias = new List<Aclaratoria>();

            aclaratoria.Circular = this;
            this.Aclaratorias.Add(aclaratoria);
        }

        [DataMember]
        public virtual IList<ConsultasProveedor> ConsultasProveedor { get; set; }

        public virtual void AddConsultaProveedor(ConsultasProveedor consultaProveedor)
        {
            if (ConsultasProveedor == null)
                ConsultasProveedor = new List<ConsultasProveedor>();

            consultaProveedor.Pliego = this.Pliego;
            this.ConsultasProveedor.Add(consultaProveedor);
        }

        [DataMember]
        public virtual IList<RespuestaProveedor> RespuestasProveedor { get; set; }

        public virtual void AddRespuestaProveedor(RespuestaProveedor respuestaProveedor)
        {
            if (RespuestasProveedor == null)
                RespuestasProveedor = new List<RespuestaProveedor>();

            respuestaProveedor.Circular = this;
            this.RespuestasProveedor.Add(respuestaProveedor);
        }

        [DataMember]
        public virtual IList<Base.NH.ActoAdministrativo> ActosAdministrativos { get; set; }

        [DataMember]
        public virtual DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        [DataMember]
        public virtual EnuTipos.TipoCircular TipoCircular
        {
            get { return tipoCircular; }
            set { tipoCircular = value; }
        }

        [DataMember]
        public virtual EnuEstados.EstadoCircular EstadoCircular
        {
            get { return estadoCircular; }
            set { estadoCircular = value; }
        }

        [DataMember]
        public virtual EnuTipos.TipoConceptoCircular TipoConcepto
        {
            get { return tipoConcepto; }
            set { tipoConcepto = value; }
        }

        private PliegoInformacionBasica informacionBasica;

        [DataMember]
        public virtual PliegoInformacionBasica InformacionBasica
        {
            get { return informacionBasica; }
            set
            {
                informacionBasica = value;
                if (informacionBasica != null)
                    informacionBasica.Circular = this;
            }
        }

        private PliegoDatosParticulares datosParticulares;

        public virtual PliegoDatosParticulares DatosParticulares
        {
            get { return datosParticulares; }
            set
            {
                datosParticulares = value;
                if (datosParticulares != null)
                    datosParticulares.Circular = this;

            }
        }

        private PliegoCronograma cronograma;

        [DataMember]
        public virtual PliegoCronograma Cronograma
        {
            get { return cronograma; }
            set
            {
                cronograma = value;
                if (cronograma != null)
                    cronograma.Circular = this;
            }
        }

        [DataMember]
        public virtual IList<Requisito> Requisitos { get; set; }

        public virtual void AddRequisito(Requisito requisito)
        {
            requisito.Circular = this;
            this.Requisitos.Add(requisito);
        }

        [DataMember]
        public virtual IList<Clausula> Clausulas { get; set; }

        public virtual void AddClausula(Clausula clausula)
        {
            clausula.Circular = this;
            this.Clausulas.Add(clausula);
        }

        [DataMember]
        public virtual IList<PliegoGarantia> Garantias { get; set; }

        public virtual void AddGarantia(PliegoGarantia garantia)
        {
            garantia.Circular = this;
            this.Garantias.Add(garantia);
        }

        private InformacionContrato informacionContrato;

        [DataMember]
        public virtual InformacionContrato InformacionContrato
        {
            get { return informacionContrato; }
            set
            {
                informacionContrato = value;
                if (informacionContrato != null)
                    informacionContrato.Circular = this;
            }
        }

        [DataMember]
        public virtual IList<Penalidad> Penalidades { get; set; }

        public virtual void AddPenalidad(Penalidad penalidad)
        {
            penalidad.Circular = this;
            this.Penalidades.Add(penalidad);
        }

        [DataMember]
        public virtual int NumeroCircular { get; set; }

        private SubastaInversa informacionSubasta;

        [DataMember]
        public virtual SubastaInversa InformacionSubasta
        {
            get { return informacionSubasta; }
            set
            {
                informacionSubasta = value;
                if (informacionSubasta != null)
                    informacionSubasta.Circular = this;
            }
        }

        private SubastaPublica informacionSubastaPublica;

        [DataMember]
        public virtual SubastaPublica InformacionSubastaPublica
        {
            get { return informacionSubastaPublica; }
            set
            {
                informacionSubastaPublica = value;
                if (informacionSubastaPublica != null)
                    informacionSubastaPublica.Circular = this;
            }
        }

        [DataMember]
        public virtual IList<CircularActoAdministrativo> ActosAdministrativosAutorizacion { get; set; }

        public virtual void Accept(IProcesadorDocumento visitor, long idTarea)
        {
            visitor.ProcesarDocumento(this, idTarea);
        }

        public Circular()
        {
            this.TipoCircular = EnuTipos.TipoCircular.Con_consulta;
            this.EstadoCircular = EnuEstados.EstadoCircular.Ingresada;
            this.TipoConcepto = EnuTipos.TipoConceptoCircular.Aclaratoria;
            this.Motivo = string.Empty;
            this.Aclaratorias = null;
            this.RespuestasProveedor = null;
            this.Penalidades = new List<Penalidad>();
            this.Garantias = new List<PliegoGarantia>();
            this.Clausulas = new List<Clausula>();
            this.Requisitos = new List<Requisito>();
            this.Indices = new List<CircularIndice>();
            this.MediosDifusion = new List<MedioDifusion>();
            this.Aclaratorias = new List<Aclaratoria>();
            this.ActosAdministrativos = new List<ActoAdministrativo>();
            this.ConsultasProveedor = new List<ConsultasProveedor>();
            this.RespuestasProveedor = new List<RespuestaProveedor>();
            this.ActosAdministrativosAutorizacion = new List<CircularActoAdministrativo>();
        }
    }
}