using Microsoft.Practices.Unity;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.CustomerExtModule.Web.Repositories;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerExtModule.Web.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.CustomerExtModule.Web.Migrations;
using VirtoCommerce.Domain.Customer.Model;
using System;
using VirtoCommerce.CustomerExtModule.Web.Services;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Domain.Customer.Events;
using VirtoCommerce.Domain.Commerce.Services;

namespace VirtoCommerce.CustomerExtModule.Web
{
    public class Module : ModuleBase
    {
        private const string _connectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }
        #region IModule Members

        public override void SetupDatabase()
        {
            using (var db = new CustomerExtensionRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<CustomerExtensionRepository, Configuration>();
                initializer.InitializeDatabase(db);
            }

            
        }

        public override void Initialize()
        {
            base.Initialize();

            _container.RegisterType<ICustomerRepository>(new InjectionFactory(c => new CustomerExtensionRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>(), new EntityPrimaryKeyGeneratorInterceptor())));

         
        }

        public override void PostInitialize()
        {
            Func<CustomerExtensionRepository> vendorExtRepositoryFactory = () => new CustomerExtensionRepository(_connectionStringName, new EntityPrimaryKeyGeneratorInterceptor(), _container.Resolve<AuditableInterceptor>());
            var vendorExtModuleMemberservice = new VendorMemberService(vendorExtRepositoryFactory, _container.Resolve<IDynamicPropertyService>(), _container.Resolve<ISecurityService>(), _container.Resolve<IEventPublisher<MemberChangingEvent>>(), _container.Resolve<ICommerceService>());

            AbstractTypeFactory<MemberDataEntity>.OverrideType<VendorDataEntity, VendorExtensionEntity>();
            AbstractTypeFactory<Member>.OverrideType<Vendor, VendorExtension>()
                                        .MapToType<VendorExtensionEntity>()
                                        .WithService(vendorExtModuleMemberservice);
        }

        #endregion
    }
}