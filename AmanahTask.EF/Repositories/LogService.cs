using AmanahTask.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.EF.Repositories
{
    public class LogService : ILogService 
    {
        public void Log(string FolderName, string FileName,string ex) 
        {
            System.IO.File.WriteAllText(@$"C:\{FolderName}\{FileName}.txt", ex);
        }
    }
}
