﻿using Microsoft.AspNetCore.Mvc;

namespace ReviewService.Models
{
    public enum ReviewStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
