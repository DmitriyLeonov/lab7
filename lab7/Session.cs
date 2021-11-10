using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                Debug.Assert(experiment != null,"Значение не должно быть null");
                Exams.Add(experiment);
            }
            finally { }
        }

        public void SetCredits(Experiment experiment)
        {
            try
            {
                Credits.Add(experiment);
            }
            finally { }
        }

        public void DeleteExam(Experiment experiment)
        {
            try
            {
                Exams.Remove(experiment);
            }
            finally { }
        }

        public void DeleteCredit(Experiment experiment)
        {
            try
            {
                Credits.Remove(experiment);
            }
            finally { }
        }

        public List<Experiment> GetExamList()
        {
            try
            {
                return Exams;
            }
            finally { }
        }

        public List<Experiment> GetCreditList()
        {
            try { 
                return Credits;
            }
            finally { }
        }

        public void PrintExams()
        {
            try
            {
                foreach (Experiment experiment in Exams)
                {
                    Console.WriteLine(experiment.GetTheme());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { }
        }

        public void PrintCreditList()
        {
            try
            {
                foreach (Experiment experiment in Credits)
                {
                    Console.WriteLine(experiment.GetTheme());
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { }
        }
    }
}
