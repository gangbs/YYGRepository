using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.Extension
{
    public static class ModelStateDictionaryExtension
    {
        /// <summary>
        /// MVC返回验证信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this System.Web.Mvc.ModelStateDictionary dictionary)
        {
            string errorMsg = string.Empty;
            foreach (var item in dictionary.Values)
            {
                if (item.Errors != null && item.Errors.Count > 0)
                {
                    errorMsg = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return errorMsg;
        }

        /// <summary>
        /// WebApi返回验证信息
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this System.Web.Http.ModelBinding.ModelStateDictionary dictionary)
        {
            string errorMsg = string.Empty;
            foreach (var item in dictionary.Values)
            {
                if (item.Errors != null && item.Errors.Count > 0)
                {
                    errorMsg = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return errorMsg;
        }
    }
}
