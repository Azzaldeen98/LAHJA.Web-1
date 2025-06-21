//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Domain.Wrapper;
//{

//        public class Result : IResult
//        {
//            public Result()
//            {
//            }

//            public List<string> Messages { get; set; } = new List<string>();

//            public bool Succeeded { get; set; }
//            public int HttpCode { get; set; }

//            public static IResult Fail(int httpCode = 0)
//            {
//                return new Result { Succeeded = false, HttpCode = httpCode };
//            }

//            public static IResult Fail(string message, int httpCode = 0)
//            {
//                return new Result { Succeeded = false, HttpCode = httpCode, Messages = new List<string> { message } };
//            }

//            public static IResult Fail(List<string> messages, int httpCode = 0)
//            {
//                return new Result { Succeeded = false, Messages = messages, HttpCode = httpCode };
//            }

//            public static Task<IResult> FailAsync()
//            {
//                return Task.FromResult(Fail());
//            }

//            public static Task<IResult> FailAsync(string message, int httpCode = 0)
//            {
//                return Task.FromResult(Fail(message, httpCode));
//            }

//            public static Task<IResult> FailAsync(List<string> messages, int httpCode = 0)
//            {
//                return Task.FromResult(Fail(messages, httpCode));
//            }

//            public static IResult Success()
//            {
//                return new Result { Succeeded = true };
//            }

//            public static IResult Success(string message)
//            {
//                return new Result { Succeeded = true, Messages = new List<string> { message } };
//            }

//            public static Task<IResult> SuccessAsync()
//            {
//                return Task.FromResult(Success());
//            }

//            public static Task<IResult> SuccessAsync(string message)
//            {
//                return Task.FromResult(Success(message));
//            }
//        }

//        public class Result<T> : Result, IResult<T>
//        {
//            public Result()
//            {
//            }

//            public T Data { get; set; }

//            public new static Result<T> Fail(int httpCode = 0)
//            {
//                return new Result<T> { Succeeded = false, HttpCode = httpCode };
//            }

//            public new static Result<T> Fail(string message, int httpCode = 0)
//            {
//                return new Result<T> { Succeeded = false, HttpCode = httpCode, Messages = new List<string> { message } };
//            }

//            public new static Result<T> Fail(List<string> messages, int httpCode = 0)
//            {
//                return new Result<T> { Succeeded = false, Messages = messages, HttpCode = httpCode };
//            }

//            public new static Task<Result<T>> FailAsync(int httpCode = 0)
//            {
//                return Task.FromResult(Fail(httpCode));
//            }

//            public new static Task<Result<T>> FailAsync(string message, int httpCode = 0)
//            {
//                return Task.FromResult(Fail(message, httpCode));
//            }

//            public new static Task<Result<T>> FailAsync(List<string> messages, int httpCode = 0)
//            {
//                return Task.FromResult(Fail(messages, httpCode));
//            }

//            public new static Result<T> Success()
//            {
//                return new Result<T> { Succeeded = true };
//            }

//            public new static Result<T> Success(string message)
//            {
//                return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
//            }

//            public static Result<T> Success(T data)
//            {

//            return new Result<T> { Succeeded = true, Data = data };
//            }

//            public static Result<T> Success(T data, string message)
//            {
//                return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
//            }

//            public static Result<T> Success(T data, List<string> messages)
//            {
//                return new Result<T> { Succeeded = true, Data = data, Messages = messages };
//            }

//            public new static Task<Result<T>> SuccessAsync()
//            {
//                return Task.FromResult(Success());
//            }

//            public new static Task<Result<T>> SuccessAsync(string message)
//            {
//                return Task.FromResult(Success(message));
//            }

//            public static Task<Result<T>> SuccessAsync(T data)
//            {
//                return Task.FromResult(Success(data));
//            }

//            public static Task<Result<T>> SuccessAsync(T data, string message)
//            {
//                return Task.FromResult(Success(data, message));
//            }
//        }


//}