using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class Client
    {
        Data_access app;
        public Client()
        {
            app = new Data_access();
        }

        public void ajouterclient(string c, string n, string p, string ad, string t, string em)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = c;
            param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            param[1].Value = n;
            param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            param[2].Value = p;//@cin,@nom,@prenom,@adresse,@tel,@email
            param[3] = new SqlParameter("@adresse", SqlDbType.VarChar,100);
            param[3].Value = ad;
            param[4] = new SqlParameter("@tel", SqlDbType.VarChar, 15);
            param[4].Value = t;
            param[5] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            param[5].Value = em;
            
            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajouterclient", param);
            app.fermerconnexion();
        }

        public void modifierclient(string c, string n, string p, string ad, string t, string em,string cinold)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = c;
            param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            param[1].Value = n;
            param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            param[2].Value = p;//@cin,@nom,@prenom,@adresse,@tel,@email
            param[3] = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            param[3].Value = ad;
            param[4] = new SqlParameter("@tel", SqlDbType.VarChar, 15);
            param[4].Value = t;
            param[5] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            param[5].Value = em;
            param[6] = new SqlParameter("@cinold", SqlDbType.VarChar, 200);
            param[6].Value = cinold;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_modifclient", param);
            app.fermerconnexion();
        }

        public void supprclient(string c)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = c;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprclient", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_afficheclient", null);
            return dt;
        }
        public DataTable combo_client()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_comboclient", null);
            return dt;
        }

        public DataTable cherch_parcin(string cin)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = cin;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_client_cin", param);
            return dt;
        }

        public DataTable les_recherches(string value)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@value", SqlDbType.VarChar, 15);
            param[0].Value = value;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_recherch_client", param);
            return dt;
        }

        public DataTable rechercher_vent_parclient(string cin)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_client", SqlDbType.VarChar, 15);
            param[0].Value = cin;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_vent_par_client", param);
            return dt;
        }

    }
}
