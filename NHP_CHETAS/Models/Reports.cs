using System.Collections.Generic;

namespace NHP_CHETAS.Models
{
    public class ReportMasterData
    {
        public ReportMasterData()
        {
            lstDamName = new List<MasterData>();
            damLevelReport = new List<DamLevelReport>();
        }
        public List<MasterData> lstDamName { get; set; }
        public List<DamLevelReport> damLevelReport { get; set; }
        //public List<string> lstReportType { get; set; }
    }


    public class ReportsResponse
    {
        public string damName { get; set; }
        public string reportType { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

    }
}
