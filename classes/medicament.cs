using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class medicament
    {
        Data_access app;
        public medicament()
        {
            app = new Data_access();
        }

        public void ajoutermedicament(string dose, string libelle, decimal prix, int qte_stock, byte[] photo, int famille, int forme)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@dose", SqlDbType.VarChar, 100);
            param[0].Value = dose;
            param[1] = new SqlParameter("@libelle", SqlDbType.VarChar, 150);
            param[1].Value = libelle;
            param[2] = new SqlParameter("@prix", SqlDbType.Decimal);
            param[2].Value = prix;
            param[3] = new SqlParameter("@qte_stock", SqlDbType.Int);
            param[3].Value = qte_stock;
            param[4] = new SqlParameter("@photo", SqlDbType.Image);
            param[4].Value = photo;
            param[5] = new SqlParameter("@famille", SqlDbType.Int);
            param[5].Value = famille;
            param[6] = new SqlParameter("@forme", SqlDbType.Int);
            param[6].Value = forme;

            app.ouvrirconnexion();
            app.mettre_ajour("ps_ajoutermedicament", param);
            app.fermerconnexion();
        }

        public void modifiermedicament(int id_medi, string dose, string libelle, decimal prix, int qte_stock, byte[] photo, int famille, int forme)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@id_medi", SqlDbType.Int);
            param[0].Value = id_medi;
            param[1] = new SqlParameter("@dose", SqlDbType.VarChar, 100);
            param[1].Value = dose;
            param[2] = new SqlParameter("@libelle", SqlDbType.VarChar, 150);
            param[2].Value = libelle;
            param[3] = new SqlParameter("@prix", SqlDbType.Decimal);
            param[3].Value = prix;
            param[4] = new SqlParameter("@qte_stock", SqlDbType.Int);
            param[4].Value = qte_stock;
            param[5] = new SqlParameter("@photo", SqlDbType.Image);
            param[5].Value = photo;
            param[6] = new SqlParameter("@famille", SqlDbType.Int);
            param[6].Value = famille;
            param[7] = new SqlParameter("@forme", SqlDbType.Int);
            param[7].Value = forme;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_modifmedicament", param);
            app.fermerconnexion();
        }

        public void supprmedicament(int idmed)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_medi", SqlDbType.Int);
            param[0].Value = idmed;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_supprmedicament", param);
            app.fermerconnexion();
        }

        public DataTable remplirdatagried()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_affichemedicament", null);
            return dt;
        }

        public DataTable combo_medicament()
        {
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_combomedicam", null);
            return dt;
        }
        public DataTable cherch_par_id(int idmed)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_medi", SqlDbType.Int);
            param[0].Value = idmed;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_cherch_medicament_id", param);
            return dt;
        }

        public DataTable cherch_avant_modife(int idmed)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_medi", SqlDbType.Int);
            param[0].Value = idmed;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_medicament_id", param);
            return dt;
        }
       
        public DataTable les_recherches(string value)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@value", SqlDbType.VarChar, 200);
            param[0].Value = value;
            DataTable dt = new DataTable();
            dt = app.selectionner("ps_recherch_medicament", param);
            return dt;
        }
    }
}
