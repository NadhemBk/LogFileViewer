using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Models
{
    public class LogData
    {
        /// <summary>
        /// Gets or sets the date of the underlying recorded log activity.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the loglevel of the underlying recorded log activity.
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the message of the underlying recorded log activity.
        /// </summary>
        public string Message { get; set; }
    }
}
