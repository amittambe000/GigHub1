using System.Collections.Generic;

namespace GigHub1.Models.Dto
{
    public class GigDto
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public UserDto Artist { get; set; }

        public System.DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

    }
}