using System;

namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Text { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}
