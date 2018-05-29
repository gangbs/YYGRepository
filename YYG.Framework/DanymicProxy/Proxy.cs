using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.DanymicProxy
{
    public class Proxy<T> where T : class
    {
        public static T CreateProxy(IInterceptor interceptor)
        {
            //构建程序集
            AssemblyName aName = new AssemblyName("Cmj.DotNet");
            AppDomain aDomain = AppDomain.CurrentDomain;//应用程序域，这里设为当前域
            AssemblyBuilder aBuidler = aDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
            //定义模块
            ModuleBuilder mBuidler = aBuidler.DefineDynamicModule("MyModule", "Cmj.DotNet.dll");
            //创建类型(其实就是一个类)
            StringBuilder sbClassName = new StringBuilder("Cmj.DotNet.");
            sbClassName.Append(typeof(T).Name);
            sbClassName.Append("Proxy");
            TypeBuilder tBuidler = mBuidler.DefineType(sbClassName.ToString(), TypeAttributes.Public | TypeAttributes.Class, typeof(T));//继承于T

            //--实现类--//
            //定义私有字段
            FieldBuilder fbInterceptor = tBuidler.DefineField("_interceptor", typeof(IInterceptor), FieldAttributes.Private);
            //为私有变量赋值
            fbInterceptor.SetConstant(null);
            //定义构造函数
            ConstructorBuilder ctstBuilder = tBuidler.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(IInterceptor) });
            ILGenerator ctstGenerator = ctstBuilder.GetILGenerator();
            ctstGenerator.Emit(OpCodes.Ldarg_0);
            ctstGenerator.Emit(OpCodes.Ldarg_1);
            ctstGenerator.Emit(OpCodes.Stfld, fbInterceptor);//给字段赋值
            ctstGenerator.Emit(OpCodes.Ret);
            //定义方法
            MethodInfo[] methods = typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Public);
            Type retType = null;
            Type[] paramsType = null;
            ParameterInfo[] parameters = null;
            MethodBuilder mtdBuidler = null;
            ILGenerator mtdGenerator = null;
            foreach (MethodInfo method in methods)
            {
                if (method.Name != "ToString" && method.Name != "Equals" && method.Name != "GetHashCode" && method.Name != "GetType")
                {
                    //获得返回值类型
                    retType = method.ReturnType;
                    //获得参数类型
                    parameters = method.GetParameters();
                    paramsType = new Type[parameters.Length];
                    for (int i = 0; i < parameters.Length; ++i)
                    {
                        paramsType[i] = parameters[i].ParameterType;
                    }
                    //实现方法体 
                    mtdBuidler = tBuidler.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, retType, paramsType);
                    mtdGenerator = mtdBuidler.GetILGenerator();
                    mtdGenerator.Emit(OpCodes.Ldarg_0);
                    mtdGenerator.Emit(OpCodes.Ldfld, fbInterceptor);
                    mtdGenerator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(new Type[0]));
                    mtdGenerator.Emit(OpCodes.Ldstr, method.Name);
                    if (paramsType.Length == 0)
                    {
                        mtdGenerator.Emit(OpCodes.Ldnull);
                    }
                    else
                    {
                        LocalBuilder paras = mtdGenerator.DeclareLocal(typeof(object[]));
                        mtdGenerator.Emit(OpCodes.Ldc_I4, paramsType.Length);
                        mtdGenerator.Emit(OpCodes.Newarr, typeof(object));
                        mtdGenerator.Emit(OpCodes.Stloc, paras);

                        for (var j = 0; j < paramsType.Length; j++)
                        {
                            mtdGenerator.Emit(OpCodes.Ldloc, paras);
                            mtdGenerator.Emit(OpCodes.Ldc_I4, j);
                            mtdGenerator.Emit(OpCodes.Ldarg, j + 1);

                            mtdGenerator.Emit(OpCodes.Stelem_Ref);
                        }
                        mtdGenerator.Emit(OpCodes.Ldloc, paras);
                    }
                    mtdGenerator.Emit(OpCodes.Callvirt, typeof(IInterceptor).GetMethod("Invoke"));
                    if (retType == typeof(void))
                    {
                        mtdGenerator.Emit(OpCodes.Pop);
                    }
                    mtdGenerator.Emit(OpCodes.Ret);
                }
            }

            //创建引用、调用方法
            Type proxyType = tBuidler.CreateType();
            aBuidler.Save("Cmj.DotNet.dll");
            object proxy = Activator.CreateInstance(proxyType, new object[]{ interceptor});//实例化
            return proxy as T;
        }

        public interface IInterceptor
        {
            object Invoke(object obj, string methodName, object[] parameters);
        }
}
}
