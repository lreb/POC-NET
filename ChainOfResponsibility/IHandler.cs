namespace ChainOfResponsibility
{
    /// <summary>
    /// Represent a request
    /// </summary>
    /// <typeparam name="T">any kind of common model validation</typeparam>
    public interface IHandler<T> where T : class
    {
        /// <summary>
        /// Sets next chain validation
        /// </summary>
        /// <param name="next">Common model to validate</param>
        /// <returns></returns>
        IHandler<T> SetNext(IHandler<T> next);
        /// <summary>
        /// Validate the chain
        /// </summary>
        /// <param name="request"></param>
        void Handle(T request);
    }
}
