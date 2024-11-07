using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
           _testimonialDAL.Delete(t);
        }

        public Testimonial TGetBYID(int id)
        {
            return _testimonialDAL.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDAL.GetList();
        }

        public void TUpdate(Testimonial t)
        {
          _testimonialDAL.Update(t);
        }
    }
}
