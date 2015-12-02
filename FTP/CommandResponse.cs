using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    class CommandResponse
    {
        public string[] lines { get; set; }
        public string bannerMessage { get; set; }
        public string welcomeMessage { get; set; }
        public FtpStatusCode statusCode { get; set; }
        public string statusDescription { get; set; }
    }
}
