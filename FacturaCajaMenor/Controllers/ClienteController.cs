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
    [RoutePrefix("Api/Clientes")]
    public class ClienteController : ApiController
    {
        [Route("")]
        public List<ClienteDto> Gets()
        {
            mCliente mCli = new mCliente();
            return mCli.Gets();
        }
        //public List<PostDto> Gets()
        //{
        //    mPost omPost = new mPost();
        //    return omPost.Gets();
        //}

        //[Route("{idPost}")]
        //public List<PostDto> Gets(int idPost)
        //{
        //    mPost omPost = new mPost();
        //    return omPost.Gets(idPost);
        //}

        //[Route("")]
        //public ByARpt Post(PostDto Reg)
        //{
        //    mPost omPost = new mPost();
        //    return omPost.Insert(Reg);
        //}


        //[Route("Content/{content}/Title/{title}")]
        //public PostDto Get(string content, string title)
        //{
        //    mPost omPost = new mPost();
        //    return omPost.Gets(content, title);
        //}
    }
}
