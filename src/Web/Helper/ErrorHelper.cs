using System;
using System.Collections.Generic;

namespace Web.Helper
{
    public class ErrorHelper
    {
        public static Dictionary<int, string> ErrorMsg = new Dictionary<int, string>(){
            {1,"Không tìm thấy sản phẩm"},
            {404,"Trang không tồn tại"}
        };

        public static string GetMsg(int code)
        {
            string msg = "";
            ErrorMsg.TryGetValue(code, out msg);
            return msg;
        }
    }

    public enum ErrorType
    {
        ProductNotFound,
    }
}