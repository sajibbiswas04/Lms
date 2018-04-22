using System;
using System.Collections.Generic;
using System.Text;
using Common.Repository;
using Common.Service;
using Model;
using Model.Repo;
using RequestModel;
using ViewModel;

namespace Service
{
    public class TeacherService: GenericService<Teacher, TeacherRequestModel, TeacherViewModel>
    {
        public TeacherService(IGenericRepository<Teacher> repository) : base(repository)
        {

        }
    }
}
