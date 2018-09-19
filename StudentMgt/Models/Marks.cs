using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMgt.Models
{
    public class Marks
    {
        public int ID { get; set; }
        //student details forign key
        public int Student_detailsID{ get; set; }
        // public int Student_DetailsID { get; set; }
        [Required]
        public float Maths { get; set; }
        [Required]
        public float Chem { get; set; }
        [Required]
        public float Physics { get; set; }

       // public virtual Student_details Student_Details { get; set; }

    }
}
