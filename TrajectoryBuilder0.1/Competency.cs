using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder0._1
{
    class Competency
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }
        }
        
        public Competency(string name)
        {
            this.name = name;
        }
    }
}
