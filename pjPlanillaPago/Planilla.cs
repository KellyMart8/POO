using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPlanillaPago
{
    public class Planilla
    {
        //Atributos
        public string empleado { get; set; }    //se encapsula
        public string cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int años { get; set; }

        //Metodos
        public int añosServiocio()
        {
            return DateTime.Now.Year - FechaIngreso.Year;
        }

        //Año consultado en letras
        public string mesConsultado()
        {
            int mes = DateTime.Now.Month;
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";

            }
            return " ";
        }
        //Determinar el sueldo basico

        public double DeterminaBasico()
        {
            switch (cargo)
            {
                case "Coordinador": return 2000;        //No se usa brak porque ya esta el return
                case "Jefe": return 4000;
                case "Capacitador": return 2500;
                case "Asistente": return 1200;
            }
            return 0;
        }

        //Determina l¿el monto de gratificacion
        public double DeterminaGratificacion()
        {
            if (mesConsultado() == "Abril")
                return 400;
            else if (mesConsultado() == "Julio")
                return 450;
            else if (mesConsultado() == "Diciembre")
                return DeterminaBasico() * 2;
            return 0;
        }

        //Determinar el monto de comision
        public double DeterminaComision()
        {
            if (cargo == "Asistente")
                return 100;
            else if (cargo == "Coordinador")
                return 250;
            return 0;
        }

        //Determinando el monto de descuento por ahorro de cooperativa
        public double DeterminarDescuentoCooperativa()
        {
            if (cargo == "Jefe")
                return 5.0 / 100 * DeterminaBasico();
            else if (cargo == "Capacitador")
                return 2.0 / 100 * DeterminaBasico();
            return 0;
        }

        //Determinar aportacion al seguro social
        public double DeterminaAportacionSeguro()
        {
            return 0.07 * DeterminaBasico();
        }

        //Calcular Montos Totales
        public double CalculaTotalIngresos()
        {
            return DeterminaBasico() + DeterminaGratificacion() + DeterminaComision();
        }

        public double CalcularTotalDescuentos()
        {
            return DeterminarDescuentoCooperativa();
        }

        public double CalcularTotalAportaciones()
        {
            return DeterminaAportacionSeguro();
        }

        //Determinar el Monto neto del empleado
        public double DeterminaNeto()
        {
            return CalculaTotalIngresos() - CalcularTotalDescuentos() - CalcularTotalAportaciones();
        }
    }
}
