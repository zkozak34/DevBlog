﻿using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.Login
{
    public class AuthorLoginQuery : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
