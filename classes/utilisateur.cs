using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class utilisateur
    {
        Data_access app;
        public utilisateur()
        {
            app = new Data_access();
        }
        public DataTable se_connecter(string email, string pass)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mail", SqlDbType.VarChar, 200);
            param[0].Value = email;
            param[1] = new SqlParameter("@pass", SqlDbType.VarChar, 50);
            param[1].Value = pass;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_connecter", param);
            return dt;
        }

        public void ajouterutilisateur(string nom, string email, string pass, string type)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            param[0].Value = nom;
            param[1] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            param[1].Value = email;
            param[2] = new SqlParameter("@mot_pass", SqlDbType.VarChar, 50);
            param[2].Value = pass;
            param[3] = new SqlParameter("@typee", SqlDbType.VarChar, 50);
            param[3].Value = type;            
            app.ouvrirconnexion();
            app.mettre_ajour("ps_add_user", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_affiche_userss", null);
            return dt;
        }

        public void supprme_user(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_suppr_user", param);
            app.fermerconnexion();
        }

        
    }
}
