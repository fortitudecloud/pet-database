using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace PeoplePets
{

    using RestSharp;

    /// <summary>
    /// AGL resource provider for the programming challenge service (HTTP service)
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public class AGLCloudProvider<R> : IResourceProvider<R> where R : IResource
    {

        IRestClient _restClient;

        public AGLCloudProvider(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public Task<R> ReadOne(string resourceName, IReadContext readContext)
        {
            // This method will remain not implemented until such time that the 
            // specifics about the service capabilities for querying data is known
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<R>> ReadAll(string resourceName)
        {
            // Get all the entities at the resource and return

            var req = new RestRequest(resourceName, Method.GET);
            var res = await _restClient.ExecuteGetTaskAsync<List<R>>(req);

            // Raise http status exceptions for unexpected results

            if (res.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception(res.StatusCode.ToString());
            
            // Return entities

            return res.Data;
        }

    }
}