﻿namespace ScientificPublications.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

    }
}
