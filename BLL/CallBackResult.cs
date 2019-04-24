﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CallBackResult
    {
        /// <summary>
        /// 1、成功 2、失败
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
    }
}
