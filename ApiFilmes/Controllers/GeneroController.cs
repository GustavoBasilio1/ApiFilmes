using ApiFilmes.Models;
using ApiGeneros.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFilmes.Controllers
{
    public class GeneroController : ApiController
    {
        // GET: api/Genero
        [HttpGet]
        public IEnumerable Get()
        {
            var generoDAO = new GeneroDAO();
            var generolist = generoDAO.SelectTodosGeneros();
            return generolist;
        }


        // GET: api/Genero/5
        [HttpGet]
        public Genero Get(int id)
        {
            var generoDAO = new GeneroDAO();
            var genero = generoDAO.SelectGeneroPeloID(id);
            return genero;
        }

        // POST: api/Genero
        [HttpPost]
        public void Post([FromBody] Genero genero)
        {
            if (genero == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var generoDAO = new GeneroDAO();
            generoDAO.Insert(genero);
        }

        // PUT: api/Genero/5
        public void Put(string id, [FromBody] Genero genero)
        {
            if (genero == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var generoDAO = new GeneroDAO();
            generoDAO.Update(genero);
        }

        // DELETE: api/Genero/5
        public Genero Delete(int id)
        {
            var generoDAO = new GeneroDAO();
            var genero = generoDAO.SelectGeneroPeloID(id);
            if (genero == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            generoDAO.Delete(id);
            return genero;
        }
    }
}

