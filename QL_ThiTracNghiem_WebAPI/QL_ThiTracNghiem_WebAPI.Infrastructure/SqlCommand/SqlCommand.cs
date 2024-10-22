using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand
{
    public class SqlCommand
    {
        // --------------------FUNCTION
        public const string GET_MAGV = "SELECT DBO.AUTO_MAGV('{0}', '{1}') AS MAGV";
        public const string GET_MAHOCPHAN = "SELECT DBO.AUTO_MAHOCPHAN() AS MAHOCPHAN";
        public const string GET_MASINHVIEN = "SELECT DBO.AUTO_STT_MASV('{0}', '{1}', '{2}') AS MASV";
        public const string GET_MALOPHOCPHAN = "SELECT DBO.AUTO_MALOPHOCPHAN('{0}') AS MALOPHOCPHAN";

        // --------------------PROCEDURE
        public const string GET_CT_LOPHOCPHAN = "EXEC GET_CT_LOPHOCPHAN '{0}'";
        public const string GET_DSSV_HOCPHAN = "EXEC GET_DSSV_HOCPHAN '{0}'";
        public const string UPDATE_LOPHOCPHAN = "SET DATEFORMAT DMY UPDATE CT_HOCPHAN SET MAGV = '{0}', THU = {1}, TIET = '{2}', PHONG = '{3}', NGAYBD = '{4}', NGAYKT = '{5}' WHERE MALOPHOCPHAN = '{6}'";
        public const string DELETE_LOPHOCPHAN = "DELETE FROM CT_HOCPHAN WHERE MALOPHOCPHAN = '{0}'";

    }
}
