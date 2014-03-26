using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Services.Transaction;
using Castle.MicroKernel;
using Castle.Core.Logging;
using NHibernate.Type;

namespace Framework.Transaction
{
    public class TransactionTemplate
    {
        private IKernel kernel;
        private ILogger logger;
        ITransactionManager manager;
        TransactionConfiguration txConfig;
        public TransactionTemplate(IKernel kernel, ITransactionManager manager, ILogger logger, TransactionConfiguration txConfig)
        {
            this.kernel = kernel;
            this.logger = logger;
            this.manager = manager;
            this.txConfig = txConfig;
        }

        public T Execute<T>(Func<ITransaction, T> action)
        {
            return Execute(txConfig.DefaultTransactionMode, txConfig.DefaultIsolationMode, txConfig.DefaultDistributed, action);
        }



        public T Execute<T>(TransactionMode transactionMode,
           Func<ITransaction, T> action)
        {
            return Execute(transactionMode, txConfig.DefaultIsolationMode, txConfig.DefaultDistributed, action);
        }


        public T Execute<T>(TransactionMode transactionMode,
                IsolationMode isolationMode,
                Func<ITransaction, T> action)
        {
            return Execute(transactionMode, isolationMode, txConfig.DefaultDistributed, action);
        }


        public T Execute<T>(TransactionMode transactionMode,
            IsolationMode isolationMode,
            bool isDistributed,
            Func<ITransaction, T> action)
        {

            ITransaction transaction = manager.CreateTransaction(transactionMode, isolationMode, isDistributed);

            if (transaction == null)
            {
                return action(null);

            }

            transaction.Begin();

            bool rolledback = false;

            try
            {

                T result = action(transaction);

                if (transaction.IsRollbackOnlySet)
                {
                    logger.DebugFormat("Rolling back transaction {0}", transaction.GetHashCode());

                    rolledback = true;
                    transaction.Rollback();
                }
                else
                {
                    logger.DebugFormat("Committing transaction {0}", transaction.GetHashCode());

                    transaction.Commit();
                }
                return result;
            }
            catch (TransactionException ex)
            {
                // Whoops. Special case, let's throw without 
                // attempt to rollback anything

                if (logger.IsFatalEnabled)
                {
                    logger.Fatal("Fatal error during transaction processing", ex);
                }
                throw;
            }
            catch (Exception)
            {
                if (!rolledback)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat("Rolling back transaction {0} due to exception on method ",
                            transaction.GetHashCode());
                    }
                    transaction.Rollback();
                }

                throw;
            }
            finally
            {
                manager.Dispose(transaction);
            }
        }

        public void Execute(Action<ITransaction> action)
        {
            Execute(txConfig.DefaultTransactionMode, txConfig.DefaultIsolationMode, txConfig.DefaultDistributed, action);
        }

        public void Execute(TransactionMode transactionMode, Action<ITransaction> action)
        {
            Execute(transactionMode, txConfig.DefaultIsolationMode, txConfig.DefaultDistributed, action);
        }

        public void Execute(TransactionMode transactionMode,
           IsolationMode isolationMode,
           Action<ITransaction> action)
        {
            Execute(transactionMode, isolationMode, txConfig.DefaultDistributed, action);
        }

        public void Execute(TransactionMode transactionMode,
            IsolationMode isolationMode,
            bool isDistributed,
            Action<ITransaction> action)
        {
            Execute<bool>(transactionMode, isolationMode, isDistributed, tx =>
            {
                action(tx);
                return true;
            });
        }
    }

}
