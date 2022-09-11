using ApiFilmes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFilmes.Controllers
{
    public class FilmeController : ApiController
    {
        // GET: api/Filme
        [HttpGet]
        public IEnumerable Get()
        {
            var filmeDAO = new FilmeDAO();
            var filmelist = filmeDAO.SelectTodosFilmes();
            return filmelist;
        }


        // GET: api/Filme/5
        [HttpGet]
        public Filme Get(string id)
        {
            var filmeDAO = new FilmeDAO();
            var filme = filmeDAO.SelectFilmePeloImdb(id);
            return filme;
        }

        // POST: api/Filme
        [HttpPost]
        public void Post([FromBody]Filme filme)
        {
            if (filme == null)
               throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var filmeDAO = new FilmeDAO();
            filmeDAO.Insert(filme);
        }

        // PUT: api/Filme/5
        public void Put(string id, [FromBody]Filme filme)
        {
            if (filme == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var elementDAO = new FilmeDAO();
            elementDAO.Update(filme);
        }

        // DELETE: api/Filme/5
        public Filme Delete(string id)
        {
            var filmeDAO = new FilmeDAO();
            var filme = filmeDAO.SelectFilmePeloImdb(id);
            if (filme == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            filmeDAO.Delete(id);
            return filme;
        }
    }
}
