using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    abstract class CompetencyGraph
    {
        private string name;
        private List<Competency> competencies;
        private List<Link> links;

        internal List<Competency> Competencies
        {
            get
            {
                return competencies;
            }
        }

        internal List<Link> Links
        {
            get
            {
                return links;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public CompetencyGraph(string name,List<Competency>comp,List<Link>links)
        {
            this.name = name;
            this.competencies = comp;
            this.links = links;
        }

        public CompetencyGraph(string name)
        {
            this.name = name;
            this.competencies = new List<Competency>();
            this.links = new List<Link>();
        }

        public void AddCompetency(Competency comp)
        {
            this.competencies.Add(comp);
        }

        public void AddLink(Link link)
        {
            links.Add(link);
        }

        // to-do remove link
        // to-do remove competency
    }
}
