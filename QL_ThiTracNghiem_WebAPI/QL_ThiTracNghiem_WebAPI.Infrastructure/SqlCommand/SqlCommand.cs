﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand
{
    public class SqlCommand
    {
        public const string GET_MAGV = "SELECT DBO.AUTO_MAGV('{0}', '{1}') AS MAGV";
        public const string GET_MAHOCPHAN = "SELECT DBO.AUTO_MAHOCPHAN() AS MAHOCPHAN";
        public const string GET_MASINHVIEN = "SELECT DBO.AUTO_STT_MASV('{0}', '{1}', '{2}') AS MASV";
    }
}
