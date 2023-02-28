namespace RepoEFCosSQLWeb.Entities
{
    public class LevelEntity : BaseEntity
    {
        public string? LevelName { get; set; }
        public bool? IsCompleted { get; set; }
        public int? NumberOfStart { get; set; }
        public PlayerEntity? Player { get; set; }
    }
}
