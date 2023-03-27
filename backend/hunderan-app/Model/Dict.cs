using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hunderan_app.Model
{
	[Table("Traslation")]
	public class Dict
	{
		[Key,Required]
		public int Id { get; set; }

		public string SourceEng { get; set; }

		public string Targetlanguage { get; set; }
	}
}

	