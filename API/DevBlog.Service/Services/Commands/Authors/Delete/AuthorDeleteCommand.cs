﻿using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Delete
{
    public class AuthorDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}