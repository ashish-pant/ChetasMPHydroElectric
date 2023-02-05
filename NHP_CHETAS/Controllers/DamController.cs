using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NHP_CHETAS.DatabaseContext;
using NHP_CHETAS.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NHP_CHETAS.Controllers
{
    public class DamController : Controller
    {
        private readonly AppSettings _mySettings;
        private IConfiguration _iconfiguration;
        private readonly ApplicationDbContext db;
        string Password;
        string username;
        public DamController(IConfiguration iconfiguration, IOptions<AppSettings> settings, ApplicationDbContext dbcontext)
        {
            _iconfiguration = iconfiguration;
            _mySettings = settings.Value;
            db = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDamData(string DamName)
        {
            SqlParameter[] sqlParams;
            DbDataReader result;
            sqlParams = new SqlParameter[]
              {
                       new SqlParameter("@damName", DamName)
              };
            bool isSuccess = false;
            try
            {
                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "NHP_GetDamLevelDetails";
                        cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        //  var successObj = result.Translate<GraphModel>();
                      
                        con.Close();
                    }
                }
                //  return Json(true);
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
            return Json(true);
        }


        [HttpGet]
        public IActionResult GetDamData1(string DamName)
        {
            SqlParameter[] sqlParams;
            DbDataReader result;
            sqlParams = new SqlParameter[]
              {
                       new SqlParameter("@damName", DamName)
              };
            bool isSuccess = false;
            try
            {
                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "NHP_GetDamLevelDetails";
                        cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        //  var successObj = result.Translate<GraphModel>();

                        con.Close();
                    }
                }
                //  return Json(true);
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
            return Json(true);
        }


    }
}
