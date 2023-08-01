using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class fournisseur
    {
        Data_access app;
        public fournisseur()
        {
            app = new Data_access();
        }

        public void ajouterfourn(string c, string n, string p, string ad, string t, string em)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = c;
            param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            param[1].Value = n;
            param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            param[2].Value = p;
            param[3] = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            param[3].Value = ad;
            param[4] = new SqlParameter("@tel", SqlDbType.VarChar, 15);
            param[4].Value = t;
            param[5] = new SqlParameter("@email", SqlDbType.VarChar, 200);
            param[5].Value = em;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajouterfournisseur", param);
            app.fermerconnexion();
        }

        public void modifierfourn(string c, string n, string p, string ad, string t, string em, string cinold)
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
            app.mettre_ajour("ps_modiffournisseur", param);
            app.fermerconnexion();
        }

        public void supprfourn(string c)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = c;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprfournisseur", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_affichefournisseur", null);
            return dt;
        }

        public DataTable cherch_parcin(string cin)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cin", SqlDbType.VarChar, 15);
            param[0].Value = cin;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_fournisseur_cin", param);
            return dt;
        }

        //ps_combofourniss
        public DataTable combo_fourniss()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_combofourniss", null);
            return dt;
        }
        public DataTable les_recherches(string value)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@value", SqlDbType.VarChar, 15);
            param[0].Value = value;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_recherch_fournisseur", param);
            return dt;
        }

        public DataTable rechercher_achat_parfournisseur(string cin)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@code_four", SqlDbType.VarChar, 15);
            param[0].Value = cin;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_vent_par_fournisseur", param);
            return dt;
        }
    }
}
