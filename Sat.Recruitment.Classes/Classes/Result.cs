﻿namespace Sat.Recruitment.Classes
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public Result(bool isSuccess, string errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }   
    }
}
