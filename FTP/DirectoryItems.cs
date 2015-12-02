using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    class DirectoryItems
    {
        public string nameFull { get; set; }
        public string name { get; set; }
        public string ext { get; set; }
        public bool isDirectory { get; set; }
        public DateTime dateTime { get; set; }

        public DirectoryItems(string os, string path, string line)
        {
            switch (os.ToUpper())
            {
                case "W":
                    name = line.Substring(39);
                    int i = name.LastIndexOf('.') + 1;
                    int l = name.Length;
                    if (i > 0 && l > 1)
                    {
                        ext = name.Substring(i, l - i);
                    }
                    else
                    {
                        ext = "";
                    }
                    nameFull = path + "/" + line.Substring(39);
                    dateTime = DateTime.Parse(line.Substring(0, 17));
                    if ("DIR".Equals(line.Substring(25, 3)))
                    {
                        isDirectory = true;
                    }
                    else
                    {
                        isDirectory = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
