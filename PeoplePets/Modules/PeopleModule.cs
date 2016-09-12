using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

using Nancy;

namespace PeoplePets.Modules
{

    using Entities;
    using Models;    

    /// <summary>
    /// Extends the RESTful resource module and adds helpful web services
    /// </summary>
    public class PeopleModule : RESTfulModule<People>
    {

        public PeopleModule(IResourceRepository<People> repository)
            : base(repository, "/people")
        {            
            Get["/cats_by_gender", true] = async (_, token) => Response.AsJson(await GetCatsByGender());
        }

        /// <summary>
        /// Gets a list of cat names by their owners gender
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        async Task<IEnumerable<PetGender>> GetCatsByGender()
        {
            // Group cat names by their owners gender and return ordered custom list

            return

            (await
                this.GetJson())
                .Where(p => p.pets != null)
                .Select(p => new
                {
                    Gender = p.gender,
                    PetNames = 
                        p.pets
                        .Where(t => t.type == "Cat")
                        .Select(n => n.name).ToArray()
                })

                .GroupBy(g1 => g1.Gender)

                .Select(pets => new PetGender
                {
                    Gender = pets.Key,
                    PetNames =
                        pets
                        .Where(p => p.Gender == pets.Key)
                        .SelectMany(pn => pn.PetNames)
                        .OrderBy(o => o)
                        .ToArray()
                })                

                .ToList();
        }

    }

}