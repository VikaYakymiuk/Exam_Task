using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Interfaces
{
    public interface ICaptain
    {
        string FullName { get; set; }
        int CombatExperience { get; set; }
        List<IVessel> Vessels { get; set; }
    }
}
