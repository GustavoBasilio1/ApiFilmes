using ApiAdmins.Models;
using ApiFilmes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAdmins.Controllers
{
    public class AdminController : ApiController
    {
        // GET: api/Admin
        [HttpGet]
        public IEnumerable Get()
        {
            var adminDAO = new AdminDAO();
            var adminlist = adminDAO.SelectTodosAdmins();
            return adminlist;
        }


        // GET: api/Admin/5
        [HttpGet]
        public Admin Get(string id)
        {
            var adminDAO = new AdminDAO();
            var admin = adminDAO.SelectAdminPeloImdb(id);
            return admin;
        }

        // POST: api/Admin
        [HttpPost]
        public void Post([FromBody] Admin admin)
        {
            if (admin == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var adminDAO = new AdminDAO();
            adminDAO.Insert(admin);
        }

        // PUT: api/Admin/5
        public void Put(string id, [FromBody] Admin admin)
        {
            if (admin == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var adminDAO = new AdminDAO();
            adminDAO.Update(admin);
        }

        // DELETE: api/Admin/5
        public Admin Delete(string id)
        {
            var adminDAO = new AdminDAO();
            var admin = adminDAO.SelectAdminPeloImdb(id);
            if (admin == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            adminDAO.Delete(id);
            return admin;
        }
    }
}
