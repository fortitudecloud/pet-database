using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePets
{

    /// <summary>
    /// Generic repository client
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public interface IResourceRepository<R> where R : IResource
    {

        /// <summary>
        /// Reads a single entity from the resource
        /// </summary>
        /// <param name="readContext"></param>
        /// <returns></returns>
        Task<R> Read(IReadContext readContext);

        /// <summary>
        /// Reads all entities found at the resource
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<R>> ReadAll();

    }

}
