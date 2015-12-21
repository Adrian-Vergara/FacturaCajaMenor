using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTIDAD;
using AutoMapper;namespace BLL
{
    class mCliente
    {
        Context ctx;
        public mCliente()
        {
            Mapper.CreateMap<Cliente, ClienteDto>();
            Mapper.CreateMap<ClienteDto, Cliente>();
        }

        public List<ClienteDto> Gets()
        {
            using(ctx = new Context())
            {
                List<ClienteDto> ListClienteDto = new List<ClienteDto>();
                List<Cliente> ListCliente = ctx.Clientes.ToList();
                Mapper.Map(ListCliente, ListClienteDto);
                return ListClienteDto;
            }
        }

        class cmdInsert : absTemplate
        {
            public ClienteDto CliDto { get; set; }

            protected internal override bool esValido()
            {
                if(CliDto.Nombre != "" && CliDto.Cedula != null && CliDto.Tipo != "")
                {
                    return true;
                }
                return false;
            }
        }

        //class cmdInsert : absTemplate
        //{
        //    public ClienteDto oDto { get; set; }
        //    protected internal override bool esValido()
        //    {
        //        if (oDto.Title != "" && oDto.Content != "")
        //        {
        //            Blogs Blog = ctx.Blogs.Where(t => t.BlogId == oDto.BlogId).FirstOrDefault();
        //            if (Blog != null)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                byaRpt.Error = true;
        //                byaRpt.Mensaje = "El blog seleccionado no existe!!!";
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            byaRpt.Error = true;
        //            byaRpt.Mensaje = "Los campos no pueden estar vacios!!";
        //            return false;
        //        }
        //    }
        //    protected internal override void Antes()
        //    {
        //        Posts Dto = new Posts();
        //        Mapper.Map(oDto, Dto);
        //        ctx.Posts.Add(Dto);
        //    }
        //}
        

    }
}
