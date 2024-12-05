using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NhaHang_Web.Models;

namespace NhaHang_Web.Controllers
{
    public class MonAnAPIController : ApiController
    {
        // GET api/<controller>
        NHAHANG_DOANWEBEntities db = new NHAHANG_DOANWEBEntities();
        public List<MonAnApiM> GetList()
        {
            List<MonAnApiM> lst = new List<MonAnApiM>();
            foreach (var item in db.MONAN.ToList())
            {
                MonAnApiM ap = new MonAnApiM(item);
                lst.Add(ap);
            }
            return lst;
        }
        public MonAnApiM Get(int id)
        {
            MonAnApiM ap = new MonAnApiM(db.MONAN.Where(x => x.MAMONAN == id).FirstOrDefault());
            return ap;
        }
    }
}