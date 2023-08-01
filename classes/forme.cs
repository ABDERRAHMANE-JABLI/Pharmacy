using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class forme
    {
        Data_access app;
        public forme()
        {
            app = new Data_access();
        }

        public void ajouterforme(string lb)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@libelle", SqlDbType.VarChar, 100);
            param[0].Value = lb;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajouterforme", param);
            app.fermerconnexion();
        }

        public void modifierforme(int id, string lb)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@libelle", SqlDbType.VarChar, 100);
            param[1].Value = lb;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_modifforme", param);
            app.fermerconnexion();
        }

        public void supprforme(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprforme", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_afficheforme", null);
            return dt;
        }

        public DataTable cherch_par_id(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_forme_id", param);
            return dt;
        }

        public DataTable les_recherches(string value)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@value", SqlDbType.VarChar, 200);
            param[0].Value = value;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_recherch_forme", param);
            return dt;
        }
    }
}
