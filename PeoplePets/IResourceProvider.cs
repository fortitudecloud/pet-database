using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePets
{

    /// <summary>
    /// Service class for providing cloud resources abstracting away differentiating technologies
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public interface IResourceProvider<R> where R : IResource
    {

        /// <summary>
        /// Reads a single entity from the resource
        /// </summary>
        /// <param name="resourceName">Name of the resource being targeted</param>
        /// <param name="readContext">Context around read conditions</param>
        /// <returns></returns>
        Task<R> ReadOne(string resourceName, IReadContext readContext);

        /// <summary>
        /// Read all entities at the resource
        /// </summary>
        /// <param name="resourceName">Name of the resource being targeted</param>
        /// <returns></returns>
        Task<IEnumerable<R>> ReadAll(string resourceName);

    }

    /// <summary>
    /// Allows methods to give context to a read request. Can bubble technological details to the implementation level
    /// </summary>
    public interface IReadContext
    {

        /// <summary>
        /// Allows manipulation of request object. (Can be used to query resource)
        /// </summary>
        /// <param name="req"></param>
        Task BeforeRead(dynamic req);

    }    

}
