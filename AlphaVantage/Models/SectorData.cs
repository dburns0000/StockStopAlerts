using System;
using System.Collections.Generic;
using System.Text;

namespace Kermor.AlphaVantage
{
    public class SectorData
    {
		public SectorPerfomances RankA_Realtime = new SectorPerfomances();
		public SectorPerfomances RankB_1_Day = new SectorPerfomances();
		public SectorPerfomances RankC_5_Days = new SectorPerfomances();
		public SectorPerfomances RankD_1_Month = new SectorPerfomances();
		public SectorPerfomances RankE_3_Months = new SectorPerfomances();
		public SectorPerfomances RankF_YTD = new SectorPerfomances();
		public SectorPerfomances RankG_1_Year = new SectorPerfomances();
		public SectorPerfomances RankH_3_Year = new SectorPerfomances();
		public SectorPerfomances RankI_5_Years = new SectorPerfomances();
		public SectorPerfomances RankJ_10_Years = new SectorPerfomances();
	}
}
