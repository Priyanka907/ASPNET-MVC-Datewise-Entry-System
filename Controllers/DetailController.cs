using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IshaTest.Models;

namespace IshaTest.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detailz
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DetailsModel d)
        {
            string cs = ConfigurationManager.ConnectionStrings["Details"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Amount", d.Amount);
                cmd.Parameters.AddWithValue("@Days", d.Days);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return View(d);
        }
    }
}