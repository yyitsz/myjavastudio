
namespace Framework.Transaction
{
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.Registration;
    using Castle.Services.Transaction;
    using Castle.Services.Transaction.IO;

    /// <summary>
    /// Augments the kernel to handle transactional components
    /// <code>
    /// <facility id="txManager"
    ///          type="Framework.Transaction.TransactionManagerFacility, Framework"
    ///          transaction="Requires" isolation="ReadCommitted" distributed="false">
    ///   <classes>
    ///       <class name="xxx.xxx.xxx" />
    ///       <class name="xxx.bbb.ccc" />
    ///   </classes>
    ///   <methods>
    ///       <method name="save*" transaction="Requires" isolation="ReadCommitted" distributed="false"  />
    ///       <method name="update*" transaction="Requires" isolation="ReadCommitted" distributed="false"  />
    ///   </methods>
    /// </facility>
    ///</code>
    /// </summary>
    public class TransactionManagerFacility : AbstractFacility
    {

        private TransactionConfiguration txConfig = new TransactionConfiguration();
        /// <summary>
        /// Constructor.
        /// </summary>
        public TransactionManagerFacility()
        {
        }



        /// <summary>
        /// Registers the interceptor component, the metainfo store and
        /// adds a contributor to the ModelBuilder
        /// </summary>
        protected override void Init()
        {
            Kernel.Register(Component.For<TransactionConfiguration>().Instance(txConfig).Named("TransactionManager.TransactionConfiguration"));

            Kernel.Register(
                Component.For<TransactionInterceptor>().Named("TransactionManager.interceptor"),
                Component.For<TransactionMetaInfoStore>().Named("TransactionManager.MetaInfoStore"),
               Component.For<ITransactionMatcher>().ImplementedBy<DefaultTransactionMatcher>().Named("TransactionManager.TransactionMatcher")
                );


            Kernel.ComponentModelBuilder.AddContributor(new TransactionComponentInspector());
            txConfig.CollectConfig(this.FacilityConfig);

        }

        public TransactionConfiguration Config()
        {
            return this.txConfig;
        }

        /// <summary>
        /// Disposes the facilitiy.
        /// </summary>
        protected override void Dispose()
        {
            base.Dispose();
        }


    }
}