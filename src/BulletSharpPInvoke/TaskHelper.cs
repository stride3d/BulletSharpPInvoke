// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace BulletSharp
{
    /// <summary>Extensions for TaskFactory.</summary>
    public static class TaskHelper
    {
        // dummy implem
        public static readonly Task CompletedTask = Task.Delay(0);

        /// <summary>
        /// Creates a Task that has completed in the Faulted state with the specified exception.
        /// </summary>
        /// <param name="exception">The exception with which the Task should fault.</param>
        /// <returns>The completed Task.</returns>
        public static Task FromException(Exception exception)
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetException(exception);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a Task that has completed in the Faulted state with the specified exception.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of payload for the new Task.</typeparam>
        /// <param name="exception">The exception with which the Task should fault.</param>
        /// <returns>The completed Task.</returns>
        public static Task<TResult> FromException<TResult>(Exception exception)
        {
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetException(exception);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a Task that has completed in the RanToCompletion state with the specified result.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of payload for the new Task.</typeparam>
        /// <param name="result">The result with which the Task should complete.</param>
        /// <returns>The completed Task.</returns>
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetResult(result);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a Task that has completed in the Canceled state with the specified CancellationToken.
        /// </summary>
        /// <param name="cancellationToken">The CancellationToken with which the Task should complete.</param>
        /// <returns>The completed Task.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">cancellationToken</exception>
        public static Task FromCanceled(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested) throw new ArgumentOutOfRangeException("cancellationToken");
            return new Task(() => { }, cancellationToken);
        }

        /// <summary>
        /// Creates a Task that has completed in the Canceled state with the specified CancellationToken.
        /// </summary>
        /// <typeparam name="TResult">Specifies the type of payload for the new Task.</typeparam>
        /// <param name="cancellationToken">The CancellationToken with which the Task should complete.</param>
        /// <returns>The completed Task.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">cancellationToken</exception>
        public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested) throw new ArgumentOutOfRangeException("cancellationToken");
            return new Task<TResult>(DelegateCache<TResult>.DefaultResult, cancellationToken);
        }

        /// <summary>A cache of delegates.</summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        private class DelegateCache<TResult>
        {
            /// <summary>Function that returns default(TResult).</summary>
            internal static readonly Func<TResult> DefaultResult = () => default(TResult);
        }
    }
}