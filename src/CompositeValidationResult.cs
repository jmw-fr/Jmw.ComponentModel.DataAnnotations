// <copyright file="CompositeValidationResult.cs" company="Weeger Jean-Marc">
// Copyright Weeger Jean-Marc under MIT Licence. See https://opensource.org/licenses/mit-license.php.
// </copyright>

namespace Jmw.ComponentModel.DataAnnotations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Composite validation result.
    /// </summary>
    /// <remarks>
    /// Copy /paste from http://www.technofattie.com/2011/10/05/recursive-validation-using-dataannotations.html. Thanks Josh !!!.
    /// </remarks>
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidationResult"/> class.
        /// Constructeur.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public CompositeValidationResult(string errorMessage)
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="memberNames">Members rejected.</param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames)
            : base(errorMessage, memberNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="validationResult">Validation result.</param>
        protected CompositeValidationResult(ValidationResult validationResult)
            : base(validationResult)
        {
        }

        /// <summary>
        /// Gets validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return results;
            }
        }

        /// <summary>
        /// Add a new validation result.
        /// </summary>
        /// <param name="validationResult">Validation result to add.</param>
        public void AddResult(ValidationResult validationResult)
        {
            results.Add(validationResult);
        }
    }
}
