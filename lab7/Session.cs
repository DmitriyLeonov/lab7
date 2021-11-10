using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Session
    {
        public List<Experiment> Exams = new List<Experiment>();
        public List<Experiment> Credits = new List<Experiment>();

        public void SetExams(Experiment experiment)
        {
            Exams.Add(experiment);
        }

        public void SetCredits(Experiment experiment)
        {
            Credits.Add(experiment);
        }

        public void DeleteExam(Experiment experiment)
        {
            Exams.Remove(experiment);
        }

        public void DeleteCredit(Experiment experiment)
        {
            Credits.Remove(experiment);
        }

        public List<Experiment> GetExamList()
        {
            return Exams;
        }

        public List<Experiment> GetCreditList()
        {
            return Credits;
        }

        public void PrintExams()
        {
            foreach (Experiment experiment in Exams)
            {
                Console.WriteLine(experiment.GetTheme());
            }
        }

        public void PrintCreditList()
        {
            foreach (Experiment experiment in Credits)
            {
                Console.WriteLine(experiment.GetTheme());
            }
        }
    }
}
