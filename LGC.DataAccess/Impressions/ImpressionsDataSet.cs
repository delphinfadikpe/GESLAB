namespace LGC.DataAccess.Impressions {
    
    
    public partial class ImpressionsDataSet {
        partial class FT_RecuDataTable
        {
        }

        partial class FT_FacturePartenaire_PreVisualiserDataTable
        {
        }

        partial class PS_FactureClientDataTable
        {
        }
    }
}

namespace LGC.DataAccess.Impressions.ImpressionsDataSetTableAdapters
{

    public partial class FT_FacturePartenaire_PreVisualiserTableAdapter
    {
        public FT_FacturePartenaire_PreVisualiserTableAdapter(string t)
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

    public partial class PS_FactureClientTableAdapter
    {
        public PS_FactureClientTableAdapter(string t)
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
