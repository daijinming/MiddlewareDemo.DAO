using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareDemo.DAO.Models
{
    /// <summary>
    /// Class representing Base_CodeRule table
    /// </summary>
    public class Base_CodeRule
    {   
        public string CodeRuleId { get; set; }

        public string FullName { get; set; }

        public string Code { get; set; }

        public string ModuleId { get; set; }

        public int? Enabled { get; set; }

        public int? SortCode { get; set; }

        public int? DeleteMark { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateUserId { get; set; }

        public string CreateUserName { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string ModifyUserId { get; set; }

        public string ModifyUserName { get; set; }

    }
}