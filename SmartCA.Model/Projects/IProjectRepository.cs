using mySmartCA.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Projects
{
    public interface IProjectRepository : IRepository<Project>
    {
        IList<Project> FindBy(object sector, object segment, bool completed);
    }
}
