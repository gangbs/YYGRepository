using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYG.DAL;
using YYG.Entity;
using YYG.IRepository;
using YYG.Repository;

namespace YYG.DAL.Facade
{
    public class UnitOfWork: IDisposable
    {
        readonly DbContext context;
        readonly IOC ioc;
        private Dictionary<string, object> dicRepository;

        public UnitOfWork()
        {
            ioc = new IOC();
            context = ioc.context;
            dicRepository = new Dictionary<string, object>();
        }
       
        public object GetRepository(Type type)
        {            
            string typeName = type.Name;
            if(!dicRepository.ContainsKey(typeName))
            {
                dicRepository.Add(typeName, ioc.GetService(type));
            }
            return dicRepository[typeName];
        }


        public int Save()
        {
            string errMsg = "";
            return Save(out errMsg);
        }
        public int Save(out string errMsg)
        {
            errMsg = "";
            int count = 0;
            try
            {
                count = context.SaveChanges();
            }
            catch (DbUpdateException exp)
            {
                errMsg = exp.InnerException.InnerException.Message;
            }
            return count;
        }



        //表示对象是否已被清除
        private bool disposed = false;

        //参数表示该方法是由IDisposable.Dispose()方法调用的，还是由析构函数调用的
        //非托管资源由IDisposable.Dispose()方法处理，析构函数不作处理
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            //该方法告诉垃圾回收器该对象已经不再需要调用其析构函数了
            GC.SuppressFinalize(this);
        }

        //析构函数
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
