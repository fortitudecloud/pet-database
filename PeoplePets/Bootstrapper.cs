using System.Configuration;

using Nancy;

namespace PeoplePets
{

    using Entities;
    using Repositories;

    public class Bootstrapper : DefaultNancyBootstrapper
    {

        public static string _AGLResourceUrl;        

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            // Configurations

            _AGLResourceUrl = ConfigurationManager.AppSettings["AGLBaseURL"].ToString();
            var _peopleResourceName = ConfigurationManager.AppSettings["PeopleResourceName"].ToString();
            var _petResourceName = ConfigurationManager.AppSettings["PetResourceName"].ToString();

            // Declare custom dependency composition objects                        

            container.Register(typeof(IResourceProvider<People>), (c, p) =>
            {
                return new AGLCloudProvider<People>(_AGLResourceUrl);
            });

            container.Register(typeof(IResourceProvider<Pet>), (c, p) =>
            {
                return new AGLCloudProvider<Pet>(_AGLResourceUrl);
            });            

            container.Register<IResourceRepository<People>>((c, p) =>
            {
                var provider = c.Resolve<IResourceProvider<People>>();
                return new PeopleRepository(provider, _peopleResourceName);
            });

            container.Register<IResourceRepository<Pet>>((c, p) =>
            {
                var provider = container.Resolve<IResourceProvider<Pet>>();
                return new PetRepository(provider, _petResourceName);
            });
        }

    }
}