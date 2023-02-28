using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoEFCosSQL.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<LevelEntity> Levels { get; set; }
    }
}
