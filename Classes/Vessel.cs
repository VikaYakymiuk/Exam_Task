using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Classes
{
    public abstract class Vessel : IVessel
    {
        protected double defaultArmorThinkness; 
        private string name;
        private double armorThinkness;
        private double mainWeaponCaliber;
        private double speed;
        private StringCollection targets;
        private Captain getCaptain = new Captain();
        public Vessel(string name, double armorThinkness, double mainWeaponCaliber, double speed, Captain captain)
        {
            this.Name = name;
            this.ArmorThinkness = armorThinkness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.Targets = new StringCollection();
            this.GetCaptain = captain;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length <= 3)
                {
                    string Message = "Vessel name cannot be null or empty.";
                    throw new ArgumentNullException(Message);
                }
                this.name = value;
            }
        }
        public double ArmorThinkness { get => this.armorThinkness; set => this.armorThinkness = value; }
        public double MainWeaponCaliber { get => this.mainWeaponCaliber; set => this.mainWeaponCaliber = value; }
        public double Speed { get => this.speed; set => this.speed = value; }
        public StringCollection Targets { get => this.targets; set => this.targets = value; }
        public Captain GetCaptain
        {
            get => this.getCaptain;
            set
            {
                if (this.getCaptain == null)
                {
                    string Message = "Captain cannot be null.";
                    throw new NullReferenceException(Message);
                }
                this.getCaptain = value;
            }
        }
        public void Attack(IVessel Target)
        {
            if (Target == null) throw new NullReferenceException("Target cannot be null.");

            Target.ArmorThinkness -= this.MainWeaponCaliber;

            if (Target.ArmorThinkness <= 0) Target.ArmorThinkness = 0;

            this.Targets.Add(Target.Name);
        }
        protected void RepairVessel() => this.ArmorThinkness = this.defaultArmorThinkness;
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder().AppendLine($"---> {this.Name}");
            builder.AppendLine($" *Type: {this.GetType().Name}");
            builder.AppendLine($" *Armor thickness: {this.ArmorThinkness}");
            builder.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            builder.AppendLine($" *Speed: {this.Speed} knots");
            builder.Append($" *Targets: ");

            if (this.Targets.Count == 0)
            {
                builder.Append("None");
            }
            else
            {
                for (int i = 0; i < this.Targets.Count; i++)
                {
                    builder.Append($"{Targets[i]}, ");
                }
            }
            
            return builder.ToString().TrimEnd();
        }
    }
}
