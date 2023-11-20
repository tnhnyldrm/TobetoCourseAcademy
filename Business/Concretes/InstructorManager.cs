﻿using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);
            return new SuccessResult(Messages.InstructorAdded);
        }

        public IResult Delete(Instructor instructor)
        {
            _instructorDal.Delete(instructor);
            return new SuccessResult(Messages.InsructorDeleted);
        }

        public IDataResult<List<Instructor>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Instructor>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<Instructor> GetById(int id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(c => c.Id == id));
        }

        public IResult Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);
            return new SuccessResult(Messages.InsructorUpdated);
        }
    }
}
