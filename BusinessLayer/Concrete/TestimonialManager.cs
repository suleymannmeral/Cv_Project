﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : IGenericService<Testimonial>
    {
        public void TAdd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetBYID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
