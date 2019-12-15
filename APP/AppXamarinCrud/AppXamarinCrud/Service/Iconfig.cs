using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace VideogameDatabase.Service
{
    public interface IConfig
    {
        string DirDB { get; }
    } 
}
