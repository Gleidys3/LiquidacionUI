using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string ruta = @"Liquidacion.txt";
        static List<LiquidacionCuotaModeradora> coutas;
        public LiquidacionCuotaModeradoraRepository()
        {
            coutas = new List<LiquidacionCuotaModeradora>();
        }

        public void Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(liquidacionCuotaModeradora.NumeroLiquidacion +";"+ liquidacionCuotaModeradora.TipoAfiliacion +";"
                + liquidacionCuotaModeradora.Identificacion +";"+ liquidacionCuotaModeradora.Nombre +";"+ liquidacionCuotaModeradora.Salario + ";"
                + liquidacionCuotaModeradora.Tarifa +";"+ liquidacionCuotaModeradora.ValorServicio + ";" + liquidacionCuotaModeradora.ValorCuota);
            writer.Close();
            file.Close();
        }

        public List<LiquidacionCuotaModeradora> Consultar()
        {
            coutas.Clear();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = Mapear(linea);
                coutas.Add(liquidacionCuotaModeradora);
            }
            file.Close();
            reader.Close();
            return coutas;
        }

        public LiquidacionCuotaModeradora Mapear(string linea)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;

            string[] datos = linea.Split(';');
            if (datos[1].Equals("Subsidiado"))
            {
                liquidacionCuotaModeradora = new LiquidacionSubsidiado();
            }
            else
            {
                liquidacionCuotaModeradora = new LiquidacionContributivo();
            }

            liquidacionCuotaModeradora.NumeroLiquidacion = datos[0];
            liquidacionCuotaModeradora.TipoAfiliacion = datos[1];
            liquidacionCuotaModeradora.Identificacion = datos[2];
            liquidacionCuotaModeradora.Nombre = datos[3];
            liquidacionCuotaModeradora.Salario = decimal.Parse(datos[4]);
            liquidacionCuotaModeradora.Tarifa = decimal.Parse(datos[5]);
            liquidacionCuotaModeradora.ValorServicio = decimal.Parse(datos[6]);
            liquidacionCuotaModeradora.ValorCuota = decimal.Parse(datos[7]);
            
            return liquidacionCuotaModeradora;
        }
        public void Eliminar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            coutas.Clear();
            coutas = Consultar();
            coutas.Remove(liquidacionCuotaModeradora);
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in coutas)
            {
                if (item.NumeroLiquidacion != liquidacionCuotaModeradora.NumeroLiquidacion)
                {
                    Guardar(item);
                }
            }

        }
        public LiquidacionCuotaModeradora BuscarNumeroLiquidacion(string numeroLiquidacion)
        {
            coutas.Clear();
            coutas = Consultar();
            foreach (var item in coutas)
            {
                if (item.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    return item;

                }

            }
            return null;
        }
        

        public void Modificar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            coutas.Clear();
            coutas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in coutas)
            {
                if (item.NumeroLiquidacion != liquidacionCuotaModeradora.NumeroLiquidacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacionCuotaModeradora);
                }

            }

        }



    }
}
