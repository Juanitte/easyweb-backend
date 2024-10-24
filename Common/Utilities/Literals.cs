﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public class Literals
    {
        #region Culturas

        public static string CultureEn = "en-US";
        public static string CultureEs = "es-ES";

        #endregion

        #region Controllers

        public static string UsersController = "Users";
        public static string TicketsController = "Tickets";
        public static string MessagesController = "Messages";

        #endregion

        #region Roles

        public static string Role_SuperAdmin = "SuperAdmin";
        public static string Role_Admin = "Admin";
        public static string Role_Support = "Support";
        public static string Role_User = "User";

        #endregion

        #region Claims de los usuarios

        public static string Claim_FullName = "FullName";
        public static string Claim_LanguageId = "LanguageId";
        public static string Claim_Role = "Role";
        public static string Claim_UserId = "UserId";
        public static string Claim_Email = "Email";
        public static string Claim_PhoneNumber = "PhoneNumber";

        #endregion

        #region Datos email

        public static string Email_Name = "Easy Web";
        public static string Email_Address = "noreply.easyweb@gmail.com";
        public static string Email_Auth = "levp dwqb qacd vhle";
        public static string Email_Service = "smtp.gmail.com";
        public static int Email_Port = 587;

        public static string Support_Email_Name = "Easy Web Support";
        public static string Support_Email_Address = "noreply.easyweb_support@gmail.com";
        public static string Support_Email_Auth = "levp dwqb qacd vhle";
        public static string Support_Email_Service = "smtp.gmail.com";
        public static int Support_Email_Port = 587;

        #endregion

        #region Enlaces

        public static string Link_Recover = "http://localhost:4200/recover/";
        public static string Link_Review = "http://localhost:4200/link/";

        #endregion
    }
}
