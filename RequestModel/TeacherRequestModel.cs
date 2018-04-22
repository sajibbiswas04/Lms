using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Common.RequestModel;
using Common.ViewModel;
using Model;

namespace RequestModel
{
    public class TeacherRequestModel:BaseRequestModel<Teacher>
    {
        public TeacherRequestModel(string keyword, string mincredit = "MinCredit", 
            string maxcredit = "MaxCredit") : base(keyword, mincredit, maxcredit)
        {

        }

        protected override Expression<Func<Teacher, bool>> GetExpression()
        {
            if (Keyword != null && MinCredit != null && MaxCredit != null)
            {
                ExpressionObj = x => (x.TotalCredit > Convert.ToDouble(MinCredit)
                && x.TotalCredit < Convert.ToDouble(MaxCredit)) 
                || (x.Name.Contains(Keyword) || x.Phone.Contains(Keyword) || x.Courses.Contains(Keyword)) ;
            }

            if (MinCredit != null && MaxCredit != null)
            {
                ExpressionObj = x => x.TotalCredit > Convert.ToDouble(MinCredit) 
                && x.TotalCredit < Convert.ToDouble(MaxCredit);
            }
            if (Keyword != null)
            {
                ExpressionObj = x => x.Name.Contains(Keyword) || x.Phone.Contains(Keyword) || x.Courses.Contains(Keyword);
            }
            if (MinCredit != null)
            {
                ExpressionObj = x => x.TotalCredit > Convert.ToDouble(MinCredit) ;
            }
            if (MaxCredit != null)
            {
                ExpressionObj = x => x.TotalCredit < Convert.ToDouble(MaxCredit);
            }

            ExpressionObj = ExpressionObj.And(GenerateBaseEntityExpression());
            return ExpressionObj;
        }

        public override Expression<Func<Teacher, DropdownViewModel>> Dropdown()
        {
            return x => new DropdownViewModel() { Id = x.Id, Text = x.Name, Data = x };
        }
    }
}
