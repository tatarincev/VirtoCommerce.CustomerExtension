using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CustomerExtModule.Web.Model
{
    public class VendorExtensionEntity : VendorDataEntity
    {
        [StringLength(128)]
        public string CustomerId { get; set; }

        [StringLength(255)]
        public string CustomerName { get; set; }

        [StringLength(128)]
        public string EmployeeId { get; set; }

        [StringLength(255)]
        public string EmployeeName { get; set; }

        [StringLength(50)]
        public string Type1 { get; set; }

        [Required]
        public int AcctRep { get; set; }

        public bool DirectoryLive { get; set; }

        [StringLength(100)]
        public string ExternalWebsiteUrl { get; set; }

        [StringLength(255)]
        public string AcctField1 { get; set; }

        [StringLength(255)]
        public string AcctField2 { get; set; }

        [StringLength(255)]
        public string AcctField3 { get; set; }

        [StringLength(255)]
        public string AcctField4 { get; set; }

        [StringLength(255)]
        public string AcctField5 { get; set; }

        [StringLength(255)]
        public string AcctField6 { get; set; }

        [StringLength(255)]
        public string AcctField7 { get; set; }

        [StringLength(255)]
        public string AcctField8 { get; set; }

        [StringLength(255)]
        public string AcctField9 { get; set; }

        [StringLength(255)]
        public string AcctField10 { get; set; }

        [StringLength(255)]
        public string AcctField11 { get; set; }

        [StringLength(255)]
        public string AcctField12 { get; set; }

        [Column(TypeName = "text")]
        public string AdminNotes { get; set; }

        public DateTime LastUsed { get; set; }

        [Column(TypeName = "ntext")]
        public string ConfiguratorSettings { get; set; }


        public override Member ToModel(Member member)
        {
            // Here you can write code for custom mapping
            // supplier properties will be mapped in base method implementation by using value injection
            var retVal = base.ToModel(member) as VendorExtension;
            
            return retVal;
        }

        public override MemberDataEntity FromModel(Member member, PrimaryKeyResolvingMap pkMap)
        {
            var retVal = base.FromModel(member, pkMap) as VendorExtensionEntity;
            var vendor = member as VendorExtension;
            retVal.AcctRep = 0;
            retVal.LastUsed = DateTime.UtcNow;
            retVal.AdminNotes = string.Empty;

            // Here you can write code for custom mapping
            // supplier properties will be mapped in base method implementation by using value injection
            return retVal;
        }

        public override void Patch(MemberDataEntity target)
        {
            base.Patch(target);

            var vendorExtensionEntity = target as VendorExtensionEntity;
        }
    }
}
