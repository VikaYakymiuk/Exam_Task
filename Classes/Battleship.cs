using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Classes
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode = false;
        public Battleship(string name, double armorThinkness, double mainWeaponCaliber, double speed, Captain captain) : base(name, armorThinkness, mainWeaponCaliber, speed, captain)
        {
            this.defaultArmorThinkness = 300;    
        }
        public bool SonarMode { get => this.sonarMode; set => this.sonarMode = value; }
        public void ToggleSonarMode()
        {
            this.sonarMode = !this.sonarMode;

            if (this.sonarMode)
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
            builder = this.SonarMode == false ? builder.AppendLine($" *Sonar mode OFF") : builder.AppendLine(" *Sonar mode ON");
            return builder.ToString().TrimEnd();
        }
    }
}
