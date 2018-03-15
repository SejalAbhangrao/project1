using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Util
{
    public class ResponseConstants
    {
        public const int SUCCESS = 0;
        public const int SYSTEM_ERROR = 1001;
        public const int DATABASE_ERROR = 1002;
        public const int DUPLICATE_ERROR = 1003;
        public const int DUPLICATE_EMAIL_ERROR = 1004;
        public const int RECORD_NOT_FOUND = 2000;
        public const int OLD_PASSWORD_INCORRECT = 2001;
        public const int EMAIL_INCORRECT = 2002;
        public const int DATABASE_NOT_FOUND = 1005;
        public const int INVALID_ROLE = 1007;
        public const int INVALID_NEW_USER = 1009;
    }
}