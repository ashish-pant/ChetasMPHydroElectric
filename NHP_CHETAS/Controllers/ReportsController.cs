using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NHP_CHETAS.DatabaseContext;
using NHP_CHETAS.Filter;
using NHP_CHETAS.Models;
using NHP_CHETAS.Utility;

namespace NHP_CHETAS.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppSettings _mySettings;
        private IConfiguration _iconfiguration;
        private readonly ApplicationDbContext db;
        public ReportsController(IConfiguration iconfiguration, IOptions<AppSettings> settings, ApplicationDbContext dbcontext)
        {
            _iconfiguration = iconfiguration;
            _mySettings = settings.Value;
            db = dbcontext;
        }
        [Authorize("Reports_Page")]
        public IActionResult Index()
        {
            ReportMasterData lstMasterData = new ReportMasterData();
            lstMasterData.lstDamName = FetchDataFromDb("damName");
            //lstMasterData.lstReportType = FetchDataFromDb("reportType");
            return View(lstMasterData);
        }
        [HttpPost]
        public IActionResult GenerateData(SelectedReportsType selectedDataReportsType)
        {
            ReportMasterData lstMasterData = new ReportMasterData();
            SqlParameter[] sqlParams;
            DbDataReader result;
            List<DamLevelReport> masterData;
            sqlParams = new SqlParameter[]
            {
                new SqlParameter("@damName", selectedDataReportsType.damName),
                new SqlParameter("@endTime", selectedDataReportsType.endTime),
                new SqlParameter("@reportType", selectedDataReportsType.reportType),
                new SqlParameter("@startTime", selectedDataReportsType.startTime)
            };
            try
            {
                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "NHP_GetReportResponseData";
                        cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        masterData = result.Translate<DamLevelReport>().ToList();

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
            lstMasterData.damLevelReport = masterData;
            return View("Index", lstMasterData);
        }

        private List<MasterData> FetchDataFromDb(string typeOfData)
        {
            SqlParameter[] sqlParams;
            DbDataReader result;
            List<MasterData> masterData;
            sqlParams = new SqlParameter[]
            {
                new SqlParameter("@typeOfData", typeOfData)
            };
            try
            {
                using (DbConnection con = db.Database.GetDbConnection())
                {
                    using (DbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "NHP_GetReportMasterData";
                        cmd.Parameters.AddRange(sqlParams);
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteReader();
                        masterData = result.Translate<MasterData>().ToList();

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

            return masterData;

        }

    }

  
}
