using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Customer.Model;

namespace VirtoCommerce.CustomerExtModule.Web.Model
{
    public class VendorExtension : Vendor
    {
        public VendorExtension() {
            base.MemberType = typeof(Vendor).Name;
        }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Type1 { get; set; }

        public int AcctRep { get; set; }

        public bool DirectoryLive { get; set; }

        public string ExternalWebsiteUrl { get; set; }

        public string AcctField1 { get; set; }

        public string AcctField2 { get; set; }

        public string AcctField3 { get; set; }

        public string AcctField4 { get; set; }

        public string AcctField5 { get; set; }

        public string AcctField6 { get; set; }

        public string AcctField7 { get; set; }

        public string AcctField8 { get; set; }

        public string AcctField9 { get; set; }

        public string AcctField10 { get; set; }

        public string AcctField11 { get; set; }

        public string AcctField12 { get; set; }

        public string AdminNotes { get; set; }

        public DateTime LastUsed { get; set; }

        public string ConfiguratorSettings { get; set; }

    }
}