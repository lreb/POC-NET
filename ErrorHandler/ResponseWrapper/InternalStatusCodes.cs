using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandler.ResponseWrapper
{
    public class InternalStatusCodes
    {
    }

    
    /// <summary>
    /// All success internal codes
    /// </summary>
    public enum InternalSuccessStatuses
    {
        /// <summary>
        /// Here is an internal code for error
        /// </summary>
        [Description("Here is an internal code for success")]
        S001,
        /// <summary>
        /// Here is another internal code for error
        /// </summary>
        [Description("Here is another internal code for success")]
        S002
    }

    /// <summary>
    /// All error internal codes
    /// </summary>
    public enum InternalErrorStatuses
    {
        /// <summary>
        /// Here is an internal code for error
        /// </summary>
        [Description("Here is an internal code for error")]
        E001,
        /// <summary>
        /// Here is another internal code for error
        /// </summary>
        [Description("Here is another internal code for error")]
        E002
    }

    /// <summary>
    /// All warning internal codes
    /// </summary>
    public enum InternalWarningStatuses
    {
        /// <summary>
        /// Here is an internal code for warning
        /// </summary>
        [Description("Here is an internal code for warning")]
        W001,
        /// <summary>
        /// Here is another internal code for warning
        /// </summary>
        [Description("Here is another internal code for warning")]
        W002,
    }
}
