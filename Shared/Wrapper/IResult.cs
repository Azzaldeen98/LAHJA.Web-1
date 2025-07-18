﻿using System.Collections.Generic;

namespace Shared.Wrapper
{
    public interface IResult
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
        Failure Failure { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }

}