using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using YYG.Framework;
using YYG.Framework.Quartz;

namespace YYG.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //HostFactory.Run(x =>
            //{
            //    x.Service<ScheduleServer>();

            //    x.SetDescription("TDR任务调度服务");
            //    x.SetDisplayName("TDR任务调度服务");
            //    x.SetServiceName("TDR任务调度服务");

            //    x.EnablePauseAndContinue();

            //});

            //var t = new RedisTest();
            //t.Test();  

            //Proxy<TestClass>.CreateProxy(new DemoInterceptor()).ShowMessage(6);

            //var command = Proxy.Of<Command>();
            //command.Execute();

            //System.Console.WriteLine("Hi, Dennis, great, we got the interceptor works.");
            //System.Console.ReadLine();

            BuildTest();

        }


        static void BuildTest()
        {
            var builder = new ProxyBuilder<TestClass>(new DemoInterceptor());
            builder.GetInstance().ShowMessage2();

        }
    }

    public class Command
    {
        public virtual void Execute()
        {
            System.Console.WriteLine("Command executing...");
            System.Console.WriteLine("Hello Kitty!");
            System.Console.WriteLine("Command executed.");
        }
    }

    public class Interceptor
    {
        public object Invoke(object @object, string @method, object[] parameters)
        {
            System.Console.WriteLine(
              string.Format("Interceptor does something before invoke [{0}]...", @method));

            var retObj = @object.GetType().GetMethod(@method).Invoke(@object, parameters);

            System.Console.WriteLine(
              string.Format("Interceptor does something after invoke [{0}]...", @method));

            return retObj;
        }
    }

    public class Proxy
    {
        public static T Of<T>() where T : class, new()
        {
            string nameOfAssembly = typeof(T).Name + "ProxyAssembly";
            string nameOfModule = typeof(T).Name + "ProxyModule";
            string nameOfType = typeof(T).Name + "Proxy";

            var assemblyName = new AssemblyName(nameOfAssembly);
            var assembly = AppDomain.CurrentDomain
              .DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assembly.DefineDynamicModule(nameOfModule);

            var typeBuilder = moduleBuilder.DefineType(
              nameOfType, TypeAttributes.Public, typeof(T));

            InjectInterceptor<T>(typeBuilder);

            var t = typeBuilder.CreateType();

            return Activator.CreateInstance(t) as T;
        }

        private static void InjectInterceptor<T>(TypeBuilder typeBuilder)
        {
            // ---- define fields ----

            var fieldInterceptor = typeBuilder.DefineField(
              "_interceptor", typeof(Interceptor), FieldAttributes.Private);

            // ---- define costructors ----

            var constructorBuilder = typeBuilder.DefineConstructor(
              MethodAttributes.Public, CallingConventions.Standard, null);
            var ilOfCtor = constructorBuilder.GetILGenerator();

            ilOfCtor.Emit(OpCodes.Ldarg_0);
            ilOfCtor.Emit(OpCodes.Newobj, typeof(Interceptor).GetConstructor(new Type[0]));
            ilOfCtor.Emit(OpCodes.Stfld, fieldInterceptor);
            ilOfCtor.Emit(OpCodes.Ret);

            // ---- define methods ----

            var methodsOfType = typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Instance);

            for (var i = 0; i < methodsOfType.Length; i++)
            {
                var method = methodsOfType[i];
                var methodParameterTypes =
                  method.GetParameters().Select(p => p.ParameterType).ToArray();

                var methodBuilder = typeBuilder.DefineMethod(
                  method.Name,
                  MethodAttributes.Public | MethodAttributes.Virtual,
                  CallingConventions.Standard,
                  method.ReturnType,
                  methodParameterTypes);

                var ilOfMethod = methodBuilder.GetILGenerator();
                ilOfMethod.Emit(OpCodes.Ldarg_0);
                ilOfMethod.Emit(OpCodes.Ldfld, fieldInterceptor);

                // create instance of T
                ilOfMethod.Emit(OpCodes.Newobj, typeof(T).GetConstructor(new Type[0]));
                ilOfMethod.Emit(OpCodes.Ldstr, method.Name);

                // build the method parameters
                if (methodParameterTypes == null)
                {
                    ilOfMethod.Emit(OpCodes.Ldnull);
                }
                else
                {
                    var parameters = ilOfMethod.DeclareLocal(typeof(object[]));
                    ilOfMethod.Emit(OpCodes.Ldc_I4, methodParameterTypes.Length);
                    ilOfMethod.Emit(OpCodes.Newarr, typeof(object));
                    ilOfMethod.Emit(OpCodes.Stloc, parameters);

                    for (var j = 0; j < methodParameterTypes.Length; j++)
                    {
                        ilOfMethod.Emit(OpCodes.Ldloc, parameters);
                        ilOfMethod.Emit(OpCodes.Ldc_I4, j);
                        ilOfMethod.Emit(OpCodes.Ldarg, j + 1);
                        ilOfMethod.Emit(OpCodes.Stelem_Ref);
                    }
                    ilOfMethod.Emit(OpCodes.Ldloc, parameters);
                }

                // call Invoke() method of Interceptor
                ilOfMethod.Emit(OpCodes.Callvirt, typeof(Interceptor).GetMethod("Invoke"));

                // pop the stack if return void
                if (method.ReturnType == typeof(void))
                {
                    ilOfMethod.Emit(OpCodes.Pop);
                }

                // complete
                ilOfMethod.Emit(OpCodes.Ret);
            }
        }

    }

    

}
