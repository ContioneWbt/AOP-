using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IExecute
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        CallBackResult Execute();

        /// <summary>
        /// 凭证号
        /// </summary>
        string Code { get; set; }
    }
}
