namespace ChainOfResponsibility
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        /// <summary>
        /// Chain to validate
        /// </summary>
        private IHandler<T> Next { get; set; }

        /// <summary>
        /// Start validation
        /// </summary>
        /// <param name="request"></param>
        public virtual void Handle(T request)
        {
            Next?.Handle(request);
        }

        /// <summary>
        /// Set next validation
        /// </summary>
        /// <param name="next">handler</param>
        /// <returns></returns>
        public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            return Next;
        }
    }
}
