using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Obase;
using Newtonsoft.Json;

namespace AopConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FE_VoucherEntity parm = new FE_VoucherEntity();
            IExecute exe = Server_side.GetInstance<OperBase>(parm, true);
            CallBackResult model = exe.Execute();
            Console.WriteLine($"{JsonConvert.SerializeObject(model)}");
        }
    }
}
