using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHelper
{
    public interface IDebuggableService
    {
        void Start(string[] args);
        void StopService();
        void Pause();
        void Continue();
    }
}
