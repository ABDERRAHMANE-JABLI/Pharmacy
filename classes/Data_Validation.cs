using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace pharmacie.classes
{
    class Data_Validation
    {

        // email
        public static Boolean verifier_email(string email)
        {
            Regex rg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return rg.IsMatch(email); 
        }

        //nom
        public static Boolean verifier_mot(string nom)
        {
            Regex rg = new Regex("^[a-zA-Z]{3,}$");
            return rg.IsMatch(nom);
        }
        //prenom       

        // cin
        public static Boolean verifier_cin(string cin)
        {
            Regex rg = new Regex("^[a-zA-Z]{1,2}[0-9]{1,7}$");
            return rg.IsMatch(cin);
        }

        //telephone
        public static Boolean verifier_tel(string tel)
        {
            Regex rg = new Regex("^[0-9]{10}$");
            return rg.IsMatch(tel);
        }
        
        //mot de pass
        public static Boolean verifier_password(string pass)
        {
            Regex rg = new Regex(@"[a-zA-Z0-9]{4,}");
            return rg.IsMatch(pass);
        }

    }
}
