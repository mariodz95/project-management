﻿using System;

namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
