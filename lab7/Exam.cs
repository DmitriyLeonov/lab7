using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    partial class Exam : Experiment
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public string GetInfo()
        {
            return this.Subject + "-" + this.Lecturer.Name + "-" + this.ExamDate.Date + "\n";
        }

        public override string GetTheme()
        {
            return this.GetInfo();
        }

        public override DateTime GetDate()
        {
            return this.ExamDate;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            return "Theme";
        }
    }
}
