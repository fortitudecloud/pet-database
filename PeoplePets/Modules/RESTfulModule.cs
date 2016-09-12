using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System;

using Nancy;

namespace PeoplePets.Modules
{
    /// <summary>
    /// Simple REST resource. Currently limited functionality
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public abstract class RESTfulModule<R> : NancyModule where R : IResource
    {

        protected IResourceRepository<R> _repo;

        public RESTfulModule(IResourceRepository<R> repository, string resourcePath)
            : base(resourcePath)
        {
            _repo = repository;            

            // Route to get all entities
            Get["/", true] = async (_, token) => Response.AsJson(await GetJson());

            //  Route to get single entity. Not currently implemented and will be picked up by the before hook
            Get["/{query}", true] = async (_, token) => Response.AsJson(await GetJson());

            this.Before += (ctx) =>
            {
                // Determine if the request was querying for a single entity. If so, return the not implemented status
                // code as this resource does not have querying capabilities
                if (ctx.Parameters.query != null) ctx.Response = HttpStatusCode.NotImplemented;

                return null;
            }; 
        }        

        /// <summary>
        /// Gets the response of all entities with the given resource
        /// </summary>
        /// <returns></returns>
        protected async Task<IEnumerable<R>> GetJson()
        {
            return await _repo.ReadAll();
        }

    }
}