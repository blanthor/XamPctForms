using System;
using System.Collections.Generic;
using System.Text;

namespace XamPctForms.DAL
{
    public interface IDatabasePathService
    {
        string GetPath(string fileName);
    }
}
