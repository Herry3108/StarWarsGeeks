﻿namespace StarWarsGeeks.Common;

public class Result<T>
{
    private readonly T? _value;
    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
        Error = Error.None;
    }
    private Result(Error error)
    {
        if (error == Error.None)
        {
            throw new ArgumentException("invalid error", nameof(error));
        }
        IsSuccess = false;
        Error = error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("there is no value for failure");
            }
            return _value!;
        }
        private init => _value = value;
    }
    public Error Error { get; }
    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }
    public static Result<T> Failure(Error error)
    {
        return new Result<T>(error);
    }
}
