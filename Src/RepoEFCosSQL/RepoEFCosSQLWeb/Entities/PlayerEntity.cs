﻿namespace RepoEFCosSQLWeb.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
