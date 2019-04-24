using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Obase
{
    public class OperBase : Server_side
    {
        FE_VoucherEntity curr = new FE_VoucherEntity();
        protected OperBase(FE_VoucherEntity v, bool isTransaction = true)
            : base(ActionEnum.LaunchPay, isTransaction)
        {
            curr = v;
        }
        protected override void Verify()
        {
            base.Verify();

            Console.WriteLine("验证通过了！");
        }
        protected override void InsertVoucher()
        {
            //base.InsertVoucher();
            Console.WriteLine("添加凭证了！");

        }

        protected override void UpdateAccount()
        {
            base.UpdateAccount();
            //从账户里面扣钱
            Console.WriteLine("账户扣钱了！");
        }
        protected override void Notice()
        {
            SubjectB = 20;
            base.Notice();
        }

        /// <summary>
        /// 20代表什么
        /// </summary>
        [Notice(20)]
        private void Notice1()
        {
            Console.WriteLine("进来了！");
        }
    }
}