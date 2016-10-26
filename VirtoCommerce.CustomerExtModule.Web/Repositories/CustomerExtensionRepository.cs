using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.CustomerExtModule.Web.Model;
using VirtoCommerce.CustomerModule.Data.Model;

namespace VirtoCommerce.CustomerExtModule.Web.Repositories
{
    public class CustomerExtensionRepository : CustomerRepositoryImpl
    {
        public CustomerExtensionRepository()
        {

        }

        public CustomerExtensionRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region VendorExtensionEntity

            modelBuilder.Entity<VendorExtensionEntity>().HasKey(x => x.Id)
                            .Property(x => x.Id);
            modelBuilder.Entity<VendorExtensionEntity>().ToTable("VendorExtension");

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #region ICustomerRepository Members

        public IQueryable<VendorExtensionEntity> VendorExtensions
        {
            get
            {
                return GetAsQueryable<VendorExtensionEntity>();
            }
        }

        public override MemberDataEntity[] GetMembersByIds(string[] ids, string responseGroup = null, string[] memberTypes = null)
        {
            var retVal = base.GetMembersByIds(ids, responseGroup, memberTypes);
            var vendors = VendorExtensions.Where(x => ids.Contains(x.Id)).ToArray();
            return retVal;
        }

        #endregion
    }
}
