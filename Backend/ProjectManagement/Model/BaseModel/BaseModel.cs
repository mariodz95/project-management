using Model.Common.Base;
using System;


namespace Model
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
