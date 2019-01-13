using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class Traits : IStateObject
    {
        [Key]
        public int TraitsId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public bool IsDelete { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public Traits(int subjectId)
        {
            SubjectId = subjectId;
            ObjectState = ObjectState.Added;
        }

        private Traits() { }
    }
}
