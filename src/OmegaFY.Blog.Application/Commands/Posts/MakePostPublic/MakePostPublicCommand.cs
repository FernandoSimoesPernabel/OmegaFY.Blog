﻿using OmegaFY.Blog.Application.Commands.Base;

namespace OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;

public class MakePostPublicCommand : CommandMediatRBase<MakePostPublicCommandResult>
{
    public Guid Id { get; set; }

    public MakePostPublicCommand() { }

    public MakePostPublicCommand(Guid id)
    {
        Id = id;
    }
}