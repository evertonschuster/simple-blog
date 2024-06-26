﻿using SimpleBlog.Domain.Blogs.Exceptions;
using SimpleBlog.Domain.Core;

namespace SimpleBlog.Domain.Blogs
{
    public class Post : Entity
    {
        public Post() { }

        public Post(string title, string? body, List<string> tags, Guid createdBy)
        {
            Title = title;
            Body = body;
            Tags = tags;
            CreatedBy = createdBy;
        }

        public string Title { get; private set; }

        public string? Body { get; private set; }

        public List<string> Tags { get; private set; }

        public void Update(string title, string body, List<string> tags)
        {
            ValidateTitle(title);

            Title = title;
            Body = body;
            Tags = tags;
        }

        public static Post Create(string title, string? body, List<string> tags, Guid createdBy)
        {
            ValidateTitle(title);

            return new Post(title, body, tags, createdBy);
        }

        private static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new TitleWhiteSpaceException();
            }
            if (title.Length > 100)
            {
                throw new TitleTooLongException();
            }
        }
    }
}
