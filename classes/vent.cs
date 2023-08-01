using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class vent
    {
        Data_access app;
        public vent()
        {
            app = new Data_access();
        }

        public void ajoutervent_client(DateTime date_vent , int qte ,string id_client ,int id_medicam ,decimal avance, decimal reste)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@date_vent", SqlDbType.Date);
            param[0].Value = date_vent;
            param[1] = new SqlParameter("@qte", SqlDbType.Int);
            param[1].Value = qte;
            param[2] = new SqlParameter("@id_client", SqlDbType.VarChar, 15);
            param[2].Value = id_client;
            param[3] = new SqlParameter("@id_medicam ", SqlDbType.Int);
            param[3].Value = id_medicam;
            param[4] = new SqlParameter("@avance", SqlDbType.Decimal);
            param[4].Value = avance;
            param[5] = new SqlParameter("@reste", SqlDbType.Decimal);
            param[5].Value = reste;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajoutervent_client", param);
            app.fermerconnexion();
        }

        public void ajoutervent_autre(DateTime date_vent, int qte, int id_medicam)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@date_vent", SqlDbType.Date);
            param[0].Value = date_vent;
            param[1] = new SqlParameter("@qte", SqlDbType.Int);
            param[1].Value = qte;
            param[2] = new SqlParameter("@id_medicam ", SqlDbType.Int);
            param[2].Value = id_medicam;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajoutervent_autre", param);
            app.fermerconnexion();
        }



        public void supprvent(int num )
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@num", SqlDbType.VarChar, 15);
            param[0].Value = num;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprvent", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_affichevent", null);
            return dt;
        }
        
        public DataTable cherch_parnum(int num)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@num", SqlDbType.Int);
            param[0].Value = num;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_vent_num", param);
            return dt;
        }


        public DataTable cherch_pardate(DateTime d)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date_vent", SqlDbType.Date);
            param[0].Value = d;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_vent_par_date", param);
            return dt;
        }

        public string calculer_credit(string cin)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_client", SqlDbType.VarChar, 15);
            param[0].Value = cin;
            DataTable dt = new DataTable();
            dt = app.selectionner("calculer_cridit_client", param);
            return dt.Rows[0][0].ToString();
        }
    }
}
