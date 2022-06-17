using LogicLayer.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.iFace
{
    public interface IService
    {
        List<ProjectDTO> getProjects();

    }
}
