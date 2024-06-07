﻿using Newtonsoft.Json;

namespace ManhPT_MidAssignment.Domain.Exceptions
{
    public class BaseException
    {
        #region Fields

        public int ErrorCode { get; set; }

        public string? DevMessage { get; set; }

        public string? UserMessage { get; set; }

        public string? TraceId { get; set; }

        public string? MoreInfo { get; set; }

        public object? Errors { get; set; }
        #endregion

        #region Methods

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion
    }
}
