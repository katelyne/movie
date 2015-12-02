using System;
using DatabaseTutorial.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace DatabaseTutorial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            connection.Open();
            var query = new SqlCommand("SELECT * FROM Table1");
            query.Connection = connection;
            var model = new Collection<MovieModel>();
            
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                var item = new MovieModel();
                item.Name = Convert.ToString(reader["Name"]);
                item.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                model.Add(item);
            }

            return View(model);
        }
    }
}