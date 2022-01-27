using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanahTask.Core.Interfaces
{
    public interface ILogService
    {
        void Log(string FolderName, string FileName, string ex); 
    }
}
