using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class Result<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public String Error { get; set; }

        /// <summary>
        /// Successes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };

        /// <summary>
        /// Failures the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = error };
    }
}
