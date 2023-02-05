using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NHP_CHETAS.DatabaseContext;
using NHP_CHETAS.Filter;
using NHP_CHETAS.Models;
using NHP_CHETAS.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NHP_CHETAS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppSettings _mySettings;
        private IConfiguration _iconfiguration;
        private readonly ApplicationDbContext db;
        private readonly string _connString;
        //string Password;
        //string username;
        public DashboardController(IConfiguration iconfiguration, IOptions<AppSettings> settings, ApplicationDbContext dbcontext)
        {
            _iconfiguration = iconfiguration;
            _mySettings = settings.Value;
            _connString = iconfiguration.GetConnectionString("DefaultConnection");
            //username = _iconfiguration.GetValue<string>("AppSettings:Username");
            //Password = _iconfiguration.GetValue<string>("AppSettings:Password");
            db = dbcontext;
        }

        public IActionResult Index()//Home Page
        {
            DamDetailViewModel onjgandhisagarDamDetails = new DamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            onjgandhisagarDamDetails.TagTable = GetGridDataByDamName("damlevel_tag_table");
            onjgandhisagarDamDetails.OpeningTagTableMainGate = GetGridDataByDamName("opening_tag_table_maingate");
            onjgandhisagarDamDetails.SLUICETagTable = GetGridDataByDamName("SLUICE_opening_tag_table");
            onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("daminflow_tag_table");
            onjgandhisagarDamDetails.HrInflowTagTable = GetGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            onjgandhisagarDamDetails.HrDishargeTagtable = GetGridDataByDamName("hr_disch_tag_table");//not use
            onjgandhisagarDamDetails.HRgateOpeningTagTable = GetGridDataByDamName("HRGateOpening_TagTable");//not use
            onjgandhisagarDamDetails.DamOutflowTagTable = GetGridDataByDamName("dam_outflow_tag_table");
            onjgandhisagarDamDetails.HrOutflowtagTable = GetGridDataByDamName("hr_outflow_tag_table");
            onjgandhisagarDamDetails.MainDamgateDischarge = GetGridDataByDamName("main_dam_gate_discharge");
            onjgandhisagarDamDetails.SLUICEDamGateDischarge = GetGridDataByDamName("SLUICE_dam_gate_discharge");
            onjgandhisagarDamDetails.MainSLUICEDamGateDischarge = GetGridDataByDamName("Main_Total_opening_tag_table");
            onjgandhisagarDamDetails.lastSevenDaysData = SevenDaysDetails("Main_Total_opening_tag_table");


            //List<DamLevelDetailsForGate> damDetailsForGate = new List<DamLevelDetailsForGate>();
            //foreach (var item in onjgandhisagarDamDetails.OpeningTagTableMainGate)
            //{
            //    foreach (var item1 in onjgandhisagarDamDetails.SLUICETagTable)
            //    {
            //        //if (damDetailsForGate.ForEach(x => x.LstValueMain == item1.LstValue))
            //        bool iscontain = false;
            //        foreach (var dsamDetail in damDetailsForGate)
            //        {
            //            if (dsamDetail.LstValueMain == item.LstValue)
            //            {
            //                iscontain = true;
            //                break;
            //            }
            //        }
            //        if (iscontain == false)
            //        {
            //            DamLevelDetailsForGate damdetail = new DamLevelDetailsForGate();
            //            damdetail.LstValueMain = item.LstValue;
            //            damdetail.TagNameMain = item.TagName;
            //            damdetail.TagNameSluice = item1.TagName;
            //            damdetail.LstValueSluice = item1.LstValue;
            //            damDetailsForGate.Add(damdetail);
            //        }
            //    }
            //}
            //ViewBag.DamDetails = damDetailsForGate;



            return View(onjgandhisagarDamDetails);
        }

        [Authorize("MOHINI_PICKUP_WEIR_DAM")]
        public IActionResult MOHINI_PICKUP_WEIR_DAM()
        {
            MohiniDamDetailViewModel objMohiniDamDetails = new MohiniDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            objMohiniDamDetails.TagTable = GetMohiniGridDataByDamName("damlevel_tag_table");
            objMohiniDamDetails.TagTableForGraph = GetMohiniGridDataByDamName("TagTableForGraph");
            objMohiniDamDetails.OpeningTagTableMainGate = GetMohiniGridDataByDamName("opening_tag_table_maingate");
            objMohiniDamDetails.SLUICETagTable = GetMohiniGridDataByDamName("SLUICE_opening_tag_table");
            objMohiniDamDetails.DamInflowTagTable = GetMohiniGridDataByDamName("daminflow_tag_table");
            objMohiniDamDetails.DamInflowTagTableForGraph = GetMohiniGridDataByDamName("daminflow_tag_tableForGraph");
            objMohiniDamDetails.HrInflowTagTable = GetMohiniGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            objMohiniDamDetails.HrDishargeTagtable = GetMohiniGridDataByDamName("hr_disch_tag_table");//not use
            objMohiniDamDetails.LBCHRgateOpeningTagTable = GetMohiniGridDataByDamName("LBCHRGateOpening_TagTable");
            objMohiniDamDetails.RBCHRgateOpeningTagTable = GetMohiniGridDataByDamName("RBCHRGateOpening_TagTable");
            objMohiniDamDetails.DamOutflowTagTable = GetMohiniGridDataByDamName("dam_outflow_tag_table");
            objMohiniDamDetails.DamOutflowTagTableForgraph = GetMohiniGridDataByDamName("dam_outflow_tag_tableForGraph");
            objMohiniDamDetails.HrOutflowtagTable = GetMohiniGridDataByDamName("hr_outflow_tag_table");
            objMohiniDamDetails.HrOutflowtagTableForGraph = GetMohiniGridDataByDamName("hr_outflow_tag_tableForGraph");
            objMohiniDamDetails.MainDamgateDischarge = GetMohiniGridDataByDamName("main_dam_gate_discharge");
            objMohiniDamDetails.SLUICEDamGateDischarge = GetMohiniGridDataByDamName("SLUICE_dam_gate_discharge");
            objMohiniDamDetails.MainSLUICEDamGateDischarge = GetMohiniGridDataByDamName("Main_Total_opening_tag_table");
            objMohiniDamDetails.lastSevenDaysData = SevenDaysDetailsMohini("Main_Total_opening_tag_table");

            return View(objMohiniDamDetails);
        }


        [Authorize("BANSAGAR_DAM")]
        public IActionResult Bansagar_Dam()
        {
            BansagarDamDetailViewModel objBansagarDamDetails = new BansagarDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            objBansagarDamDetails.TagTable = GetBansagarGridDataByDamName("damlevel_tag_table");
            objBansagarDamDetails.OpeningTagTableMainGate = GetBansagarGridDataByDamName("opening_tag_table_maingate");
            objBansagarDamDetails.SLUICETagTable = GetBansagarGridDataByDamName("SLUICE_opening_tag_table");
            objBansagarDamDetails.DamInflowTagTable = GetBansagarGridDataByDamName("daminflow_tag_table");
            objBansagarDamDetails.DamInflowTagTableForGraph = GetBansagarGridDataByDamName("daminflow_tag_tableForGraph");
            objBansagarDamDetails.HrInflowTagTable = GetBansagarGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            objBansagarDamDetails.HrDishargeTagtable = GetBansagarGridDataByDamName("hr_disch_tag_table");//not use
            objBansagarDamDetails.LBCHRgateOpeningTagTable = GetBansagarGridDataByDamName("LBCHRGateOpening_TagTable");
            objBansagarDamDetails.RBCHRgateOpeningTagTable = GetBansagarGridDataByDamName("RBCHRGateOpening_TagTable");
            objBansagarDamDetails.DamOutflowTagTable = GetBansagarGridDataByDamName("dam_outflow_tag_table");
            objBansagarDamDetails.dam_outflow_tag_tableForGraph = GetBansagarGridDataByDamName("dam_outflow_tag_tableForGraph");
            objBansagarDamDetails.HrOutflowtagTable = GetBansagarGridDataByDamName("hr_outflow_tag_table");
            objBansagarDamDetails.HrOutflowtagTableForGraph = GetBansagarGridDataByDamName("hr_outflow_tag_tableForGraph");
            objBansagarDamDetails.MainDamgateDischarge = GetBansagarGridDataByDamName("main_dam_gate_discharge");
            objBansagarDamDetails.SLUICEDamGateDischarge = GetBansagarGridDataByDamName("SLUICE_dam_gate_discharge");
            objBansagarDamDetails.MainSLUICEDamGateDischarge = GetBansagarGridDataByDamName("Main_Total_opening_tag_table");
            objBansagarDamDetails.lastSevenDaysData = SevenDaysDetailsBanSagar("Main_Total_opening_tag_table");

            return View(objBansagarDamDetails);
        }

        [Authorize("ATAL_SAGAR_DAM")]
        public IActionResult Atalsagar_Dam()
        {
            AtalsagarDamDetailViewModel objAtalsagarDamDetails = new AtalsagarDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            objAtalsagarDamDetails.TagTable = GetAtalsagarGridDataByDamName("damlevel_tag_table");
            objAtalsagarDamDetails.OpeningTagTableMainGate = GetAtalsagarGridDataByDamName("opening_tag_table_maingate");
            objAtalsagarDamDetails.SLUICETagTable = GetAtalsagarGridDataByDamName("SLUICE_opening_tag_table");
            objAtalsagarDamDetails.DamInflowTagTable = GetAtalsagarGridDataByDamName("daminflow_tag_table");
            objAtalsagarDamDetails.DamInflowTagTableForGraph = GetAtalsagarGridDataByDamName("daminflow_tag_tableForGraph");
            objAtalsagarDamDetails.HrInflowTagTable = GetAtalsagarGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            objAtalsagarDamDetails.HrDishargeTagtable = GetAtalsagarGridDataByDamName("hr_disch_tag_table");//not use
            objAtalsagarDamDetails.LBCHRgateOpeningTagTable = GetAtalsagarGridDataByDamName("LBCHRGateOpening_TagTable");
            objAtalsagarDamDetails.RBCHRgateOpeningTagTable = GetAtalsagarGridDataByDamName("RBCHRGateOpening_TagTable");
            objAtalsagarDamDetails.DamOutflowTagTable = GetAtalsagarGridDataByDamName("dam_outflow_tag_table");
            objAtalsagarDamDetails.dam_outflow_tag_tableForGraph = GetAtalsagarGridDataByDamName("dam_outflow_tag_tableForGraph");
            objAtalsagarDamDetails.HrOutflowtagTable = GetAtalsagarGridDataByDamName("hr_outflow_tag_table");
            objAtalsagarDamDetails.HrOutflowtagTableForGraph = GetAtalsagarGridDataByDamName("hr_outflow_tag_tableForGraph");
            objAtalsagarDamDetails.MainDamgateDischarge = GetAtalsagarGridDataByDamName("main_dam_gate_discharge");
            objAtalsagarDamDetails.SLUICEDamGateDischarge = GetAtalsagarGridDataByDamName("SLUICE_dam_gate_discharge");
            objAtalsagarDamDetails.MainSLUICEDamGateDischarge = GetAtalsagarGridDataByDamName("Main_Total_opening_tag_table");
            objAtalsagarDamDetails.lastSevenDaysData = SevenDaysDetailsAtalSagar("Main_Total_opening_tag_table");

            return View(objAtalsagarDamDetails);
        }

        [Authorize("SANJAY_SAROVAR_DAM")]
        public IActionResult SanjaySarovar_Dam()
        {
            SanjaySarovarDamDetailViewModel objSanjaySarovarDamDetails = new SanjaySarovarDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            objSanjaySarovarDamDetails.TagTable = GetSanjaySarovarGridDataByDamName("damlevel_tag_table");
            objSanjaySarovarDamDetails.OpeningTagTableMainGate = GetSanjaySarovarGridDataByDamName("opening_tag_table_maingate");
            objSanjaySarovarDamDetails.SLUICETagTable = GetSanjaySarovarGridDataByDamName("SLUICE_opening_tag_table");
            objSanjaySarovarDamDetails.DamInflowTagTable = GetSanjaySarovarGridDataByDamName("daminflow_tag_table");
            objSanjaySarovarDamDetails.DamInflowTagTableForGraph = GetSanjaySarovarGridDataByDamName("daminflow_tag_tableForGraph");
            objSanjaySarovarDamDetails.HrInflowTagTable = GetSanjaySarovarGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            objSanjaySarovarDamDetails.HrDishargeTagtable = GetSanjaySarovarGridDataByDamName("hr_disch_tag_table");//not use
            objSanjaySarovarDamDetails.LBCHRgateOpeningTagTable = GetSanjaySarovarGridDataByDamName("LBCHRGateOpening_TagTable");
            objSanjaySarovarDamDetails.RBCHRgateOpeningTagTable = GetSanjaySarovarGridDataByDamName("RBCHRGateOpening_TagTable");
            objSanjaySarovarDamDetails.DamOutflowTagTable = GetSanjaySarovarGridDataByDamName("dam_outflow_tag_table");
            objSanjaySarovarDamDetails.dam_outflow_tag_tableForGraph = GetSanjaySarovarGridDataByDamName("dam_outflow_tag_tableForGraph");
            objSanjaySarovarDamDetails.HrOutflowtagTable = GetSanjaySarovarGridDataByDamName("hr_outflow_tag_table");
            objSanjaySarovarDamDetails.HrOutflowtagTableForGraph = GetSanjaySarovarGridDataByDamName("hr_outflow_tag_tableForGraph");
            objSanjaySarovarDamDetails.MainDamgateDischarge = GetSanjaySarovarGridDataByDamName("main_dam_gate_discharge");
            objSanjaySarovarDamDetails.SLUICEDamGateDischarge = GetSanjaySarovarGridDataByDamName("SLUICE_dam_gate_discharge");
            objSanjaySarovarDamDetails.MainSLUICEDamGateDischarge = GetSanjaySarovarGridDataByDamName("Main_Total_opening_tag_table");
            objSanjaySarovarDamDetails.lastSevenDaysData = SevenDaysDetailsSarovar("Main_Total_opening_tag_table");

            return View(objSanjaySarovarDamDetails);
        }

        [Authorize("BARGI_DAM")]
        public IActionResult Bargi_DAM()
        {
            BargiDamDetailViewModel objBargiDamDetails = new BargiDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            objBargiDamDetails.TagTable = GetBargiGridDataByDamName("damlevel_tag_table");
            objBargiDamDetails.OpeningTagTableMainGate = GetBargiGridDataByDamName("opening_tag_table_maingate");
            objBargiDamDetails.SLUICETagTable = GetBargiGridDataByDamName("SLUICE_opening_tag_table");
            objBargiDamDetails.DamInflowTagTable = GetBargiGridDataByDamName("daminflow_tag_table");
            objBargiDamDetails.DamInflowTagTableForGraph = GetBargiGridDataByDamName("daminflow_tag_tableForGraph");
            objBargiDamDetails.HrInflowTagTable = GetBargiGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            objBargiDamDetails.HrDishargeTagtable = GetBargiGridDataByDamName("hr_disch_tag_table");//not use
            objBargiDamDetails.LBCHRgateOpeningTagTable = GetBargiGridDataByDamName("LBCHRGateOpening_TagTable");
            objBargiDamDetails.RBCHRgateOpeningTagTable = GetBargiGridDataByDamName("RBCHRGateOpening_TagTable");
            objBargiDamDetails.DamOutflowTagTable = GetBargiGridDataByDamName("dam_outflow_tag_table");
            objBargiDamDetails.DamOutflowTagTableForgraph = GetBargiGridDataByDamName("dam_outflow_tag_tableForGraph");
            objBargiDamDetails.HrOutflowtagTable = GetBargiGridDataByDamName("hr_outflow_tag_table");

            objBargiDamDetails.HrOutflowtagTableForGraph = GetBargiGridDataByDamName("hr_outflow_tag_tableForGraph");
            objBargiDamDetails.MainDamgateDischarge = GetBargiGridDataByDamName("main_dam_gate_discharge");
            objBargiDamDetails.SLUICEDamGateDischarge = GetBargiGridDataByDamName("SLUICE_dam_gate_discharge");
            objBargiDamDetails.MainSLUICEDamGateDischarge = GetBargiGridDataByDamName("Main_Total_opening_tag_table");
            objBargiDamDetails.lastSevenDaysData = SevenDaysDetailsBagri("Main_Total_opening_tag_table");

            return View(objBargiDamDetails);
        }

        [Authorize("GANDHI_SAGAR_DAM")]
        public IActionResult Gandhi_Sagar_Dam()//Gandhisagar DAM case
        {
            GandhiSagarDamDetailViewModel onjgandhisagarDamDetails = new GandhiSagarDamDetailViewModel();
            /*onjgandhisagarDamDetails.DamInflowTagTable = GetGridDataByDamName("damlevel_tag_table");*/
            onjgandhisagarDamDetails.TagTable = GetGandhiSagarGridDataByDamName("damlevel_tag_table");
            onjgandhisagarDamDetails.OpeningTagTableMainGate = GetGandhiSagarGridDataByDamName("opening_tag_table_maingate");
            onjgandhisagarDamDetails.SLUICETagTable = GetGandhiSagarGridDataByDamName("SLUICE_opening_tag_table");
            onjgandhisagarDamDetails.DamInflowTagTable = GetGandhiSagarGridDataByDamName("daminflow_tag_table");
            onjgandhisagarDamDetails.HrInflowTagTable = GetGandhiSagarGridDataByDamName("hrinflow_tag_table");//not use in gnsg
            onjgandhisagarDamDetails.HrDishargeTagtable = GetGandhiSagarGridDataByDamName("hr_disch_tag_table");//not use
            onjgandhisagarDamDetails.HRgateOpeningTagTable = GetGandhiSagarGridDataByDamName("HRGateOpening_TagTable");//not use
            onjgandhisagarDamDetails.DamOutflowTagTable = GetGandhiSagarGridDataByDamName("dam_outflow_tag_table");
            onjgandhisagarDamDetails.HrOutflowtagTable = GetGandhiSagarGridDataByDamName("hr_outflow_tag_table");
            onjgandhisagarDamDetails.MainDamgateDischarge = GetGandhiSagarGridDataByDamName("main_dam_gate_discharge");
            onjgandhisagarDamDetails.SLUICEDamGateDischarge = GetGandhiSagarGridDataByDamName("SLUICE_dam_gate_discharge");
            onjgandhisagarDamDetails.MainSLUICEDamGateDischarge = GetGandhiSagarGridDataByDamName("Main_Total_opening_tag_table");
            onjgandhisagarDamDetails.lastSevenDaysData = SevenDaysDetails("Main_Total_opening_tag_table");
            onjgandhisagarDamDetails.DamGateDischGandhi = GateDischDataGandhisagar("damlevel_tag_table");



            //List<DamLevelDetailsForGate> damDetailsForGate = new List<DamLevelDetailsForGate>();
            //foreach (var item in onjgandhisagarDamDetails.OpeningTagTableMainGate)
            //{
            //    foreach (var item1 in onjgandhisagarDamDetails.SLUICETagTable)
            //    {
            //        //if (damDetailsForGate.ForEach(x => x.LstValueMain == item1.LstValue))
            //        bool iscontain = false;
            //        foreach (var dsamDetail in damDetailsForGate)
            //        {
            //            if (dsamDetail.LstValueMain == item.LstValue)
            //            {
            //                iscontain = true;
            //                break;
            //            }
            //        }
            //        if (iscontain == false)
            //        {
            //            DamLevelDetailsForGate damdetail = new DamLevelDetailsForGate();
            //            damdetail.LstValueMain = item.LstValue;
            //            damdetail.TagNameMain = item.TagName;
            //            damdetail.TagNameSluice = item1.TagName;
            //            damdetail.LstValueSluice = item1.LstValue;
            //            damDetailsForGate.Add(damdetail);
            //        }
            //    }
            //}
            //ViewBag.DamDetails = damDetailsForGate;



            return View(onjgandhisagarDamDetails);
        }

        private List<DamLevelDetails> GetGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<DamLevelDetails> GetMohiniGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails_MOHINI";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<DamLevelDetails> GetBansagarGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails_BANSAGAR";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<DamLevelDetails> GetAtalsagarGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails_Atal";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<DamLevelDetails> GetSanjaySarovarGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails_SANJAY";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private List<DamLevelDetails> GetBargiGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails_Bargi";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<DamLevelDetails> GetGandhiSagarGridDataByDamName(string tableName)// proc will take table name and return data,make it alsong with ............
        {
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<DamLevelDetails> lstdamDetails = new List<DamLevelDetails>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetDamLevelDetails";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<DamLevelDetails>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region "7 days"
        public List<SevenDaysData> SevenDaysDetails(string tableName)//Gandhisagar DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysData> lstdamDetails = new List<SevenDaysData>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetails";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysData>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SevenDaysDataMohini> SevenDaysDetailsMohini(string tableName)//Mohini DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysDataMohini> lstdamDetails = new List<SevenDaysDataMohini>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetailsMohini";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysDataMohini>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SevenDaysDataBanSagar> SevenDaysDetailsBanSagar(string tableName)//BanSagar DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysDataBanSagar> lstdamDetails = new List<SevenDaysDataBanSagar>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetailsBansagar";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysDataBanSagar>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SevenDaysDataAtalSagar> SevenDaysDetailsAtalSagar(string tableName)//Atalsagar DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysDataAtalSagar> lstdamDetails = new List<SevenDaysDataAtalSagar>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetailsAtalSagar";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysDataAtalSagar>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SevenDaysDataSanjaySarovar> SevenDaysDetailsSarovar(string tableName)//sanajay sarovar DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysDataSanjaySarovar> lstdamDetails = new List<SevenDaysDataSanjaySarovar>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetailsSanjaySarovar";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysDataSanjaySarovar>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SevenDaysDataBagri> SevenDaysDetailsBagri(string tableName)//Bagri DAM case
        {
            SevenDaysData onjgandhisagarDamDetails = new SevenDaysData();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<SevenDaysDataBagri> lstdamDetails = new List<SevenDaysDataBagri>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GetLastSevenDaysDetailsBagri";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<SevenDaysDataBagri>().ToList();
                con.Close();
                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        public List<GateDischDataGandhisagar> GateDischDataGandhisagar(string tableName)//Gandhisagar DAM case
        {
            GateDischDataGandhisagar onjgandhisagarDamDetails = new GateDischDataGandhisagar();
            string _connString = _iconfiguration.GetConnectionString("DefaultConnection");
            SqlParameter[] sqlParams;
            DbConnection con;
            DbCommand cmd;
            DbDataReader result;
            List<GateDischDataGandhisagar> lstdamDetails = new List<GateDischDataGandhisagar>();
            try
            {
                sqlParams = new SqlParameter[]
                {
                   new SqlParameter("@damname", tableName)
                };
                con = db.Database.GetDbConnection();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "NHP_GateDischGandhisagar";
                cmd.Parameters.AddRange(sqlParams);
                cmd.Connection = con;
                result = cmd.ExecuteReader();
                lstdamDetails = result.Translate<GateDischDataGandhisagar>().ToList();
                con.Close();

                return lstdamDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
