using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class achat
    {
        Data_access app;
        public achat()
        {
            app = new Data_access();
        }


        public void ajouterachat(DateTime date_achat, int qte_commander, string code_four, int code_med)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@date_achat", SqlDbType.Date);
            param[0].Value = date_achat;
            param[1] = new SqlParameter("@qte_commander", SqlDbType.Int);
            param[1].Value = qte_commander;
            param[2] = new SqlParameter("@code_four", SqlDbType.VarChar, 15);
            param[2].Value = code_four;
            param[3] = new SqlParameter("@code_med", SqlDbType.Int);
            param[3].Value = code_med;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajouteachat", param);
            app.fermerconnexion();
        }



        public void supprachat(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 15);
            param[0].Value = id;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprachat", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_afficheachat", null);
            return dt;
        }

        public DataTable cherch_parid(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_achat_id", param);
            return dt;
        }

        public DataTable cherch_pardate(DateTime d)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date_achat", SqlDbType.Date);
            param[0].Value = d;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_achat_par_date", param);
            return dt;
        }
    }
}
