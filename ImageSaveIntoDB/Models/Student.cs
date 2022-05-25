using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSaveIntoDB.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        
        public string Name { get; set; }

        public string Roll { get; set; }

        public byte[] Photo{ get; set; }
    }
}
