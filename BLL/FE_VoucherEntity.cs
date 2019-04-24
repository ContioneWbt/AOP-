using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class FE_VoucherEntity
    {

    
        public long ID
        {
            get;set;
        }

        public string Code
        {
            get; set;
        }

   
        public string SourceCode
        {
            get; set;
        }

       
    
        public string OrderID
        {
            get; set;
        }

      
        public int BillType
        {
            get; set;
        }

      
        public int Type
        {
            get; set;
        }

  
        public long UseType
        {
            get; set;
        }

     
        public int SourceType
        {
            get; set;
        }

    
        public int PaymentType
        {
            get; set;
        }

  
        public long BandKID
        {
            get; set;
        }

    
        public string Summary1
        {
            get; set;
        }

     
        public string Summary2
        {
            get; set;
        }

   
        public string Summary3
        {
            get; set;
        }

     
        public string Summary4
        {
            get; set;
        }

     
        public long SubjectA1
        {
            get; set;
        }

   
        public long SubjectA2
        {
            get; set;
        }

     
        public long SubjectA3
        {
            get; set;
        }

      
        public long SubjectA4
        {
            get; set;
        }

   
        public long SubjectB1
        {
            get; set;
        }

    
        public long SubjectB2
        {
            get; set;
        }

    
        public long SubjectB3
        {
            get; set;
        }

     
    
        public long SubjectB4 {

            get; set;
        }

        public decimal Debit1 { 
        get; set;
        }

        public decimal Debit2
        {
            get; set;
        }

        private decimal _Debit3;
      
        public decimal Debit3
        {
            get; set;
        }

        public decimal Debit4
        {
            get; set;
        }

       
        public decimal DebitAll
        {
            get; set;
        }

      
        public decimal Credit1
        {
            get; set;
        }

     
        public decimal Credit2
        {
            get; set;
        }

    
        public decimal Credit3
        {
            get; set;
        }

      
        public decimal Credit4
        {
            get; set;
        }

        public decimal CreditAll
        {
            get; set;
        }

    
   
        public string CheckNo
        {
            get; set; 
        }

      
        public DateTime Time
        {
            get; set;
        }

    
        public int GrantStatus
        {
            get; set;
        }

    
        public string ImageURL
        {
            get; set;
        }

      
        public string SourceBy
        {
            get; set;
        }




        public string CreateBy
        {
            get; set;
        }

    
        public string Payee
        {
            get; set;
        }

        public string PayeeBankNo
        {
            get; set;
        }

        public string PayeeBankName
        {
            get; set;
        }

   
        public int Region
        {
            get; set;
        }

    
        public int Status
        {
            get; set;
        }

     
        public bool CanInvalid
        {
            get; set;
        }

        public DateTime UpdateDate
        {
            get; set;
        }

      
        public DateTime CreateDate
        {
            get; set;
        }

    
        public byte Pattern
        {
            get; set;
        }

     
       
        public byte AccountType2
        {
            get; set;
        }

      

        #region 项目回款用到的额外字段

        /// <summary>
        /// 是否冲预收
        /// </summary>
        public bool IsPrePaid { get; set; }

        ///// <summary>
        ///// 回款批次
        ///// </summary>
        //public FE_ReceivableDetailsEntity.PeriodEnum Period { get; set; }

        ///// <summary>
        ///// 回款批次 类型
        ///// </summary>
        //public FE_ReceivableDetailsEntity.TypeEnum BackType { get; set; }

        /// <summary>
        /// 回款批次ID
        /// </summary>
        public int BackPeriodID { get; set; }

        #endregion


        /// <summary>
        /// 凭证办理状态
        /// </summary>
        public enum GrantStatusEnum
        {
            [Description("待收")]
            待付 = 1,
            [Description("收款中")]
            支付中 = 2,
            [Description("已收")]
            已付 = 3,
            [Description("集审")]
            集审 = 4
        }

        /// <summary>
        /// 类型
        /// </summary>
        public enum TypeEnum
        {
            收 = 0,
            支 = 1,
            一收一支 = 2
        }

        public enum PatternEnum
        {
            传统 = 1,
            划转 = 2,
            分账 = 3
        }

        public enum StatusEnum
        {
            正常 = 1,
            作废 = 3
        }


        private class CodeModel
        {
            public string Code { get; set; }
        }
    }
}
