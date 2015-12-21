using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DAL;

namespace BLL
{
    public abstract class absTemplate
    {
        public Context ctx { get; set; }
        public ByARpt byaRpt { get; set; }

        protected bool Existe(object e)
        {
            return e != null;
        }

        protected virtual void Despues()
        {
            byaRpt.Mensaje = "Se Realizó la Operación Satisfactoriamente";
        }
        protected internal abstract void Antes();

        protected internal virtual bool esValido()
        {
            byaRpt.Mensaje = "VALIDADÓ UPDATE";
            byaRpt.Error = true;
            return byaRpt.Error;
        }
        protected internal virtual void SaveChange()
        {
            byaRpt.Filas = ctx.SaveChanges();
            byaRpt.Error = false;
        }

        public ByARpt Enviar()
        {
            byaRpt = new ByARpt();
            using (ctx = new Context())
            {
                if (!esValido())
                {
                    return byaRpt;
                }
                try
                {
                    Antes();
                    SaveChange();
                    Despues();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {

                }
                catch (Exception ex)
                {
                    byaRpt.Mensaje = ex.Message;
                    byaRpt.Error = true;
                    //ByAExcep.AdminException(byaRpt, ex);

                }
                return byaRpt;

            }
        }
        
    }
}
