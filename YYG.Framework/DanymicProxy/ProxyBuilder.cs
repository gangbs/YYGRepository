using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
    public class ProxyBuilder<T> where T : class
    {
        readonly IInterceptor _interceptor;
        private AssemblyBuilder _assemblyBuilder;
        private ModuleBuilder _moduleBuilder;
        private TypeBuilder _typeBuilder;
        private FieldBuilder _privateFieldBuilder;
        
        public ProxyBuilder(IInterceptor interceptor)
        {
            this._interceptor = interceptor;
            BuilerAssembly();
            BuilderModule();
            BuilderType();
            BuilderPrivateField();
            BuilderConstructor();
            BuilderMethods();
        }

        public void BuilerAssembly(string assemblyName = null)
        {
            if (string.IsNullOrWhiteSpace(assemblyName)) assemblyName = typeof(T).Name + "ProxyAssembly";

            AssemblyName aName = new AssemblyName(assemblyName);
            AppDomain aDomain = AppDomain.CurrentDomain;//应用程序域，这里设为当前域
            _assemblyBuilder = aDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
        }

        public void BuilderModule(string moduleName = null)
        {
            if (string.IsNullOrWhiteSpace(moduleName)) moduleName = typeof(T).Name + "ProxyModule";
            this._moduleBuilder = this._assemblyBuilder.DefineDynamicModule(moduleName);
        }

        public void BuilderType(string typeName = null)
        {
            if (string.IsNullOrWhiteSpace(typeName)) typeName = typeof(T).Name + "Proxy";
            this._typeBuilder = this._moduleBuilder.DefineType(typeName, TypeAttributes.Public, typeof(T));//继承于T
        }

        public void BuilderPrivateField()
        {
            //定义私有字段
            this._privateFieldBuilder = this._typeBuilder.DefineField("_interceptor", typeof(IInterceptor), FieldAttributes.Private);
            //为私有变量赋值
            this._privateFieldBuilder.SetConstant(null);
        }

        public void BuilderConstructor()
        {
            ConstructorBuilder cstBuilder = this._typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,new Type[] { typeof(IInterceptor) });
            ILGenerator ctsGenerator = cstBuilder.GetILGenerator();
            ctsGenerator.Emit(OpCodes.Ldarg_0);
            ctsGenerator.Emit(OpCodes.Ldarg_1);
            //ctsGenerator.Emit(OpCodes.Newobj, typeof(K).GetConstructor(new Type[0]));//
            ctsGenerator.Emit(OpCodes.Stfld, this._privateFieldBuilder);//给字段赋值
            ctsGenerator.Emit(OpCodes.Ret);
        }

        public void BuilderMethods()
        {
            MethodInfo[] methods = typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Public);
            Type retType = null;
            Type[] paramsType = null;
            ParameterInfo[] parameters = null;
            MethodBuilder mdBuidler = null;
            ILGenerator mdGenerator = null;

            foreach (MethodInfo method in methods)
            {
                if (method.Name == "ToString" || method.Name == "Equals" || method.Name == "GetHashCode" || method.Name == "GetType") continue;

                //获得返回值类型
                retType = method.ReturnType;
                //获得参数类型
                parameters = method.GetParameters();
                paramsType = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; ++i)
                {
                    paramsType[i] = parameters[i].ParameterType;
                }
                mdBuidler = this._typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, retType, paramsType);
                mdGenerator = mdBuidler.GetILGenerator();
                mdGenerator.Emit(OpCodes.Ldarg_0);
                mdGenerator.Emit(OpCodes.Ldfld, this._privateFieldBuilder);
                mdGenerator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(new Type[0]));
                mdGenerator.Emit(OpCodes.Ldstr, method.Name);
                if (paramsType.Length == 0)
                {
                    mdGenerator.Emit(OpCodes.Ldnull);
                }
                else
                {
                    LocalBuilder paras = mdGenerator.DeclareLocal(typeof(object[]));
                    mdGenerator.Emit(OpCodes.Ldc_I4, paramsType.Length);
                    mdGenerator.Emit(OpCodes.Newarr, typeof(object));
                    mdGenerator.Emit(OpCodes.Stloc, paras);

                    for (var j = 0; j < paramsType.Length; j++)
                    {
                        mdGenerator.Emit(OpCodes.Ldloc, paras);
                        mdGenerator.Emit(OpCodes.Ldc_I4, j);
                        mdGenerator.Emit(OpCodes.Ldarg, j + 1);
                        mdGenerator.Emit(OpCodes.Stelem_Ref);
                    }
                    mdGenerator.Emit(OpCodes.Ldloc, paras);
                }
                mdGenerator.Emit(OpCodes.Callvirt, typeof(IInterceptor).GetMethod("Invoke"));
                if (retType == typeof(void))
                {
                    mdGenerator.Emit(OpCodes.Pop);
                }
                mdGenerator.Emit(OpCodes.Ret);
            }

        }

        public T GetInstance()
        {
            Type proxyType = this._typeBuilder.CreateType();
            return Activator.CreateInstance(proxyType, new object[] { this._interceptor }) as T;
        }
    }
}
