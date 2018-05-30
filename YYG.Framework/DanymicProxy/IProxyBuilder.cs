using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
//1.构建程序集

//2.定义模块

//3.创建类型

//4.定义属性、字段

//5.定义构造函数

//6.定义方法

//7.创建引用、调用方法

   public interface IProxyBuilder
    {
        AssemblyBuilder BuilerAssembly(string assemblyName);

        ModuleBuilder BuilderModule(string moduleName, string fileName);

        TypeBuilder BuilderType(string typeName);

        FieldBuilder BuilderField(string fieldName,Type tp);

        ConstructorBuilder BuilderConstructor(Type[] parameterTypes);

        void BuilderMethods();

        object GetProduct();
    }
}
