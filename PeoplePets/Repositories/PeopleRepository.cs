using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace PeoplePets.Repositories
{

    using Entities;

    /// <summary>
    /// People repository client
    /// </summary>
    public class PeopleRepository : IResourceRepository<People>
    {

        IResourceProvider<People> _resourceProvider;
        string _resourceName;

        public PeopleRepository(IResourceProvider<People> resourceProvider, string resourceName)
        {
            _resourceProvider = resourceProvider;
            _resourceName = resourceName;
        }

        public Task<People> Read(IReadContext readContext)
        {
            // This method will remain not implemented until such time that the 
            // specifics about the service capabilities for querying data is known
            throw new NotImplementedException();
        }

        public Task<IEnumerable<People>> ReadAll()
        {
            return _resourceProvider.ReadAll(_resourceName);
        }
    }
}