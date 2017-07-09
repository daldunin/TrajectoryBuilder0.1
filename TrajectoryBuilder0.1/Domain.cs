using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    class Domain : CompetencyGraph
    {
        public Domain(string name) : base(name)
        {

        }

        public Domain generateDomainGraph(int qtyOfCourses, int maxQtyOfPreCompetenciesPerCourse, int maxQtyOfPostCompetenciesPerCourse)
        {
            Random rnd = new Random();
            for (int i = 1; i <= qtyOfCourses; i++)
            {
                Course course = new Course("Course" + i);
                course.generateCourse(
                    rnd.Next(1, maxQtyOfPreCompetenciesPerCourse + 1),
                    rnd.Next(1, maxQtyOfPostCompetenciesPerCourse + 1));
                foreach (Competency compOfCourse in course.PrerequisiteCompetencies)
                {
                    //recursion here
                    addCompetencyAndLinksToDomain(this, course, compOfCourse, null);
                }
            }
            return this;
        }

        private void addCompetencyAndLinksToDomain(Domain domain, Course course, Competency compOfCourse, Competency prevComp)
        {
            bool compFound = false;
            foreach (Competency compOfDomain in domain.Competencies)
            {
                if (compOfCourse.Name == compOfDomain.Name)
                {
                    compFound = true;
                    break;
                }
            }
            if (!compFound)
            {
                domain.AddCompetency(compOfCourse);
            }

            if (prevComp != null)
            {
                bool linkFound = false;
                foreach (Link link in domain.Links)
                {
                    if ((link.InitialCompetency.Name == prevComp.Name) && (link.ResultingCompetency.Name == compOfCourse.Name))
                    {
                        linkFound = true;
                        bool linkingCourseFound = false;
                        foreach(Course linkingCourse in link.LinkingCourses)
                        {
                            if (linkingCourse.Name == course.Name)
                            {
                                linkingCourseFound = true;
                                break;
                            }
                        }
                        if (!linkingCourseFound)
                        {
                            link.LinkingCourses.Add(course);
                        }
                    }
                }
                if (!linkFound)
                {
                    Link link = new Link(prevComp, compOfCourse, course);
                    domain.AddLink(link);
                }

            }

            if (prevComp == null)
            {
                foreach (Competency postComp in course.PostrequisiteCompetencies)
                {
                    addCompetencyAndLinksToDomain(domain, course, postComp, compOfCourse);
                }
            }

        }

        public void printDomain()
        {
            Console.WriteLine();
            Console.WriteLine("Domain description");
            foreach (Link link in this.Links)
            {
                Console.Write("Link: {0} to {1} by courses ", link.InitialCompetency.Name, link.ResultingCompetency.Name);
                foreach (Course course in link.LinkingCourses)
                {
                    Console.Write(course.Name + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
