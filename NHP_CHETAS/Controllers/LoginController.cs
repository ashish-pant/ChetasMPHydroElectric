using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHP_CHETAS.Models;
using NHP_CHETAS.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NHP_CHETAS.Utility;

namespace NHP_CHETAS.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppSettings _mySettings;
        private IConfiguration _iconfiguration;
        private readonly ApplicationDbContext db;
        //string Password;
        //string username;
        public LoginController(IConfiguration iconfiguration, IOptions<AppSettings> settings, ApplicationDbContext dbcontext)
        {
            _iconfiguration = iconfiguration;
            _mySettings = settings.Value;
            //username = _iconfiguration.GetValue<string>("AppSettings:Username");
            //Password = _iconfiguration.GetValue<string>("AppSettings:Password");
            db = dbcontext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLoginn(string userName, string password)
        {
            List<GraphModel> successObj = new List<GraphModel>();
            SqlParameter[] sqlParams;
            DbDataReader result;
            sqlParams = new SqlParameter[]
                     {
                new SqlParameter("@username", userName),
                new SqlParameter("@password", password)
                     };
            try
            {
                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "NHP_CheckUserLogin";
                        cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        successObj = result.Translate<GraphModel>().ToList();
                        con.Close();
                    }
                }
                if (successObj[0].IsSuccess == true)
                {
                    DamInSession(successObj);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View("Login");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlParams = null;
                result = null;
            }
        }

        private void DamInSession(List<GraphModel> objGraphModel)
        {
            HashSet<string> lstDams = new HashSet<string>();
            foreach (var damIdGraphModel in objGraphModel)
            {
                lstDams.Add(damIdGraphModel.DamName);
            }
            HttpContext.Session.SetString("ListDams", JsonConvert.SerializeObject(lstDams));
        }


        [HttpGet]
        public IActionResult BindAllGraphs()
        {
            SqlParameter[] sqlParams;
            DbDataReader result;

            List<GraphModel> lstmodel = new List<GraphModel>();
            try
            {

                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetRLTList";
                        //   cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        lstmodel = result.Translate<GraphModel>().ToList();
                        con.Close();
                    }
                }
                return View(lstmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlParams = null;
                result = null;
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("ListDams");
            return Json("success");
        }


        [HttpPost]
        public JsonResult CreateGraphs(CreateGraphModel graphmodel)
        {
            //    var param = new[] {new SqlParameter("@siteId", graphmodel.siteId),
            //                new SqlParameter("@startdate", graphmodel.startdate),
            //                new SqlParameter("@enddatetime", graphmodel.enddate)
            //};
            List<RLTMindate> lstmodel = new List<RLTMindate>();
            var sqlParams = new SqlParameter[]
              {
                new SqlParameter("@siteId", graphmodel.siteId),
                new SqlParameter("@startdate", graphmodel.startdate),
                new SqlParameter("@enddatetime", graphmodel.enddate)
              };
            // var items = db.GraphPoints.FromSqlRaw("sp_GetRLTMinuteDatas @siteId,@startdate,@enddatetime", graphmodel.siteId, graphmodel.startdate, graphmodel.enddate).ToList();
            using (DbConnection con = db.Database.GetDbConnection())
            {
                using (DbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetRLTMinuteDatas";
                    cmd.Parameters.AddRange(sqlParams);
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandTimeout = 0;
                    var result = cmd.ExecuteReader();
                    lstmodel = result.Translate<RLTMindate>().ToList();
                    con.Close();
                }
            }
            return Json(lstmodel);
        }
    }


    public class CreateGraphModel
    {
        public int siteId { get; set; }
        public string startdate { get; set; } = null;
        public string enddate { get; set; } = null;
    }


    public class RLTMindate
    {
        public string Dateandtime { get; set; }
        public decimal lastValue { get; set; }
    }

}
