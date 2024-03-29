﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string AuthorFullName { get; set; }

        [StringLength(150)]
        public string AuthorImage { get; set; }

        [StringLength(300)]
        public string AuthorAbout { get; set; }

        [StringLength(50)]
        public string AuthorTitle { get; set; }

        [StringLength(100)]
        public string AuthorAboutShort { get; set; }

        [StringLength(50)]
        public string AuthorMail { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }


        //Yazar-Blog İlişkisi
        public ICollection<Blog> Blogs { get; set; }
    }
}
