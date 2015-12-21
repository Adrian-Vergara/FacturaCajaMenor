using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Context ctx;
            using (ctx = new Context())
            {
                //List<ClienteDto> ListClienteDto = new List<ClienteDto>();
                List<Cliente> ListCliente = ctx.Clientes.ToList();
                ListCliente.ForEach(t => Console.WriteLine(t.Nombre));
                //Mapper.Map(ListCliente, ListClienteDto);
                //return ListClienteDto;
                //Cliente Cli = new Cliente();
                //Cli.Nombre = "Juancho";
                //Cli.Apellido = "Perez";
                //Cli.Cedula = 1783782;
                //Cli.Tipo = "Persona Natural";
                //ctx.Clientes.Add(Cli);
                //ctx.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
