namespace LGC.DataAccess.GestionDesAnalyses {
    
    
    public partial class GestionDesAnalysesDataSet {
        partial class TJ_ResultatParametreAnalyseDataTable
        {
       }
        partial class PS_DemandeAnalyse_SP1DataTable
        {
       }

        partial class T_FactureDataTable
        {
        }
    }


}


namespace LGC.DataAccess.GestionDesAnalyses.GestionDesAnalysesDataSetTableAdapters
{

    public partial class PS_DemandeAnalyse_SP1TableAdapter
    {
        public PS_DemandeAnalyse_SP1TableAdapter(string t)
        {
            this.CommandCollection[0].CommandTimeout = 0;
        }

        public int ComTimeout
        {
            get
            {
                return this.CommandCollection[0].CommandTimeout;
            }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    this.CommandCollection[i].CommandTimeout = value;
                    this.ConnectionTimeOut = value;
                }

            }
        }

        public int ConnectionTimeOut
        {
            get
            {
                return this.Connection.ConnectionTimeout;
            }
            set
            {

            }
        }
    }


    
}
