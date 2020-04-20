﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common.Base
{
    public interface IBaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
