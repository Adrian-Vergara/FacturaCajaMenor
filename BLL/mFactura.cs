﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTIDAD;
using AutoMapper;

namespace BLL
{
    public class mFactura
    {
        //Insertar Datos
        Context ctx;
        public mFactura()
        {
            Mapper.CreateMap<Factura, FacturaDto>()
                .ForMember(dest=>dest.NombreCliente,obj=>obj.MapFrom(src=>src.Cliente.Nombre));
            Mapper.CreateMap<FacturaDto, Factura>();
        }

        public List<FacturaDto> Gets()
        {
            using(ctx = new Context())
            {
                List<FacturaDto> ListFactDto = new List<FacturaDto>();
                List<Factura> ListFact = ctx.Facturas.Where(t=> t.Estado == "Activo").OrderByDescending(t=> t.IdFactura).ToList();
                Mapper.Map(ListFact, ListFactDto);
                return ListFactDto;
            }
        }
        public ByARpt Insert(FacturaDto Registro)
        {
            cmdInsert Insert = new cmdInsert();
            Insert.FactDto = Registro;
            return Insert.Enviar();
        }

        public List<FacturaDto> Get(int idCliente)
        {
            using(ctx = new Context())
            {
                List<FacturaDto> ListFactDto = new List<FacturaDto>();
                List<Factura> ListFact = ctx.Facturas.Where(t => t.IdCliente == idCliente && t.Estado == "Activo").OrderByDescending(t => t.IdFactura).ToList();
                Mapper.Map(ListFact, ListFactDto);
                return ListFactDto;
            }
        }

        public ByARpt AnularFactura(int idFactura)
        {
            cmdUpdate cmd = new cmdUpdate();
            cmd.FactId = idFactura;
            return cmd.Enviar();
        }

        class cmdUpdate : absTemplate
        {
            public int  FactId { get; set; }
            Factura Fact;
            protected internal override bool esValido()
            {
                Fact = ctx.Facturas.Where(t => t.IdFactura == FactId).FirstOrDefault();
                if (Fact != null)
                {
                    if(Fact.Estado != "Inactivo")
                    {
                        return true;
                    }
                    else
                    {
                        byaRpt.Error = true;
                        byaRpt.Mensaje = "La Factura seleccionada ya fue anulada!!!";
                        return false;
                    }
                }
                else
                {
                    byaRpt.Error = true;
                    byaRpt.Mensaje = "La Factura seleccionado no existe!!!";
                    return false;
                }
            }

            protected internal override void Antes()
            {
                Fact.Estado = "Inactivo";
            }

            protected override void Despues()
            {
                byaRpt.Mensaje = "Factura Anulada Exitosamente";
            }
            
        }
        class cmdInsert : absTemplate
        {
            public FacturaDto FactDto { get; set; }
            protected internal override bool esValido()
            {
                if (FactDto.Concepto != "" && FactDto.Valor != 0 && FactDto.ValorLetras != "")
                {
                    Cliente Cli = ctx.Clientes.Where(t => t.IdCliente == FactDto.IdCliente).FirstOrDefault();
                    if (Cli != null)
                    {
                        return true;
                    }
                    else
                    {
                        byaRpt.Error = true;
                        byaRpt.Mensaje = "El Cliente seleccionado no existe!!!";
                        return false;
                    }
                }
                else
                {
                    byaRpt.Error = true;
                    byaRpt.Mensaje = "Los campos no pueden estar vacios!!";
                    return false;
                }
            }

            protected internal override void Antes()
            {
                Factura Fact = new Factura();
                Mapper.Map(FactDto, Fact);
                Fact.Fecha = DateTime.Now;
                ctx.Facturas.Add(Fact);
            }
        }    
    }
}
