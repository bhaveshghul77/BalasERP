using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
	public class DataInputOptionModel : BaseModel
	{
		[Key]
		public int Id { get; set; }

        [Required]
        [DisplayName("DataInput")]
        public int DataInputMasterId { get; set; }
		public string? DataInput { get; set; }

		[Required]
		[DisplayName("Option Name")]
		public string? OptionName { get; set; }

        [Required]
        [DisplayName("Millimetre")]
        public int MillimetreMasterId { get; set; }
		public string? Millimetre { get; set; }

		//public int OptionValue { get; set; }
	}
}
