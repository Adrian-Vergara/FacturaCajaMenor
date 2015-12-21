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
        
    }
}
