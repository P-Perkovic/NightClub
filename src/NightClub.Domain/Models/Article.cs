﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class Article : Entity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishingDate { get; set; }

        public Photo Photo { get; set; }
    }
}
