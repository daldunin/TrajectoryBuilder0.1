using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    class Link
    {
        private Competency initialCompetency;
        private Competency resultingCompetency;
        private List<Course> linkingCourses;
        public double rank;

        internal Competency InitialCompetency
        {
            get
            {
                return initialCompetency;
            }
        }

        internal Competency ResultingCompetency
        {
            get
            {
                return resultingCompetency;
            }
        }

        internal List<Course> LinkingCourses
        {
            get
            {
                return linkingCourses;
            }

            set
            {
                linkingCourses = value;
            }
        }

        public Link(Competency init, Competency result, Course course)
        {
            this.initialCompetency = init;
            this.resultingCompetency = result;
            this.linkingCourses = new List<Course>();
            this.LinkingCourses.Add(course);
        }


    }
}
