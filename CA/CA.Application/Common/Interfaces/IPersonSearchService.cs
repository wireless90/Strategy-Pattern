using CA.Domain;
using System;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    /// <summary>
    ///     Searches for Persons by dynamically accepting the name of a search strategy
    ///     
    ///     <example>
    ///         <code>
    ///             IQueryable<Person> personQuery = _personSearchService
    ///                 .SearchIdentification("PersonIdContainsAndTypeEquals", new PersonIdentification() { Identification = "12345", Type = "T"})
    ///                 .SearchName("PersonNamePermutePlus", new PersonName() { Name = "RAZALI" })
    ///                 .AsQueryable();
    ///         </code>
    ///     </example>
    /// </summary>
    public interface IPersonSearchService
    {
        /// <summary>
        ///     Initializes the personQuery of your choice.
        ///     If this method is not called, the default personQuery would be of _personDbContext.Persons.
        ///     <see cref="CA.Application.Common.Interfaces.IPersonDbContext"/>
        /// </summary>
        /// <param name="personQuery">The IQueryable<Person> to initialize to.</param>
        /// <returns>Returns the current class itself.</returns>
        IPersonSearchService InitializeSet(IQueryable<Person> personQuery);

        /// <summary>
        ///     Given the name of a strategy to run, builds upon the existing IQueryable<Person> query;
        /// </summary>
        /// <param name="nameOfStrategy">
        ///     The name of the strategy to run.
        ///     <see cref="CA.Application.Common.Constants.PersonSearchStrategyConstants.PersonName"/>
        /// </param>
        /// <param name="personName">Contains parameters needed for the strategy to run.</param>
        /// <param name="isEagerLoaded">
        ///     If set to true, constructs the IQueryable<Person> in a way to load all PersonNames for this Person, within this query, 
        /// </param>
        /// <returns>Returns the current class itself.</returns>
        IPersonSearchService SearchName(String nameOfStrategy, PersonName personName, bool isEagerLoaded = true);

        /// <summary>
        ///     Given the name of a strategy to run, builds upon the existing IQueryable<Person> query;
        /// </summary>
        /// <param name="nameOfStrategy">
        ///     The name of the strategy to run.
        ///     <see cref="CA.Application.Common.Constants.PersonSearchStrategyConstants.PersonIdentification"/>
        /// </param>
        /// <param name="personIdentification">Contains parameters needed for the strategy to run.</param>
        /// <param name="isEagerLoaded">
        ///     If set to true, constructs the IQueryable<Person> in a way to load all PersonIdentifications for this Person, within this query, 
        /// </param>
        /// <returns></returns>
        IPersonSearchService SearchIdentification(String nameOfStrategy, PersonIdentification personIdentification, bool isEagerLoaded = true);

        /// <summary>
        /// Returns the IQueryable<Person> result.
        /// </summary>
        /// <returns>The current constructed IQueryable<Person></returns>
        IQueryable<Person> AsQueryable();
    }
}
