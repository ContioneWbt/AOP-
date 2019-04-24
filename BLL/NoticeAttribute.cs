using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 通知业务部门 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NoticeAttribute : Attribute
    {
        private int[] subjectID;

        /// <summary>
        /// 流程处理科目
        /// </summary>
        public int[] SubjectID
        {
            get { return subjectID; }
            set { subjectID = value; }
        }

        public NoticeAttribute(params int[] subjectID)
        {
            this.subjectID = subjectID;
        }
    }

    #region 操作类型
    public enum ActionEnum
    {
        /// <summary>
        /// 部门财务【发起支出】
        /// </summary>
        LaunchPay,

        /// <summary>
        /// 出纳【新建收款】
        /// </summary>
        NewReceive,

        /// <summary>
        /// 出纳【回款】
        /// </summary>
        Repayment,

        /// <summary>
        /// 审核通过
        /// </summary>
        AuditPass,

        /// <summary>
        /// 出纳办理【支款待办】
        /// </summary>
        Pay,

        /// <summary>
        /// 出纳办理【收款待办】
        /// </summary>
        Receive,

        /// <summary>
        /// 作废
        /// </summary>
        Invalid,

        /// <summary>
        /// 上传附件
        /// </summary>
        Upload,

        /// <summary>
        /// 一收一支
        /// </summary>
        ReceiveAndPay
    }
    #endregion
}
