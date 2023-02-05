using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHP_CHETAS.Models
{

    public class DamLevelDetails
    {

        public string TagName { get; set; }
        public string LstValue { get; set; }
        public string Unit { get; set; }

        public string LDR { get; set; }

    }
    public class DamLevelDetailsForGate
    {

        public string TagNameMain { get; set; }
        public string LstValueMain { get; set; }
        public string UnitMain { get; set; }
        public string TagNameSluice { get; set; }
        public string LstValueSluice { get; set; }
        public string UnitSluice { get; set; }

    }


    public class SevenDaysDataMohini
    {
        public DateTime lastUpdate { get; set; }
        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }
        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }

        public string MaxValue_27 { get; set; }
        public string MinValue_27 { get; set; }
        public string AvgValue_27 { get; set; }

    }
    public class SevenDaysDataAtalSagar
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }

        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }

        public string MaxValue_27 { get; set; }
        public string MinValue_27 { get; set; }
        public string AvgValue_27 { get; set; }

    }
    public class SevenDaysDataBanSagar
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }

        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }

        public string MaxValue_27 { get; set; }
        public string MinValue_27 { get; set; }
        public string AvgValue_27 { get; set; }

    }
    public class SevenDaysDataBagri
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }
        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }
    }
    public class SevenDaysDataSanjaySarovar
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }

        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }

        public string MaxValue_27 { get; set; }
        public string MinValue_27 { get; set; }
        public string AvgValue_27 { get; set; }

    }
    public class SevenDaysData
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_36 { get; set; }
        public string MinValue_36 { get; set; }
        public string AvgValue_36 { get; set; }

        public string MaxValue_26 { get; set; }
        public string MinValue_26 { get; set; }
        public string AvgValue_26 { get; set; }

        public string MaxValue_27 { get; set; }
        public string MinValue_27 { get; set; }
        public string AvgValue_27 { get; set; }


        public string MaxValue_28 { get; set; }
        public string MinValue_28 { get; set; }
        public string AvgValue_28 { get; set; }
        public string MaxValue_29 { get; set; }
        public string MinValue_29 { get; set; }
        public string AvgValue_29 { get; set; }
    }

    public class DamDetailViewModel
    {
        public DamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            HRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            HrOutflowtagTable = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysData>();
            DamGateDischGandhi = new List<GateDischDataGandhisagar>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
      
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }
        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> HRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysData> lastSevenDaysData { get; set; }
        public List<GateDischDataGandhisagar> DamGateDischGandhi { get; set; }



    }
    public class MohiniDamDetailViewModel
    {
        public MohiniDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            TagTableForGraph = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            DamInflowTagTableForGraph = new List<DamLevelDetails>();

            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            LBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            RBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            DamOutflowTagTableForgraph = new List<DamLevelDetails>();

            HrOutflowtagTable = new List<DamLevelDetails>();

            HrOutflowtagTableForGraph = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysDataMohini>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> TagTableForGraph { get; set; }

        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }

        public List<DamLevelDetails> DamInflowTagTableForGraph { get; set; }

        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> LBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> RBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTableForgraph { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }

        public List<DamLevelDetails> HrOutflowtagTableForGraph { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysDataMohini> lastSevenDaysData { get; set; }
    }
    public class BansagarDamDetailViewModel
    {
        public BansagarDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            DamInflowTagTableForGraph = new List<DamLevelDetails>();

            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            LBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            RBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            dam_outflow_tag_tableForGraph = new List<DamLevelDetails>();

            HrOutflowtagTable = new List<DamLevelDetails>();

            HrOutflowtagTableForGraph = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysDataBanSagar>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }

        public List<DamLevelDetails> DamInflowTagTableForGraph { get; set; }

        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> LBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> RBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> dam_outflow_tag_tableForGraph { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }

        public List<DamLevelDetails> HrOutflowtagTableForGraph { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysDataBanSagar> lastSevenDaysData { get; set; }
    }
    public class AtalsagarDamDetailViewModel
    {
        public AtalsagarDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            DamInflowTagTableForGraph = new List<DamLevelDetails>();

            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            LBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            RBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            dam_outflow_tag_tableForGraph = new List<DamLevelDetails>();

            HrOutflowtagTable = new List<DamLevelDetails>();

            HrOutflowtagTableForGraph = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysDataAtalSagar>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }

        public List<DamLevelDetails> DamInflowTagTableForGraph { get; set; }

        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> LBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> RBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> dam_outflow_tag_tableForGraph { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }

        public List<DamLevelDetails> HrOutflowtagTableForGraph { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysDataAtalSagar> lastSevenDaysData { get; set; }
    }
    public class SanjaySarovarDamDetailViewModel
    {
        public SanjaySarovarDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            DamInflowTagTableForGraph = new List<DamLevelDetails>();

            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            LBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            RBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            dam_outflow_tag_tableForGraph = new List<DamLevelDetails>();

            HrOutflowtagTable = new List<DamLevelDetails>();

            HrOutflowtagTableForGraph = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysDataSanjaySarovar>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }

        public List<DamLevelDetails> DamInflowTagTableForGraph { get; set; }

        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> LBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> RBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> dam_outflow_tag_tableForGraph { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }

        public List<DamLevelDetails> HrOutflowtagTableForGraph { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysDataSanjaySarovar> lastSevenDaysData { get; set; }
    }
    public class BargiDamDetailViewModel
    {
        public BargiDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            DamInflowTagTableForGraph = new List<DamLevelDetails>();

            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            LBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            RBCHRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            DamOutflowTagTableForgraph = new List<DamLevelDetails>();

            HrOutflowtagTable = new List<DamLevelDetails>();

            HrOutflowtagTableForGraph = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysDataBagri>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }

        public List<DamLevelDetails> DamInflowTagTableForGraph { get; set; }

        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> LBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> RBCHRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTableForgraph { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }

        public List<DamLevelDetails> HrOutflowtagTableForGraph { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysDataBagri> lastSevenDaysData { get; set; }
    }
    public class GandhiSagarDamDetailViewModel
    {
        public GandhiSagarDamDetailViewModel()
        {
            TagTable = new List<DamLevelDetails>();
            OpeningTagTableMainGate = new List<DamLevelDetails>();
            SLUICETagTable = new List<DamLevelDetails>();
            DamInflowTagTable = new List<DamLevelDetails>();
            HrInflowTagTable = new List<DamLevelDetails>();
            HrDishargeTagtable = new List<DamLevelDetails>();
            HRgateOpeningTagTable = new List<DamLevelDetails>();
            DamOutflowTagTable = new List<DamLevelDetails>();
            HrOutflowtagTable = new List<DamLevelDetails>();
            MainDamgateDischarge = new List<DamLevelDetails>();
            MainSLUICEDamGateDischarge = new List<DamLevelDetails>();
            SLUICEDamGateDischarge = new List<DamLevelDetails>();
            lastSevenDaysData = new List<SevenDaysData>();
            DamGateDischGandhi = new List<GateDischDataGandhisagar>();
        }
        public List<DamLevelDetails> TagTable { get; set; }
        public List<DamLevelDetails> OpeningTagTableMainGate { get; set; }
        public List<DamLevelDetails> SLUICETagTable { get; set; }
        public List<DamLevelDetails> DamInflowTagTable { get; set; }
        public List<DamLevelDetails> HrInflowTagTable { get; set; }
        public List<DamLevelDetails> HrDishargeTagtable { get; set; }
        public List<DamLevelDetails> HRgateOpeningTagTable { get; set; }
        public List<DamLevelDetails> DamOutflowTagTable { get; set; }
        public List<DamLevelDetails> HrOutflowtagTable { get; set; }
        public List<DamLevelDetails> MainDamgateDischarge { get; set; }
        public List<DamLevelDetails> MainSLUICEDamGateDischarge { get; set; }
        public List<DamLevelDetails> SLUICEDamGateDischarge { get; set; }
        public List<SevenDaysData> lastSevenDaysData { get; set; }
        public List<GateDischDataGandhisagar> DamGateDischGandhi { get; set; }


    }

    public class GateDischDataGandhisagar
    {
        public DateTime lastUpdate { get; set; }

        public string MaxValue_1 { get; set; }
        public string MaxValue_2 { get; set; }
        public string MaxValue_3 { get; set; }
        public string MaxValue_4 { get; set; }
        public string MaxValue_5 { get; set; }
        public string MaxValue_6 { get; set; }
        public string MaxValue_11 { get; set; }
        public string MaxValue_12 { get; set; }
        public string MaxValue_13 { get; set; }
        public string MaxValue_14 { get; set; }


    }
}
