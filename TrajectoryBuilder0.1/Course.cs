using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    class Course
    {
        private String name;
        private List<Competency> prerequisiteCompetencies;
        private List<Competency> postrequisiteCompetencies;

        public string Name
        {
            get
            {
                return name;
            }

        }

        public List<Competency> PrerequisiteCompetencies
        {
            get
            {
                return prerequisiteCompetencies;
            }
        }

        public List<Competency> PostrequisiteCompetencies
        {
            get
            {
                return postrequisiteCompetencies;
            }
        }

        public Course(string name)
        {
            this.name = name;
            this.prerequisiteCompetencies = new List<Competency>();
            this.postrequisiteCompetencies = new List<Competency>();
        }

        public Course(string name, List<Competency> pre, List<Competency> post)
        {
            this.name = name;
            this.prerequisiteCompetencies = pre;
            this.postrequisiteCompetencies = post;
        }

        public void addPrerequisite(Competency comp)
        {
            this.PrerequisiteCompetencies.Add(comp);
        }

        public void addPostrequisite(Competency comp)
        {
            this.PostrequisiteCompetencies.Add(comp);
        }

        public Course generateCourse(int qtyOfPreCompetencies, int qtyOfPostCompetencies)
        {
            for (int i = 1; i <= qtyOfPreCompetencies; i++)
            {
                Competency comp = new Competency("Competency" + i);
                this.addPrerequisite(comp);
            }
            for (int i = 1; i <= qtyOfPostCompetencies; i++)
            {
                Competency comp = new Competency("Competency" + i);
                this.addPostrequisite(comp);
            }

            printCourse(this);


            return this;
        }

        public void printCourse(Course course)
        {
            Console.WriteLine(course.Name);
            Console.WriteLine("Pre. Comp.:");
            if (course.prerequisiteCompetencies.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
                foreach (Competency preComp in course.PrerequisiteCompetencies)
                {
                    Console.Write(preComp.Name + ' ');
                }
            Console.WriteLine();
            Console.WriteLine("Post. Comp.:");
            if (course.postrequisiteCompetencies.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
                foreach (Competency postComp in course.PostrequisiteCompetencies)
                {
                    Console.Write(postComp.Name + ' ');
                }
            Console.WriteLine();
            Console.WriteLine("==============================");
        }
    }
}
