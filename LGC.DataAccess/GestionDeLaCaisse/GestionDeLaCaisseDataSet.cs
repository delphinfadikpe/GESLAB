namespace LGC.DataAccess.GestionDeLaCaisse {
    
    
    public partial class GestionDeLaCaisseDataSet {

        partial class T_FacturePartenaireDataTable
        {
        }

        partial class PS_FacturePartenaire_SPDataTable
        {
        }
    }
}

namespace LGC.DataAccess.GestionDeLaCaisse.GestionDeLaCaisseDataSetTableAdapters {
    
    
    public partial class T_FactureTableAdapter {

    }

    public partial class T_FacturePartenaireTableAdapter
    {

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
                //return this.ConnectionTimeOut;
            }
            set
            {
                //for (int i = 0; i < this.Connection.Length - 1; i++)
                //this.Connection. = value;

            }
        }
    }

    public partial class T_FactureTableAdapter
    {
        public T_FactureTableAdapter(string t)
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




    public partial class PS_FacturePartenaire_SPTableAdapter
    {
        public PS_FacturePartenaire_SPTableAdapter(string t)
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
