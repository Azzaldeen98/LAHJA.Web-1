namespace Shared.Wrapper
{
    //public abstract class Either2<L, R>
    //{
    //    public class Left : Either<L, R>
    //    {
    //        public L Value { get; }
    //        public Left(L value) => Value = value;
    //    }

    //    public class Right : Either<L, R>
    //    {
    //        public R Value { get; }
    //        public Right(R value) => Value = value;
    //    }

    //    public static Either<L, R> Left(L left) => new Left(left);
    //    public static Either<L, R> Right(R right) => new Right(right);

    //}
    public abstract class Either<L, R>
    {
        private Either() { }

        public sealed class LeftResult : Either<L, R>
        {
            public L Value { get; }
            public LeftResult(L value) => Value = value;
        }

        public sealed class RightResult : Either<L, R>
        {
            public R Value { get; }
            public RightResult(R value) => Value = value;
        }

        // Factory methods
        public static Either<L, R> Left(L value) => new LeftResult(value);
        public static Either<L, R> Right(R value) => new RightResult(value);

        // Helpers to check and cast
        public bool IsLeft => this is LeftResult;
        public bool IsRight => this is RightResult;

        public L LeftValue => this is LeftResult left
            ? left.Value
            : throw new InvalidOperationException("Not a Left");

        public R RightValue => this is RightResult right
            ? right.Value
            : throw new InvalidOperationException("Not a Right");

        // Match helper (like switch)
        public T Match<T>(Func<L, T> leftFunc, Func<R, T> rightFunc)
        {
            return this switch
            {
                LeftResult l => leftFunc(l.Value),
                RightResult r => rightFunc(r.Value),
                _ => throw new InvalidOperationException("Invalid Either state")
            };
        }
     }
    }