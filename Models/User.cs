using System;
using System.ComponentModel.DataAnnotations;

namespace authentication.Models
{
	public class User
	{
		[Key]
		public Guid Id { get; set; }
		public string? Name { get; set; }
        public string? Password { get; set; }
		public bool IsAvtive { get; set; } = false;
		public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

