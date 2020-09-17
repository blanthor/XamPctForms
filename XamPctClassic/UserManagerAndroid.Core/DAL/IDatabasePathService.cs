using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagerAndroid.Core.DAL
{
    public interface IDatabasePathService
    {
        string GetPath(string fileName);
    }
}
