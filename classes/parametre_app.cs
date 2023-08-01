using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacie.classes
{
    class parametre_app
    {
        Data_access app;
        public parametre_app()
        {
            app = new Data_access();
        }

        public void creer_backup(string emplacement)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@path", SqlDbType.VarChar,250);
            param[0].Value = emplacement;
            app.ouvrirconnexion();
            app.mettre_ajour("ps_backup", param);
            app.fermerconnexion();
        }
    }
}
