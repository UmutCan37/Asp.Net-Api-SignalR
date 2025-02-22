﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.Testimonial
{
    public class ResultTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string TestimonialName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}
