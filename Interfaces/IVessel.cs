using Exam_Task.Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Interfaces
{
    public interface IVessel
    {
        string Name { get; set; }
        double ArmorThinkness { get; set; }
        double MainWeaponCaliber { get; set; }
        double Speed { get; set; }
        StringCollection Targets { get; set; }
        Captain GetCaptain { get; set; }
    }
}
