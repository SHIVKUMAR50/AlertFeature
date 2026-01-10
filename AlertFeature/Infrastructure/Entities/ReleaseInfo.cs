using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class ReleaseInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public int? AlertId { get; set; }
        public AlertInfo? AlertInfo { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
