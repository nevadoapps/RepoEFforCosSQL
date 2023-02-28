using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoEFCosSQL.Entities
{
    public class LevelEntity : BaseEntity
    {
        public string? LevelName { get; set; }
        public bool? IsCompleted { get; set; }
        public int? NumberOfStart { get; set; }
        public PlayerEntity? Player { get; set; }
    }
}
