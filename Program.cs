using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
namespace LiquidacionUI
{
    class Program
    {
        static LiquidacionCuotaModeradora liquidacionCuotaModeradora;
        static LiquidacionSubsidiado liquidacionSubsidiado = new LiquidacionSubsidiado();
        static LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n ----------- Menu -----------");
                Console.WriteLine(" 1. Registrar Paciente");
                Console.WriteLine(" 2. Consultar");
                Console.WriteLine(" 3  Eliminar");
                Console.WriteLine(" 4. Buscar");
                Console.WriteLine(" 5. Modificar");
                Console.WriteLine(" 6. Salir");
                Console.WriteLine(" --------------------------");
                Console.Write(" Digite una opcion: "); opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: RegistrarPaciente(); break;
                    case 2: Consultar(); break;
                    case 3: Eliminar(); break;
                    case 4: Buscar(); break;
                    case 5: Modificar(); break;
                    default: break;
                }
            } while (opcion!=6);
        }

        static public void RegistrarPaciente()
        {
            Console.Clear();
            int opcion;
            Console.WriteLine("\n 1. Registrar Paciente\n");
            Console.WriteLine(" Informacion del paciente");
            Console.WriteLine(" 1. Subsidiado \t\t 2. Contributivo");
            Console.Write(" Digite una opcion: "); opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion==1)
            {
                liquidacionCuotaModeradora = new LiquidacionSubsidiado();
                LlenarInformacion(liquidacionCuotaModeradora, "Subsidiado");
                Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            }
            else if(opcion == 2)
            {
                liquidacionCuotaModeradora = new LiquidacionContributivo();
                LlenarInformacion(liquidacionCuotaModeradora, "Contributivo");
                Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            }
            Console.ReadKey();
        }

        static public void LlenarInformacion(LiquidacionCuotaModeradora liquidacionCuotaModeradora, string tipo)
        {
            Console.Write(" Digite numero de liquidacion: "); liquidacionCuotaModeradora.NumeroLiquidacion = Console.ReadLine();
            Console.Write(" Digite identificacion: "); liquidacionCuotaModeradora.Identificacion = Console.ReadLine();
            Console.Write(" Digite nombre: "); liquidacionCuotaModeradora.Nombre = Console.ReadLine();
            Console.Write(" Digite valor del servicio: "); liquidacionCuotaModeradora.ValorServicio = Convert.ToDecimal(Console.ReadLine());
            Console.Write(" Digite salario: "); liquidacionCuotaModeradora.Salario = Convert.ToDecimal(Console.ReadLine());
            liquidacionCuotaModeradora.TipoAfiliacion = tipo;
            Console.WriteLine(liquidacionSubsidiado.CalcularCuotaModeradora(liquidacionCuotaModeradora.Salario, liquidacionCuotaModeradora.ValorServicio));
            liquidacionCuotaModeradora.Tarifa = liquidacionSubsidiado.Tarifa;
            liquidacionCuotaModeradora.ValorCuota = liquidacionSubsidiado.ValorCuota;
        }

        static public void Consultar()
        {
            Console.Clear();
            Console.WriteLine("\n 2. Consultar\n");
            foreach (var item in liquidacionCuotaModeradoraService.Consultar())
            {
                Console.WriteLine(" -----------------------");
                Console.WriteLine($" Numero de liquidacion: {item.NumeroLiquidacion}");
                Console.WriteLine($" Identificacion: {item.Identificacion}");
                Console.Write($" Nombre: {item.Nombre}");
                Console.WriteLine($" Valor del servicio: {item.ValorServicio}");
                Console.WriteLine($" Salario: {item.Salario}");
                Console.WriteLine($" Tipo de Afiliacion: {item.TipoAfiliacion}");
                Console.WriteLine($" Tarifa aplicada: {item.Tarifa}");
                Console.WriteLine($" Cuota moderada: {item.ValorCuota}");
                Console.WriteLine(" -----------------------\n");
            }
            Console.Write("\n Presione enter para continuar..."); Console.ReadKey();
        }

        static public void Eliminar()
        {
            string numeroLiquidacion;
            Console.Write("\n Digite numero de liquidacion a eliminar: "); numeroLiquidacion = Console.ReadLine();
            Console.WriteLine(liquidacionCuotaModeradoraService.Eliminar(numeroLiquidacion));
            Console.ReadKey();
        }

        static public void Buscar()
        {
            string numeroLiquidacion;
            Console.Write("\n Digite NumeroLiquidacion: "); numeroLiquidacion = Console.ReadLine();
            liquidacionCuotaModeradora = liquidacionCuotaModeradoraService.BuscarNumeroLiquidacion(numeroLiquidacion);
            if (liquidacionCuotaModeradora == null)
            {
                Console.WriteLine($"\n El numero de liquidacion [{numeroLiquidacion}] no existe");
            }
            else
            {
         
                Console.WriteLine("\n Informacion de persona");
                Console.WriteLine($" Numero de liquidacion: {liquidacionCuotaModeradora.NumeroLiquidacion}");
                Console.WriteLine($" Identificacion: {liquidacionCuotaModeradora.Identificacion}");
                Console.WriteLine($" Nombre: {liquidacionCuotaModeradora.Nombre}");
                Console.WriteLine($" Valor del servicio: {liquidacionCuotaModeradora.ValorServicio}");
                Console.WriteLine($" Salario: {liquidacionCuotaModeradora.Salario}");
                Console.WriteLine($" Tipo de Afiliacion: {liquidacionCuotaModeradora.TipoAfiliacion}");
                Console.WriteLine($" Tarifa aplicada: {liquidacionCuotaModeradora.Tarifa}");
                Console.WriteLine($" Cuota moderada: {liquidacionCuotaModeradora.ValorCuota}");
                
            }
            Console.Write("\n Pulse enter para continuar..."); Console.ReadKey();

        }

        static public void Modificar()
        {
            string numeroLiquidacion;
            Console.Write("\n Digite numero de liquidacion a Modificar: "); numeroLiquidacion = Console.ReadLine();
            if (liquidacionCuotaModeradoraService.BuscarNumeroLiquidacion(numeroLiquidacion) == null)
            {
                Console.WriteLine("\n El numero de liquidacion no existe...");
            }
            else
            {
                liquidacionCuotaModeradora = liquidacionCuotaModeradoraService.BuscarNumeroLiquidacion(numeroLiquidacion);
                if (liquidacionCuotaModeradora.TipoAfiliacion.Equals("Subsidiado"))
                {
                    Console.Write(" Digite numero valor del serivicio: "); liquidacionCuotaModeradora.ValorServicio = Convert.ToDecimal(Console.ReadLine());
                    liquidacionSubsidiado.CalcularCuotaModeradora(liquidacionCuotaModeradora.Salario, liquidacionCuotaModeradora.ValorServicio);
                    liquidacionCuotaModeradora.ValorCuota = liquidacionSubsidiado.ValorCuota;
                    Console.WriteLine($" Su nueva cuota moderada es: {liquidacionCuotaModeradora.ValorCuota}");
                    Console.WriteLine(liquidacionCuotaModeradoraService.Modificar(liquidacionCuotaModeradora));
                    Console.ReadKey();
                }
            }

        }
        //stevdgvbnyhgdfgtyhujnbvfdfgtyhjnbgvfghjuyhgtrfc

    }
}
