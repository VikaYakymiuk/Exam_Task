using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task.Classes
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private List<IVessel> GetVessels;

        public Captain()
        {
        }

        public Captain(string fullName = "Tomas")
        {
            this.FullName = fullName;
            this.GetVessels = new List<IVessel>();
        }
        public string FullName 
        { 
            get => this.fullName; 
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    string Message = "Captain full name cannot be null or empty string.";
                    throw new ArgumentNullException(Message);
                }
                this.fullName = value;
            }
        }
        public int CombatExperience { get => this.combatExperience; set => this.combatExperience = value; }
        public List<IVessel> Vessels { get => this.GetVessels; set => this.GetVessels = value; }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            else
            {
                this.Vessels.Add(vessel);
            }
        }
        public void IncreaseCombatExperience()
        {
            if (this.Vessels.Any(x => x.Targets.Count > 0))
            {
                this.CombatExperience += 10;
            }
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder()
                .AppendLine($"{FullName} has {CombatExperience} combat experience and commands {this.Vessels.Count} vessels");
            
            if (this.Vessels.Count > 0)
            {
                for (int i = 0; i < this.Vessels.Count; i++)
                {
                    builder.AppendLine($"---> {Vessels[i].Name}");
                    builder.AppendLine($" *Type: {Vessels[i].GetType()}");
                    builder.AppendLine($" *Armor thickness: {Vessels[i].ArmorThinkness}");
                    builder.AppendLine($" *Main weapon caliber: {Vessels[i].MainWeaponCaliber}");
                    builder.AppendLine($" *Speed: {Vessels[i].Speed} knots");
                    builder.Append($" *Targets: ");

                    if (Vessels[i].Targets.Count == 0)
                    {
                        builder.Append("None");
                    }
                    else
                    {
                        for (int j = 0; j < Vessels[i].Targets.Count; j++)
                        {
                            builder.Append($"{Vessels[i].Targets[j]}, ");
                        }
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
