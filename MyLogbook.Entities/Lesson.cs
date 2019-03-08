using MyLogbook.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLogbook.Entities
{
	[Table("lessons")]
	class Lesson : DbEntity
	{
		[Column("name")]
		[StringLength(64)]
		public string Name { get; set; }
	}
}
