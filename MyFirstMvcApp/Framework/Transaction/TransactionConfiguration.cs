using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using Castle.Core.Configuration;
using Framework.Utils;
using System.Reflection;

namespace Framework.Transaction
{
    public class TransactionConfiguration
    {
        
        public TransactionMode DefaultTransactionMode { get; private set; }
        public IsolationMode DefaultIsolationMode { get; private set; }
        public bool DefaultDistributed { get; private set; }

        private List<String> transactionalClasses = new List<String>();
        private List<Tuple<String, TransactionAttribute>> txDefinitions = new List<Tuple<String, TransactionAttribute>>();

        public IList<String> ClassDef { get { return transactionalClasses.AsReadOnly(); } }
        public IList<Tuple<String, TransactionAttribute>> MethodDef { get { return txDefinitions.AsReadOnly(); } }

        public TransactionConfiguration()
        {
            DefaultTransactionMode = TransactionMode.Requires;
            DefaultIsolationMode = IsolationMode.ReadCommitted;
            DefaultDistributed = false;
        }

        public void CollectConfig(IConfiguration config)
        {
            if (config == null)
            {
                return;
            }
            string txMode = config.Attributes["transaction"];
            string isolation = config.Attributes["isolation"];
            string isdistributed = config.Attributes["distributed"];
            DefaultTransactionMode = txMode.TryParseEnum<TransactionMode>(this.DefaultTransactionMode);

            DefaultIsolationMode = isolation.TryParseEnum<IsolationMode>(DefaultIsolationMode);

            DefaultDistributed = isdistributed.TryParseBool(this.DefaultDistributed);

            RegisterClass(config.Children["classes"]);
            RegiseterMethodDef(config.Children["methods"]);
        }

        private void RegisterClass(IConfiguration iConfiguration)
        {

            foreach (IConfiguration child in iConfiguration.Children)
            {
                AddClass(child.Attributes["name"]);
            }
        }

        private void RegiseterMethodDef(IConfiguration iConfiguration)
        {
            foreach (IConfiguration child in iConfiguration.Children)
            {
                string methodName = child.Attributes["name"];
                string txMode = child.Attributes["transaction"];
                string isolation = child.Attributes["isolation"];
                string isdistributed = child.Attributes["distributed"];
                TransactionAttribute attribute = new TransactionAttribute(txMode.TryParseEnum<TransactionMode>(this.DefaultTransactionMode)
                    , isolation.TryParseEnum<IsolationMode>(DefaultIsolationMode));

                attribute.Distributed = isdistributed.TryParseBool(this.DefaultDistributed);

                txDefinitions.Add(Tuple.Create(methodName, attribute));
            }
        }

        public TransactionConfiguration AddClass(string name)
        {
            if (name.EndsWith(".*") && name.Length == 2)
            {
                throw new Exception("The class name's format is wrong. Should be: A.B.C.*");
            }
            transactionalClasses.Add(name);
            return this;
        }

        public TransactionConfiguration AddClass(Type type)
        {
            AddClass(type.FullName);
            return this;
        }

        public TransactionConfiguration AddMethod(string methodName, TransactionMode txmode, IsolationMode isolation, bool distributed)
        {
            TransactionAttribute attribute = new TransactionAttribute(txmode, isolation);

            attribute.Distributed = distributed;
            txDefinitions.Add(Tuple.Create(methodName, attribute));
            return this;
        }

        public TransactionConfiguration AddMethod(string methodName, TransactionMode txmode, IsolationMode isolation)
        {
            return AddMethod(methodName, txmode, isolation, DefaultDistributed);
        }

        public TransactionConfiguration AddMethod(string methodName, TransactionMode txmode)
        {
            return AddMethod(methodName, txmode, DefaultIsolationMode, DefaultDistributed);
        }

        public TransactionConfiguration SetDefaultTransactionMode(TransactionMode txmode)
        {
            this.DefaultTransactionMode = txmode;
            return this;
        }

        public TransactionConfiguration SetDefaultTransactionMode(IsolationMode isolation)
        {
            this.DefaultIsolationMode = isolation;
            return this;
        }
        public TransactionConfiguration SetDefaultDistributed(bool distributed)
        {
            this.DefaultDistributed = distributed;
            return this;
        }

       
    }
}
