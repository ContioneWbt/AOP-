using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Server_side : IExecute
    {
        #region 操作公共属性

        /// <summary>
        /// 是否启用事务
        /// </summary>
        private bool isTransaction;

        /// <summary>
        /// 执行类型
        /// </summary>
        private ActionEnum function;

        /// <summary>
        /// 二级科目ID
        /// </summary>
        protected long SubjectB;

        /// <summary>
        /// 凭证号
        /// </summary>
        public string Code { get; set; }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="function">方法</param>
        /// <param name="isTransaction">是否启用事务</param>
        public Server_side(ActionEnum function, bool isTransaction = true)
        {
            this.isTransaction = isTransaction;
            this.function = function;
        }


        /// <summary>
        /// 创建凭证操作的实例
        /// </summary>
        /// <typeparam name="T">凭证操作类</typeparam>
        /// <param name="v">凭证信息</param>
        /// <param name="isTran">是否启用事务</param>
        /// <returns></returns>
        public static IExecute GetInstance<T>(FE_VoucherEntity v, bool isTran = true) where T : Server_side, IExecute
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            object[] obj = { v, isTran };
            var _invoke = (IExecute)typeof(T).GetConstructors(flag)[0].Invoke(obj);
            return _invoke;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public CallBackResult Execute()
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var _CallBackResult = (CallBackResult)this.GetType().GetMethod(function.ToString(), flag).Invoke(this, null);
            return _CallBackResult;
        }

        #region 行为

        /// <summary>
        /// 插入凭证
        /// </summary>
        protected virtual void InsertVoucher()
        {

        }

        /// <summary>
        /// 更新凭证
        /// </summary>
        protected virtual void UpdateVoucher()
        {

        }

        /// <summary>
        /// 更新账户
        /// </summary>
        protected virtual void UpdateAccount()
        {

        }

        /// <summary>
        /// 更新银行
        /// </summary>
        protected virtual void UpdateBank()
        {

        }

        /// <summary>
        /// 通知业务部门
        /// </summary>
        protected virtual void Notice()
        {
            MethodInfo[] methods = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var m in methods)
            {
                NoticeAttribute attr = (NoticeAttribute)Attribute.GetCustomAttribute(m, typeof(NoticeAttribute));
                if (attr == null || attr.SubjectID == null) { continue; }

                if (attr.SubjectID.Count(o => o == SubjectB) == 1)
                {
                    try
                    {
                        // 调用方法
                        m.Invoke(this, null);
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected virtual void Verify()
        {

        }

        #endregion

        #region 操作

        /// <summary>
        /// 部门财务【发起支出】
        /// </summary>
        /// <returns></returns>
        protected CallBackResult LaunchPay()
        {
            // 1、插入凭证
            Action action = InsertVoucher;

            // 2、更改账户（减账）
            action += UpdateAccount;

            //3、通知业务部门
            //action += Notice;

            return Invoke(action);
        }

        /// <summary>
        /// 出纳【新建收款】
        /// </summary>
        /// <returns></returns>
        protected CallBackResult NewReceive()
        {
            // 1、插入凭证
            Action action = InsertVoucher;

            // 2、账户加账
            action += UpdateAccount;

            // 3、银行加账
            action += UpdateBank;

            return Invoke(action);
        }

        /// <summary>
        /// 出纳【回款】
        /// </summary>
        /// <returns></returns>
        protected CallBackResult Repayment()
        {
            // 1、插入凭证
            Action action = InsertVoucher;

            // 2、账户加账
            action += UpdateAccount;

            // 3、银行加账
            action += UpdateBank;

            return Invoke(action);
        }

        /// <summary>
        /// 出纳办理【支款待办】
        /// </summary>
        /// <returns></returns>
        protected CallBackResult Pay()
        {
            //1.验证凭证是否办理
            Action action = UpdateVoucher;

            return Invoke(action);
        }

        /// <summary>
        /// 出纳办理【收款待办】
        /// </summary>
        /// <returns></returns>
        protected CallBackResult Receive()
        {
            // 1、修改凭证
            Action action = UpdateVoucher;

            // 2、账户加账
            action += UpdateAccount;

            // 3、银行加账
            action += UpdateBank;

            return Invoke(action);
        }

        /// <summary>
        /// 凭证审核通过
        /// </summary>
        /// <returns></returns>
        protected CallBackResult AuditPass()
        {
            return Invoke(UpdateVoucher);
        }

        /// <summary>
        /// 作废
        /// </summary>
        /// <returns></returns>
        protected CallBackResult Invalid()
        {
            // 1、修改凭证
            Action action = UpdateVoucher;

            // 2、账户加账
            action += UpdateAccount;

            return Invoke(action);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        protected CallBackResult Upload()
        {
            // 1、修改凭证
            Action action = UpdateVoucher;

            // 2、支款待办 银行扣账
            action += UpdateBank;

            return Invoke(action);
        }

        /// <summary>
        /// 一收一支
        /// </summary>
        /// <returns></returns>
        protected CallBackResult ReceiveAndPay()
        {
            // 1、插入凭证
            Action action = InsertVoucher;

            // 2、银行加钱 扣钱
            action += UpdateBank;

            return Invoke(action);
        }

        #endregion

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="action">行为</param>
        /// <returns></returns>
        private CallBackResult Invoke(Action action)
        {
            CallBackResult result = new CallBackResult() { Status = 1, Msg = "成功" };

            // 是否发生异常
            bool isExcept = false;

            if (isTransaction)
            {
              //加事务操作
                try
                {
                    // 1、信息验证
                    Verify();

                    // 2、执行操作
                    if (action != null)
                    {
                        action.Invoke();//执行
                    }

                }
                catch (Exception ex)
                {
                    isExcept = true;
                    result.Status = 2;
                    result.Msg = ex.Message;
                }
                
            }
            else
            {
                try
                {
                    // 1、信息验证
                    Verify();

                    // 2、执行操作
                    if (action != null)
                    {
                        action();
                    }
                }
                catch (Exception ex)
                {
                    isExcept = true;
                    result.Status = 2;
                    result.Msg = ex.Message;
                }
            }

            if (!isExcept)
            {
                // 3、通知业务部门
                Notice();
            }
            return result;
        }
       
    }
}
