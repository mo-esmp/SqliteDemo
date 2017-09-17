using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.SeedWork
{
    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    public class OperationResult
    {
        private readonly List<ValidationResult> _errors = new List<ValidationResult>();

        private OperationResult()
        {
        }

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value> True if the operation succeeded, otherwise false. </value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see
        /// cref="T:ValidationResult"/> s containing an error that occurred during the  operation.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see
        /// cref="T:ValidationResult"/> s.
        /// </value>
        public IEnumerable<ValidationResult> ValidationResults => _errors;

        public IEnumerable<string> ErrorMessages
        {
            get { return _errors.Select(er => er.Message); }
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a successful operation.
        /// </summary>
        /// <returns> An <see cref="T:OperationResult"/> indicating a successful operation. </returns>
        public static OperationResult Success()
        {
            var operationResult = new OperationResult
            {
                Succeeded = true
            };

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errorMessage"/> if applicable.
        /// </summary>
        /// <param name="errorMessage">
        /// An string error message which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errorMessage"/> if applicable.
        /// </returns>
        public static OperationResult Failed(string errorMessage)
        {
            var operationResult = new OperationResult { Succeeded = false };
            operationResult._errors.Add(new ValidationResult(errorMessage));

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">
        /// An optional array of <see cref="T:OperationResult"/> s which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errors"/> if applicable.
        /// </returns>
        public static OperationResult Failed(params ValidationResult[] errors)
        {
            var operationResult = new OperationResult { Succeeded = false };
            if (errors != null)
                operationResult._errors.AddRange(errors);

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">
        /// An optional array of <see cref="T:OperationResult"/> s which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errors"/> if applicable.
        /// </returns>
        public static OperationResult Failed(IEnumerable<ValidationResult> errors)
        {
            var operationResult = new OperationResult { Succeeded = false };
            if (errors != null)
                operationResult._errors.AddRange(errors);

            return operationResult;
        }
    }

    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    public class OperationResult<T>
    {
        private T _data;
        private readonly List<ValidationResult> _errors = new List<ValidationResult>();

        /// <summary>
        /// Gets or sets the additional data.
        /// </summary>
        /// <value> The data. </value>
        public T Data => _data;

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value> True if the operation succeeded, otherwise false. </value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see
        /// cref="T:ValidationResult"/> s containing an error that occurred during the  operation.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see
        /// cref="T:ValidationResult"/> s.
        /// </value>
        public IEnumerable<ValidationResult> ValidationResults => _errors;

        public IEnumerable<string> ErrorMessages
        {
            get { return _errors.Select(er => er.Message); }
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a successful operation with data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>OperationResult&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException">data</exception>
        public static OperationResult<T> Success(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var operationResult = new OperationResult<T>
            {
                _data = data,
                Succeeded = true
            };

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errorMessage"/> if applicable.
        /// </summary>
        /// <param name="errorMessage">
        /// An string error message which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errorMessage"/> if applicable.
        /// </returns>
        public static OperationResult<T> Failed(string errorMessage)
        {
            var operationResult = new OperationResult<T> { Succeeded = false };
            operationResult._errors.Add(new ValidationResult(errorMessage));

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">
        /// An optional array of <see cref="T:OperationResult"/> s which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errors"/> if applicable.
        /// </returns>
        public static OperationResult<T> Failed(params ValidationResult[] errors)
        {
            var operationResult = new OperationResult<T> { Succeeded = false };
            if (errors != null)
                operationResult._errors.AddRange(errors);

            return operationResult;
        }

        /// <summary>
        /// Creates an <see cref="T:OperationResult"/> indicating a failed operation, with a
        /// list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">
        /// An optional array of <see cref="T:OperationResult"/> s which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="T:OperationResult"/> indicating a failed operation, with a list of
        /// <paramref name="errors"/> if applicable.
        /// </returns>
        public static OperationResult<T> Failed(IEnumerable<ValidationResult> errors)
        {
            var operationResult = new OperationResult<T> { Succeeded = false };
            if (errors != null)
                operationResult._errors.AddRange(errors);

            return operationResult;
        }
    }
}