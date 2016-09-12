using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace PeoplePets.Repositories
{

    using Entities;

    /// <summary>
    /// Pet repository client. (Currently not supported)
    /// </summary>
    public class PetRepository : IResourceRepository<Pet>
    {

        IResourceProvider<Pet> _resourceProvider;
        string _resourceName;

        public PetRepository(IResourceProvider<Pet> resourceProvider, string resourceName) 
        {
            _resourceProvider = resourceProvider;
            _resourceName = resourceName;
        }

        public Task<Pet> Read(IReadContext readContext)
        {
            // This method will remain not implemented until such time that the 
            // specifics about the service capabilities for querying data is known
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pet>> ReadAll()
        {
            return _resourceProvider.ReadAll(_resourceName);
        }

    }
}