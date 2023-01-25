using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.VesselRepository
{
    public class VesselRepository
    {
        public List<IVessel> Models = new List<IVessel>();
        public void Add(IVessel vessel)
        {
            if (Models.Select(x => x.Name).Distinct().Count() == Models.Select(x => x.Name).Count())
            {
                this.Models.Add(vessel);
            }
            else
            {
                string Message = "Every vessel is unique and it is guaranteed that there will not be a vessel with the same name.";
                throw new Exception(Message);
            }
        }

        public void Remove(IVessel vessel)
        {
            if (Models.Any(x => x.Equals(vessel)))
            {
                this.Models.Remove(vessel);
                Console.WriteLine("Succesfull!");
            }
            else
            {
                throw new Exception();
            }
        }

        public IVessel FindByName(string name)
        {
            return (IVessel)Models.Select(x => x.Name).Where(x => x == name);  
        }
    }
}
