using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class Operacion
    {
        //Encapsulación: private
        private int resultado;
        private int parametroUno, parametroDos;

        public int Resultado { get => resultado; set => resultado = value; } 

        public int ParametroUno { get => parametroUno; set => parametroUno = value; }

        public int ParametroDos { get => parametroDos; set => parametroDos = value; }



        public double multiplicacion(int ParametroUno, int ParametroDos)
        {
            this.Resultado = this.ParametroUno * this.ParametroDos;

            return this.Resultado;
        }
    }
}
