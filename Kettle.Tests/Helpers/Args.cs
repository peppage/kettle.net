namespace Kettle.Tests
{
    internal static class Args
    {
        public static CancellationToken CancellationToken
        {
            get { return Arg.Any<CancellationToken>(); }
        }

        public static IRequest Request
        {
            get { return Arg.Any<IRequest>(); }
        }
    }
}