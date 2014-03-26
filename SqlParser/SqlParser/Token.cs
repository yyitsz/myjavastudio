using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public enum Token
    {
        Unsupported,
        If,
        Where,
        ElseIf,
        Else,
        And,
        Or,
        In,
    }
}
