using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtChalenge.Core.Interfaces
{
    public interface IMovieQueryDto
    {
        public int IdMovie { get; set; }

        public string Name { get; set; } 
        public int IdComment { get; set; }
        public string? ImagenPath { get; set; }
    }
}
