using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.Utils
{
    public static class ErrorCode
    {
        public static String DATA_CHANGED = "数据已经被修改，是否放弃修改？";
        public static String DELETE_REC = "是否继续删除数据？";
        public static String DELETE_POLICY = "是否删除保单？注意，保单删除之后，相关的客户信息都没有被删除。";
        public static String DELETE_CUSTOMER_RELATION = "是否解除与此客户的关系？注意，解除之后，已保存的客户信息并没有被删除。";
        public static String DELETE_CUSTOMER = "是否解删除客户？";
        public static String SAVE_SUCCESS = "保存成功！";
    }
}
