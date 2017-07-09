using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Domain domain = new Domain("Domain");
            domain.generateDomainGraph(3, 3, 3);
            domain.printDomain();
            Console.ReadKey();
        }



        private void addCompetencyAndLinksToDomain(Domain domain, Course course, Competency compOfCourse, Competency prevComp, List<Competency> postCompetencies)
        {
            bool compFound = false;
            foreach (Competency compOfDomain in domain.Competencies)
            {
                if (compOfCourse == compOfDomain)
                {
                    compFound = true;
                    break;
                }
                if (!compFound)
                {
                    domain.AddCompetency(compOfCourse);
                    if (prevComp != null)
                    {
                        bool linkFound = false;
                        foreach (Link link in domain.Links)
                        {
                            if ((link.InitialCompetency == prevComp) && (link.ResultingCompetency == compOfCourse))
                            {
                                linkFound = true;
                            }
                        }
                        if (!linkFound)
                        {
                            Link link = new Link(prevComp, compOfCourse, course);
                        }
                    }
                }

                if (prevComp == null)
                {
                    foreach (Competency postComp in postCompetencies)
                    {
                        addCompetencyAndLinksToDomain(domain, course, postComp, compOfCourse, null);
                    }
                }
            }
        }








    }
}
