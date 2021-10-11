﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueListKanban.Models
{
    public class UserAddress
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public UserAddressGeo Geo { get; set; }

    }
}