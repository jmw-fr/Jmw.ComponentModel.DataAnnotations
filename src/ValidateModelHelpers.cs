// <copyright file="ValidateModelHelpers.cs" company="Weeger Jean-Marc">
// Copyright Weeger Jean-Marc under MIT Licence. See https://opensource.org/licenses/mit-license.php.
// </copyright>

namespace Jmw.ComponentModel.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Object validation extension.
    /// </summary>
    /// <remarks>
    /// Copy /paste from http://www.technofattie.com/2011/10/05/recursive-validation-using-dataannotations.html. Thanks Josh !!!
    /// </remarks>
    public static class ValidateModelHelpers
    {
        /// <summary>
        /// Validate an object properties with <see cref="Validator" />.
        /// </summary>
        /// <typeparam name="T">Object type to validate.</typeparam>
        /// <param name="entity">Object to validate.</param>
        /// <exception cref="ValidationException"><paramref name="entity"/> validation failed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <c>null</c>.</exception>
        public static void ValidateModel<T>(this T entity)
            where T : class
        {
            ValidateModel(entity, null);
        }

        /// <summary>
        /// Validate an object properties with <see cref="Validator" />.
        /// </summary>
        /// <typeparam name="T">Object type to validate.</typeparam>
        /// <param name="entity">Object to validate.</param>
        /// <param name="items">
        /// A dictionary of key/value pairs to make available to the service consumers. This parameter is optional.
        /// </param>
        /// <exception cref="ValidationException"><paramref name="entity"/> validation failed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <c>null</c>.</exception>
        public static void ValidateModel<T>(this T entity, IDictionary<object, object> items)
            where T : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var validationContext = new ValidationContext(entity, items);
            Validator.ValidateObject(
                entity,
                validationContext,
                validateAllProperties: true);
        }
    }
}
