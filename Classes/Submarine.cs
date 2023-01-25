using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Classes
{
    internal class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;

        public Submarine(string name, double armorThinkness, double mainWeaponCaliber, double speed, Captain captain) : base(name, armorThinkness, mainWeaponCaliber, speed, captain)
        {
            this.defaultArmorThinkness = 200;
        }
        public bool SubmergeMode { get => this.submergeMode; set => this.submergeMode = value; }
        public void ToggleSubmergeMode()
        {
            this.submergeMode = !this.submergeMode;
            if (this.submergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public new void RepairVessel()
        {
            if (this.ArmorThinkness < this.defaultArmorThinkness)
            {
                this.ArmorThinkness = this.defaultArmorThinkness;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder().AppendLine(base.ToString());
            builder = this.SubmergeMode == false ? builder.AppendLine($" *Submerge mode OFF") : builder.AppendLine(" *Submerge mode ON");
            return builder.ToString().TrimEnd();
        }
    }
}
