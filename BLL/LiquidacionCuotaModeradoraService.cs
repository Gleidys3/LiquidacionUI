using System.Collections.Generic;
using Entity;
using DAL;
using System.IO;
using System;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora);
            return $"Liquidacion: {liquidacionCuotaModeradora.NumeroLiquidacion} guardada";
        }

        public List<LiquidacionCuotaModeradora> Consultar()
        {
            return liquidacionCuotaModeradoraRepository.Consultar();
        }

        public LiquidacionCuotaModeradora BuscarNumeroLiquidacion(string numeroLiquidacion)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora= liquidacionCuotaModeradoraRepository.BuscarNumeroLiquidacion(numeroLiquidacion);
            return liquidacionCuotaModeradora;
        }

        public string Eliminar(string numeroLiquidacion)
        {
            
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = liquidacionCuotaModeradoraRepository.BuscarNumeroLiquidacion(numeroLiquidacion);
                if (liquidacionCuotaModeradora != null)
                {
                    liquidacionCuotaModeradoraRepository.Eliminar(liquidacionCuotaModeradora);
                    return $"Los datos de {liquidacionCuotaModeradora.NumeroLiquidacion} se han eliminado correctamente";
                }
                else
                {
                    return $"Error la persona que desea eliminar no se encuentra en el sistema";
                }

            
        }

        public string Modificar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            try
            {
                liquidacionCuotaModeradoraRepository.Modificar(liquidacionCuotaModeradora);
                return $"Los Datos de la liquidacion{liquidacionCuotaModeradora.NumeroLiquidacion}se han modificado correctamente";


            }
            catch (Exception e)
            {

                return "Error de la lectura" + e.Message;
            }
        }
    }
}
