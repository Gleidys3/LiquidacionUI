using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionContributivo : LiquidacionCuotaModeradora
    {
        const decimal SALARIOMINIMO = 828116;

        public override string CalcularCuotaModeradora(decimal salario, decimal valorServicio)
        {
            Salario = salario;
            const decimal CUOTAMODERADORABAJA = 250000;
            const decimal CUOTAMODERADORAMEDIA = 900000;
            const decimal CUOTAMODERADORAALTA = 15000000;

            if (salario>0 && salario<SALARIOMINIMO*2)
            {
                Tarifa = 0.15M;
                ValorServicio = valorServicio;
                ValorCuota = ValorServicio * Tarifa;
                if (ValorCuota > CUOTAMODERADORABAJA)
                {
                    ValorCuota = CUOTAMODERADORABAJA;
                    return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa} y Valor a pagar supero la cuota moderadora";
                }
                return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa}";
            }
            else if(salario>=SALARIOMINIMO*2 && salario<=SALARIOMINIMO*5)
            {
                Tarifa = 0.2M;
                ValorServicio = valorServicio;
                ValorCuota = ValorServicio * Tarifa;
                if (ValorCuota > CUOTAMODERADORAMEDIA)
                {
                    ValorCuota = CUOTAMODERADORABAJA;
                    return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa} y Valor a pagar supero la cuota moderadora";
                }
                return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa}";
            }
            else if(salario>SALARIOMINIMO*5)
            {
                Tarifa = 0.2M;
                ValorServicio = valorServicio;
                ValorCuota = ValorServicio * Tarifa;
                if (ValorCuota > CUOTAMODERADORAALTA)
                {
                    ValorCuota = CUOTAMODERADORAALTA;
                    return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa} y Valor a pagar supero la cuota moderadora";
                }
                return $" Total a pagar: {ValorCuota}, La tarifa aplicada es: {Tarifa}";
            }
            return "\n No se pudo calcular la cuota moderadora";
        }
        public override string ToString()
        {
            return $"Servicio {ValorServicio}, Salario {Salario}, Tarifa{Tarifa}, Cuota{ValorCuota}";
        }
    }
}
