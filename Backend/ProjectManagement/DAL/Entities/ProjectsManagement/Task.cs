﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Priority { get; set; }
        public string Estimated { get; set; }
        public Guid TaskCategoryId { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<Comment> Comment { get; set; }
    }
}