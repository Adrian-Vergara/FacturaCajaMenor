using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ENTIDAD;
using BLL;

namespace FacturaCajaMenor.Controllers
{
    [RoutePrefix("Api/Facturas")]
    public class FacturaController : ApiController
    {
        [Route("")]
        public List<FacturaDto> Gets()
        {
            mFactura mFact = new mFactura();
            return mFact.Gets();
        }

        [Route("")]
        public ByARpt Registrar(FacturaDto registro)
        {
            mFactura mFact = new mFactura();
            return mFact.Insert(registro);
        }

        [Route("{idCliente}")]
        public List<FacturaDto> Get(int idCliente)
        {
            mFactura mFact = new mFactura();
            return mFact.Get(idCliente);
        }

        [Route("{idFactura}")]
        [AcceptVerbs("PUT")]
        public ByARpt AnulcarFactura(int idFactura)
        {
            mFactura mFact = new mFactura();
            return mFact.AnularFactura(idFactura);
        }
        
    }
}
