using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem.app.Financial.Controllers.AdminController
{
    /// <summary>
    /// Admin singleton to save login Data
    /// </summary>
    public class AdminSingleton
    {
        private static AdminSingleton singleton;
        private Admin admin = new Admin();

        public AdminSingleton(){}

        /// <summary>
        /// Singleton for Admin
        /// </summary>
        public static AdminSingleton Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new AdminSingleton();
                }
                return singleton;
            }
        }

        public void saveAdmin(Admin admin) 
        {
            this.admin = admin;
        }

        public Admin getAdmin() 
        {
            return this.admin;
        }
    }


    /// <summary>
    /// Class Admin
    /// </summary>
    public class Admin 
    {
        public      int         idAdmin         { get; set; }

         [DisplayName("Nombre")]
        public      string      nameAdmin       { get; set; }

         [DisplayName("Apellidos")]
        public      string      lastNameAdmin   { get; set; }

         [DisplayName("Usuario")]
        public      string      userAdmin       { get; set; }

         [DisplayName("Password")]
        public      string      passwordAdmin   { get; set; }

        public      int         idTypeAdmin     { get; set; }

         [DisplayName("Tipo")]
        public      string      typeAdmin       { get; set; }

         [DisplayName("Turno")]
        public      string      workingHours    { get; set; }

        /// <summary>
        /// Constructor empty from Admin Object
        /// </summary>
        public Admin() 
        {

        }

        /// <summary>
        /// Constructor From Admin Object
        /// </summary>
        /// <param name="idAdmin">ID from Admin</param>
        /// <param name="nameAdmin">Name from Admin</param>
        /// <param name="lastNameAdmin">Lastname from Admin</param>
        /// <param name="userAdmin">User from Session of Admin</param>
        /// <param name="passwordAdmin">Password from Session of Admin</param>
        /// <param name="idTypeAdmin">ID of Admin</param>
        /// <param name="typeAdmin">Type of Admin</param>
        /// <param name="workingHours">Working hours from Admin</param>
        public Admin(int idAdmin, string nameAdmin, string lastNameAdmin, string userAdmin, string passwordAdmin, int idTypeAdmin, string typeAdmin, string workingHours) 
        {
            this.idAdmin        = idAdmin;
            this.nameAdmin      = nameAdmin;
            this.lastNameAdmin  = lastNameAdmin;
            this.userAdmin      = userAdmin;
            this.passwordAdmin  = passwordAdmin;
            this.idTypeAdmin    = idTypeAdmin;
            this.typeAdmin      = typeAdmin;
            this.workingHours   = workingHours;
        }
    }
}
