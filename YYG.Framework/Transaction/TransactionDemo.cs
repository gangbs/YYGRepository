using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace YYG.Framework
{
   public class TransactionDemo
    {

        /// <summary>
        /// 普通的环境事务
        /// </summary>
        public void CommonTransactionScope()
        {
            using (var scope = new TransactionScope())
            {
               
            }
        }

        /// <summary>
        /// 嵌套的作用域和环境事务:定义嵌套作用域中的事务与根事务是否属同一事务
        /// </summary>
        public void AreasTransactionScope()
        {
            using (var scope1 = new TransactionScope())
            {
                //doSomething

                //TransactionScopeOption.Required表示与根事务同属一个事务
                //TransactionScopeOption.RequiresNew表示作用域内始终重新生成一个新事务
                using (var scope2 = new TransactionScope( TransactionScopeOption.Required))
                {

                }
            }



        }


        /// <summary>
        /// 多线程和环境事务：使用依赖事务，如果不使用依赖事务，则新建线程中的事务与主线程中的事务不是同一个事务
        /// </summary>
        public void DependentTransactionScope()
        {

            Action<DependentTransaction> fun = tran =>
            {
                Transaction.Current = tran;
                //事务处理

                using (var scope = new TransactionScope())
                {
                    
                }

            };

            
            //DependentCloneOption:根事务是否要等待依赖事务的结果
            using (var scope1 = new TransactionScope())
            {
                Task.Run(()=> 
                {
                    fun(Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete));
                });
                
            }
        }


        #region 说明

        //1.事务中的Complete()方法是设置事务的成功位，而并非提交事务
        //2.Commit方法是提交事务，使用using块的TransactionScope事务时，超出作用域时，会调用该事务的IDispose方法，调用该方法时提交或回滚事务
        //3.只有CommittableTransaction对象有Commit方法
        //4.Rollback()方法终止一个事务，撤销所有的改变
        //5.Transaction.Current返回当前的环境事务
        //6.EF中事务
        //6.1 普通的ef增删改在调用SaveChange()方法时已进行了事务处理
        //6.2 执行sql的，SaveChange()方法不起作用，但可用context.Database.BeginTransaction()来作事务处理

        #endregion

    }
}
