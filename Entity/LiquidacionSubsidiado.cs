using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionSubsidiado : LiquidacionCuotaModeradora
    {
        public const decimal CUOTAMODERADORA = 200000;

        public override string CalcularCuotaModeradora(decimal salario, decimal valorServicio)
        {
            Tarifa = 0.5M;
            ValorServicio = valorServicio;
            ValorCuota = ValorServicio * Tarifa;
            if (ValorCuota > 200000)
            {
                ValorCuota = CUOTAMODERADORA;
                return $" Valor cuota moderadora: {ValorCuota}, la cuota sobre paso el valor maximo";
            }
            return $" Valor cuota moderadora: {ValorCuota}";
        }

        public override string ToString()
        {
            return $"Servicio {ValorServicio}, Salario {Salario}, Tarifa{Tarifa}, Cuota{ValorCuota}";
        }
    }
}
